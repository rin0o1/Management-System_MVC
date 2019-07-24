using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;


using Crm_DataUtilities.Repository;
using Crm_DataUtilities.ViewModel;
using Crm_Global;
using Crm_Entities;

namespace Crm.Controllers
{
    
    public class ProductController : DefaultController
    {

        private MyDataEntities dbEntity;
        private ProductRepository _productRepository;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            dbEntity = new MyDataEntities();
            _productRepository = new ProductRepository(dbEntity);
            dbEntity.Database.Connection.Open();
            
        }

        public ActionResult Index()
        {
            
            Title = "Prodotti";
            _pageParameters = new PageParameters()
            {
                PageTitle = this.Title,
                ControllerName = ControllerName.Product,
                FilterForData = null,
                HasEditButton = false,
                HasExportButton = false,
                HasDeleteButton = false,
                HasSaveButton = false,

            };



            SetParameters();


            var data = LoadData(null);

            //Prendere tutti i prodotti
            return View(data);
        }

        public List<ProductViewModel> LoadData(string Filter)
        {
            var AllProducts = _productRepository.GetAllProducts();

            List<ProductViewModel> data = new List<ProductViewModel>();



            if (!String.IsNullOrEmpty(Filter))
            {
                AllProducts = AllProducts.Where(

                    x => x.NomeProdotto.ToUpper().StartsWith(Filter.ToUpper()));
            }


            foreach (var item in AllProducts.ToList())
            {
                ProductViewModel p = new ProductViewModel(item);
                data.Add(p);
            }


            return data;


            
        }

        //Details Get
        public  ActionResult Details(int ? Id)
        {

            if (Id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PageParameters _pageParameters = new PageParameters()
            {
                PageTitle = "Dettaglio Prodotto",
                ControllerName = ControllerName.Product,
                HasScrollButton = false,
                HasEditButton = false,
                HasGeneralFilter = false
               
            };


            ViewBag.pageParameters = _pageParameters;

            var Product = _productRepository.GetProductFromId(Id.Value);

            var model = new ProductDetailsViewModel(Product);

            return View(model);
        }

        public JsonResult GetDataToAsyncForDialog(string Filter)
        {

            JsonResult JsonResult = new JsonResult()
            {
                Data = new { object_ = new object[0] },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };


            //Prendo i dati dei preventivi filtrati
            List<ProductViewModel> data = LoadData(Filter);

            JsonResult.Data = new List<object>();

            if (data != null && data.Count > 0)
            {
                foreach (var item in data)
                {
                    //string PriceWithUm = item.PrezzoPerUnita.ToString() + "\xa0\xa0\xa0\xa0\xa0\xa0\xa0" + item.UM;
                    string DataToShow = item.NomeProdotto + "\xa0\xa0\xa0\xa0\xa0\xa0\xa0" + item.PrezzoPerUnita.ToString() + " " + item.UM;
                    //string[] DataToShow = new string[] { item.NomeProdotto, PriceWithUm };
                    int Id = item.IdProdotto;

                    ((List<object>)JsonResult.Data).Add(new { @datatoshow = DataToShow, @valueId = Id, @optional = -1 });
                }
            }
            return JsonResult;
        }


    }
}