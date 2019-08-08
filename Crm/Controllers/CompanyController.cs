using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Crm_DataUtilities.Repository;
using Crm_DataUtilities.ViewModel;
using Crm_Global;
using Crm_Entities;
using System.Web.Routing;

namespace Crm.Controllers
{
    public class CompanyController : DefaultController
    {

        private CompanyRepository _companyRepository;
        private MyDataEntities dbEntity;

        protected override void Initialize(RequestContext requestContext)
        {
            Title = "Ditte";
            base.Initialize(requestContext);
            dbEntity = new MyDataEntities();
            dbEntity.Database.Connection.Open();
            _companyRepository = new CompanyRepository(dbEntity);
        }
        // GET: Company
        public ActionResult Index()
        {
            _pageParameters = new PageParameters()
            {
                PageTitle = this.Title,
                ControllerName = ControllerName.Company,
                HasEditButton = false,
                HasExportButton = false,
                HasSaveButton = false,
                HasDeleteButton = false
            };
            SetParameters();
            var data = this.LoadData(null);
            return View();
        }

       
        public List<CompanyViewModel> LoadData(string Filter= null)
        {
            List<CompanyViewModel> Data = null;

            var AllProducts = _companyRepository.GetAllCompany();


            if (!String.IsNullOrEmpty(Filter))
            {
                AllProducts = AllProducts.Where(
                    x=>x.NomeDitta.ToUpper().StartsWith(Filter.ToUpper())
                    );
            }

            Data = new List<CompanyViewModel>();
            foreach (tDitte item in AllProducts.ToList())
            {
                CompanyViewModel c = new CompanyViewModel(item);
                Data.Add(c);
            }

            return Data;
        }

        public JsonResult GetDataToAsyncForDialog(string Filter)
        {
            JsonResult JsonResult = new JsonResult()
            {
                Data = new {object_ = new object[0]},
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            List<CompanyViewModel> data = LoadData(Filter);
            JsonResult.Data = new List<object>();

            if (data!= null && data.Count > 0)
            {
                foreach (var item in data)
                {
                    string DataToShow = item.NomeDittaa;
                    int Id = item.IdDitta;

                   ((List<object>)JsonResult.Data).Add(new { @datatoshow = DataToShow, @valueId = Id, @optional = -1 });
                    //((List<object>)JsonResult.Data).
                    //    Add( new
                    //    {
                    //        @datatoshow= DataToShow,
                    //        @valuedId= Id,
                    //        @optionalee= -1
                    //    }
                    //    );

                }
            }

            return JsonResult;
        }


    }
}