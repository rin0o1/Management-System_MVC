﻿using System;
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
    
    public class PreventiveController : Controller
    {
        private PreventiveRepository _preventiveRepository;
        private MyDataEntities dbEntity;
        private string Title = "Gestione preventivi";

        protected override void Initialize(RequestContext requestContext)
        {   
            base.Initialize(requestContext);
            dbEntity = new MyDataEntities();
            dbEntity.Database.Connection.Open();
            _preventiveRepository = new PreventiveRepository();
        }

        public ActionResult Index()
        {


            #region FILTER FOR DATA VISUALIZATION
            List<FilterForDataVisualization> FilterForDataVisualization = new List<FilterForDataVisualization>()
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

            PageParameters _pageParameters = new PageParameters()
            {
                PageTitle = this.Title,
                ControllerName = ControllerName.PreventiveController,
                FilterForData = FilterForDataVisualization,
                HasEditButton = false,
                HasExportButton = false,
                HasDeleteButton = false,
                HasSaveButton=false,
                
                
            };
    

            ViewBag.pageParameters = _pageParameters;
            ViewBag.pageTitle = Title;

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
                HasDeleteButton=false,
                ButtonMenu= new List<ButtonMenuViewModel>()
                {
                    new ButtonMenuViewModel()
                    {
                        ButtonName="Genera",
                        ButtonValue= "genera"
                    },
                    new ButtonMenuViewModel()
                    {
                        ButtonName="Duplica",
                        ButtonValue= "duplica"
                    },
                   
                }
            };

            ViewBag.pageParameters = _pageParameters;

            var model = new PreventiveDetailsViewModel();

            return View(model);
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
                HasDeleteButton=false,
                ButtonMenu= new List<ButtonMenuViewModel>()
                {
                    new ButtonMenuViewModel()
                    {
                        ButtonName="Salva e genera",
                        ButtonValue="SaveAndGenerate"
                    }
                }


            };


            ViewBag.pageParameters = _pageParameters;

            return View();
        }

        //Create Post
        [HttpPost]
        public ActionResult Create(PreventiveDetailsViewModel model)
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

            //_preventiveRepository.SavePreventive(tPreventive, EnumUseful.typeOfDatabaseOperation.CREATE);


            //Redirect alla Index 
            return Json(new
            {
                redirect = "Index"
            });
        }


        //Non credo sia necessario
        public ActionResult SaveData()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult SaveDetailsData(PreventiveDetailsViewModel model)
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

            _preventiveRepository.SavePreventive(tPreventive, EnumUseful.typeOfDatabaseOperation.SAVE);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        
        [HttpPost]
        public ActionResult RemoveElementWithId(int ? Id)
        {
            if(Id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

             //_preventiveRepository.RemovePreventiveWithId(Id ?? 0);

            return new HttpStatusCodeResult(HttpStatusCode.OK);
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

                    ((List<object>)JsonResult.Data).Add(new { @datatoshow =DataToShow , @valueId = Id });
                }
            }
            return JsonResult;
        }


    }
}