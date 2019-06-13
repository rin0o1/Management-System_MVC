using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using Crm_DataUtilities.Repository;
using Crm_DataUtilities.ViewModel;
using Crm_Global;
using Crm_Entities;

namespace Crm.Controllers
{
    public class CustomerController : DefaultController
    {
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

            var Data = this.LoadData();

            return View(Data);
        }

        public List<CustomerViewModel>  LoadData()
        {
            return new List<CustomerViewModel>() 
            {
                new CustomerViewModel(),
                new CustomerViewModel(),
                new CustomerViewModel()
            };
        }

        public JsonResult GetDataToAsyncForDialog()
        {
            JsonResult JsonResult = new JsonResult()
            {
                Data = new { object_ = new object[0] },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            //Prendo i dati richiesti
            List<CustomerViewModel> data = LoadData();
            

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