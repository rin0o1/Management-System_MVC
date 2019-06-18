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
    
    public class PreventiveController : DefaultController
    {
        private PreventiveRepository _preventiveRepository;
        private MyDataEntities dbEntity;
        

        protected override void Initialize(RequestContext requestContext)
        {
            Title = "Gestione preventivi";
            base.Initialize(requestContext);
            dbEntity = new MyDataEntities();
            //dbEntity.Database.Connection.Open();
            _preventiveRepository = new PreventiveRepository();
        }

        public ActionResult Index()
        {


            #region FILTER FOR DATA VISUALIZATION
             FilterForDataVisualization = new List<FilterForDataVisualization>()
            {
                new FilterForDataVisualization(),
                new FilterForDataVisualization()
                {
                    Value= 1,
                    TextToShow= "Aperto"
                },
                new FilterForDataVisualization()
                {
                    Value= 2,
                    TextToShow= "Chiuso"
                }
            };

            #endregion

            //ViewBag.filterForDataVisualization = FilterForDataVisualization;

             _pageParameters = new PageParameters()
            {
                PageTitle = this.Title,
                ControllerName = ControllerName.PreventiveController,
                FilterForData = FilterForDataVisualization,
                HasEditButton = false,
                HasExportButton = false,
                HasSaveButton=false,
                
            };

            SetParameters();
            
            var Data = this.LoadData();
            return View(Data);
        }

        public List<PreventiveViewModel> LoadData()
        {
            //var AllPreventives = _preventiveRepository.GetAllPreventives();

            //foreach (tPreventive item in AllPreventives.ToList())
            //{
            //    PreventiveViewModel p = new PreventiveViewModel();
            //}


            return new List<PreventiveViewModel>()
            {
                new PreventiveViewModel(),
                new PreventiveViewModel(),
                new PreventiveViewModel()
            };
        }


        //Get Details
        public ActionResult Details( int ? Id)
        {
            
            if (Id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PageParameters _pageParameters = new PageParameters()
            {
                PageTitle = "Dettaglio Preventivo",
                ControllerName = ControllerName.PreventiveController,
                HasScrollButton=false,
                HasEditButton=false,
                ButtonMenu= new List<ButtonMenuViewModel>()
                {
                    new ButtonMenuViewModel()
                    {
                        ButtonName="Genera",
                        ButtonValue= "genera"
                    }
                    //new ButtonMenuViewModel()
                    //{
                    //    ButtonName="Duplica",
                    //    ButtonValue= "duplica"
                    //},
                   
                }
            };

            ViewBag.pageParameters = _pageParameters;

            var model = new PreventiveDetailsViewModel();

            return View(model);
        }

        //Post Details --> Save edit //Creare una tabella con il savataggio
        [HttpPost]
        public ActionResult Details(PreventiveDetailsViewModel model)
        {
            if (model == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            tPreventive tPreventive = new tPreventive()
            {
                ID = model.IdPreventivo,
                Data = model.Data,
                Durata = model.Durata,
                ImportoTotaleScontato = model.ImportoTotaleScontato,
                ScontoGenerale = model.ScontoGenerale,
                TotalearticoliListino = model.TotaleArticoliListino
            };

            _preventiveRepository.SavePreventive(tPreventive, EnumUseful.typeOfDatabaseOperation.EDIT);

            return RedirectToAction("Index");

        }

        //Create Get
        public ActionResult Create()
        {
            PageParameters _pageParameters = new PageParameters()
            {
                PageTitle = "Nuovo Preventivo",
                ControllerName = ControllerName.PreventiveController,
                HasScrollButton = false,
                HasAddElementButton = false,
                HasEditButton = false,
                HasDeleteButton=false
                //ButtonMenu= new List<ButtonMenuViewModel>()
                //{
                //    new ButtonMenuViewModel()
                //    {
                //        ButtonName="Salva e vai al detta",
                //        ButtonValue="SaveAndGenerate"
                //    }
                //}


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
            tPreventive tPreventive = new tPreventive()
            {
                ID = model.IdPreventivo,
                Data = model.Data,
                Durata = model.Durata,
                ImportoTotaleScontato = model.ImportoTotaleScontato,
                ScontoGenerale = model.ScontoGenerale,
                TotalearticoliListino = model.TotaleArticoliListino
            };

            //_preventiveRepository.SavePreventive(tPreventive, EnumUseful.typeOfDatabaseOperation.CREATE);
            //int id = tPreventive.ID; ID del preventivo creato
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveElementWithId(int ? Id)
        {
            if(Id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //_preventiveRepository.RemovePreventiveWithId(Id ?? 0);

            return Json(new { redirectTo = Url.Action("Index", ControllerName.PreventiveController) });
        }

        
        public JsonResult GetDataToAsyncForDialog()
        {
            JsonResult JsonResult = new JsonResult()
            {
                Data= new {object_ = new object[0]},
                JsonRequestBehavior= JsonRequestBehavior.AllowGet
            };

            //Prendo i dati richiesti
            List<TestToRemoveViewModel> data = new List<TestToRemoveViewModel>
            {
                new TestToRemoveViewModel(),
                new TestToRemoveViewModel(),
                new TestToRemoveViewModel(),
                new TestToRemoveViewModel()
            };

            JsonResult.Data = new List<object>();

            if(data!=null && data.Count> 0)
            {
                foreach (var item in data)
                {
                    string DataToShow = item.Nome + " " + item.Cognome;
                    int Id = item.Id;

                    ((List<object>)JsonResult.Data).Add(new { @datatoshow =DataToShow , @valueId = Id , @optional=-1});
                }
            }
            return JsonResult;
        }


    }
}