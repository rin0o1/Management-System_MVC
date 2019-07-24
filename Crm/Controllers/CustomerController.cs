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

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            dbEntity = new MyDataEntities();
            dbEntity.Database.Connection.Open();
            _CustomerRepository = new CustomerRepository(dbEntity);
        }

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
	
		
	        if (!String.IsNullOrEmpty(filter)) 
	        {
		        AllCustomer= AllCustomer.Where(x=> x.CodiceUniclima.ToUpper().StartsWith(filter.ToUpper()));
	        }

		    foreach(var x in AllCustomer.ToList())
		    {	
			    CustomerViewModel c= new CustomerViewModel(x);
			    list.Add(c);
		    }		


            return list;
        }

        //Details Get
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

            var Customer= _CustomerRepository.GetCustomerFromId(Id.Value);

            var model = new CustomerDetailsViewModel(Customer);

            return View(model);
        }

        //Details Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(CustomerDetailsViewModel model)
        {
            if (model == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            tCliente client = new tCliente()
            {
                Id= model.Id,
                RagioneSociale = model.RagioneSociale,
                CodiceUniclima = model.CodiceUniclima,
                Categoria = model.Categoria,
                Classe = model.Classe,
                Indirizzo = model.Indirizzo,
                CAP = model.CAP,
                Citta = model.Citta,
                Provincia = model.Provincia,
                P_Iva = model.P_Iva,
                Banca = model.Banca,
                CIN = model.CIN,
                ABI = model.ABI,
                CAB = model.CAB,
                ContoCorrente = model.ContoCorrente,
                IBAN = model.IBAN,
                TelefonoUfficio = model.TelefonoUfficio,
                Telefax = model.Telefax,
                Conttato1 = model.Contatto1,
                Cellulare1= model.Cellulare1,
                Referente1 = model.Referente1,
                Referente2 = model.Referente2,
                Note1 = model.Note1,
                Fornitori = model.Fornitori,
                Titolari = model.Titolari,
                Soci = model.Soci,
                Segretari = model.Segretari,
                Amministrativi = model.Amministrativi,
                UfficioTecnico = model.UfficioTecnico,
                IndirizzoEmail = model.Email,
                SitoInternet = model.IndirizzoInternet,
                ConsensoDati = model.ConsensoDati,
                Data_ = model.Data,
                FatturatoGlobale = model.FatturatoGloable,
            };

            _CustomerRepository.SaveCustomer(client, EnumUseful.typeOfDatabaseOperation.EDIT);

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
                HasDeleteButton = false,
                HasGeneralFilter=false
            };


            ViewBag.pageParameters = _pageParameters;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerDetailsViewModel model)
        {

            if (model == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            tCliente client = new tCliente()
            {
                 RagioneSociale = model.RagioneSociale, 
                 CodiceUniclima = model.CodiceUniclima,
                 Categoria = model.Categoria,
                 Classe = model.Classe,
                 Indirizzo = model.Indirizzo,
                 CAP = model.CAP,
                 Citta = model.Citta,
                 Provincia = model.Provincia,
                 P_Iva = model.P_Iva,
                 Banca = model.Banca,
                 CIN = model.CIN,
                 ABI = model.ABI,
                 CAB = model.CAB,
                 ContoCorrente = model.ContoCorrente,
                 IBAN = model.IBAN,
                 TelefonoUfficio = model.TelefonoUfficio,
                 Telefax = model.Telefax,
                 Conttato1 = model.Contatto1,                
                 Referente1 = model.Referente1,
                 Referente2 = model.Referente2,
                 Note1 = model.Note1,                 
                 Fornitori = model.Fornitori,
                 Titolari = model.Titolari,
                 Soci = model.Soci,
                 Segretari = model.Segretari,
                 Amministrativi = model.Amministrativi,
                 UfficioTecnico = model.UfficioTecnico,
                 IndirizzoEmail = model.Email,
                 SitoInternet = model.IndirizzoInternet,
                 ConsensoDati = model.ConsensoDati,
                 Data_ = model.Data,
                 FatturatoGlobale = model.FatturatoGloable,
            };

            _CustomerRepository.SaveCustomer(client, EnumUseful.typeOfDatabaseOperation.CREATE);

            return RedirectToAction("Index");
        }



        [HttpPost]
        public ActionResult RemoveElementWithId(int? Id)
        {
            if (Id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            _CustomerRepository.RemoveCustomerWithId(Id ?? 0);

            return Json(new { redirectTo = Url.Action("Index", ControllerName.CustomerController) });
        }

        [HttpPost]
        public ActionResult GetDataAsync(string filter)
        {

            List<CustomerViewModel> data = LoadData(filter);

            JsonModel Model = new JsonModel();
            Model.HTMLString = renderPartialViewtostring("PartialInformationContainer", data);
            
            return Json(Model);
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

                        ((List<object>)JsonResult.Data).Add(new { @datatoshow = DataToShow , @valueId = Id, @optional = Optional });
                    
                }
            }
            return JsonResult;
        }

    }
}