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
    public class CustomerController : DefaultController
    {

        private CustomerRepository _CustomerRepository;
        private MyDataEntities dbEntity;

        //protected override void Initialize(RequestContext requestContext)
        //{
        //    //base.Initialize(requestContext);
        //    //dbEntity = new MyDataEntities();
        //    //dbEntity.Database.Connection.Open();
        //    //_CustomerRepository = new CustomerRepository(dbEntity);
        //}

        // GET: Customer
        public ActionResult Index()
        {
            Title = "Clienti";
            _pageParameters = new PageParameters()
            {
                PageTitle = this.Title,
                ControllerName = ControllerName.CustomerController,
                FilterForData = null,
                HasEditButton = false,
                HasExportButton = false,
                HasDeleteButton = false,
                HasSaveButton = false,
            };

            SetParameters();

            var Data = this.LoadData(null);

            return View(Data);
        }

        public List<CustomerViewModel>  LoadData(string filter)
        {
            var AllCustomer= _CustomerRepository.GetAllCustomers();

            List<CustomerViewModel> list = new List<CustomerViewModel>();
	
		
	if (!String.IsNullOrEmpty(filter)  
	{
		
		AllCustomer= AllCustomer.Where(x=> x.Nome.ToUpper().StartWith(Filter.ToUpper()));
	}

		foreach(tCustomer x in AllCustomer.ToList())
		{	
			CustomerViewModel c= new CustomerViewModel(x);
			list.Add(c);
		}		


            return list;
        }


        public ActionResult Details(int? Id)
        {

            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PageParameters _pageParameters = new PageParameters()
            {
                PageTitle = "Dettaglio Cliente",
                ControllerName = ControllerName.CustomerController,
                               HasEditButton = false,
            };

            ViewBag.pageParameters = _pageParameters;

            //var Customer= _CustomerRepository.GetCustomerFromId(Id.Value) ;

            var model = new CustomerDetailsViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Details(CustomerDetailsViewModel model)
        {
            if (model == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


            return RedirectToAction("Index");

        }

        public ActionResult Create()
        {
            PageParameters _pageParameters = new PageParameters()
            {
                PageTitle = "Nuovo Cliente",
                ControllerName = ControllerName.CustomerController,
                HasScrollButton = false,
                HasAddElementButton = false,
                HasEditButton = false,
                HasDeleteButton = false
            };


            ViewBag.pageParameters = _pageParameters;

            return View();
        }

        //Create Post
        [HttpPost]
        public ActionResult Create(PreventiveDetailsViewModel model)
        {

            if (model == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //Redirect alla Index 
          

            return RedirectToAction("Index");
        }

        public JsonResult GetDataToAsyncForDialog(string filter)
        {
            JsonResult JsonResult = new JsonResult()
            {
                Data = new { object_ = new object[0] },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            //Prendo i dati richiesti
            List<CustomerViewModel> data = LoadData(filter);
            

            JsonResult.Data = new List<object>();

            if (data != null && data.Count > 0)
            {
                foreach (var item in data)
                {
                    string DataToShow = item.Nome;
                        string Optional = item.Email;
                        int Id = item.IdCliente;

                        ((List<object>)JsonResult.Data).Add(new { @datatoshow = DataToShow, @valueId = Id, @optional = Optional });
                    
                }
            }
            return JsonResult;
        }

    }
}