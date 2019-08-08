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
            dbEntity.Database.Connection.Open();
            _preventiveRepository = new PreventiveRepository(dbEntity);
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
                 //FilterForData= null,
                 HasEditButton = false,
                HasExportButton = false,
                HasSaveButton=false,
                HasDeleteButton= false
             };

            SetParameters();
            
            var Data = this.LoadData(null);
            return View(Data);
        }


        public List<PreventiveViewModel> LoadData(string Filter)
        {

            var AllPreventives = _preventiveRepository.GetAllPreventives();

            
            //Filtro i preventivi per "NumeroPreventivo" se inizia o contiene 
            // le lettere inserite prendo quel preventivo
            if (!String.IsNullOrEmpty(Filter))
            {
                

                AllPreventives = AllPreventives.Where(
                x => x.NumeroPreventivo.ToUpper().StartsWith(Filter.ToUpper())
                //aggiungre  il filtro per tutti gli elementi della partialindex
                ); ;
                
               
            }

            List<PreventiveViewModel> list = new List<PreventiveViewModel>();

            foreach (tPreventiveDetails item in AllPreventives.ToList())
            {
                PreventiveViewModel p = new PreventiveViewModel(item);
                list.Add(p);
            }

            return list;
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
                HasGeneralFilter= false,
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

            var Preventivo = _preventiveRepository.GetPreventiveFromId(Id.Value);

            var model = new PreventiveDetailsViewModel(Preventivo);

            return View(model);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(PreventiveDetailsViewModel model)
        {
            if (model == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            tPreventiveDetails tPreventive = new tPreventiveDetails()
            {
                IdPreventivo= model.IdPreventivo,
                IdCliente = model._IdCliente,
                NumeroPreventivo = model.NumeroPreventivo,
                Riferimento = model.Riferimento,
                Allegati = model.Allegati,
                Oggetto = model.Oggetto,
                Attenzione = model.Attenzione,
                Durata = model.Durata,
                Data_ = model.Data,
                Cartella= model.Cartella,
                Operatore = model.Operatore,
                AddebitoTransporto = model.AddebitoTrasportato,
                Sconto = model.ScontoGenerale,
                Variazione = model.ImportoTotaleScontato,
                Totale = model.TotaleArticoliListino,
                Pagamento = model.Pagamento,
                Consegna = model.Consegna,
                NotaApertura = model.NotaApertura,
                NotaChiusura = model.NotaChiusura,
                NoteAndamaneto = model.NoteAndamento,
                DataInizioLavoro = model.DataInizioLavori,
                Referenza = model.Referenza,
                Listino = model.ListinoInVigore,
                Progetto = model.Progetto,
                Importo = model.ImportoTotaleScontato, //Non so la differenza tra total, importo e totale con sconto
                NumeroCommisione = model.NumeroCommissione,
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
                HasDeleteButton=false,
                HasGeneralFilter= false
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(PreventiveDetailsViewModel model)
        {

            if (model == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            //Redirect alla Index 
            tPreventiveDetails tPreventive = new tPreventiveDetails()
            {
                NumeroPreventivo = model.NumeroPreventivo,
                Riferimento = model.Riferimento,
                Allegati = model.Allegati,
                Oggetto = model.Oggetto,
                Attenzione = model.Attenzione,
                Durata = model.Durata,
                Data_ = model.Data,
                Cartella = model.Cartella,
                Operatore = model.Operatore,
                AddebitoTransporto = model.AddebitoTrasportato,
                Sconto = model.ScontoGenerale,
                Variazione = model.ImportoTotaleScontato,
                Totale = model.TotaleArticoliListino,
                Pagamento = model.Pagamento,
                Consegna = model.Consegna,
                NotaApertura = model.NotaApertura,
                NotaChiusura = model.NotaChiusura,
                NoteAndamaneto = model.NoteAndamento,
                DataInizioLavoro = model.DataInizioLavori,
                Referenza = model.Referenza,
                Listino = model.ListinoInVigore,
                Progetto= model.Progetto,
                Importo= model.ImportoTotaleScontato, //Non so la differenza tra total, importo e totale con sconto
                NumeroCommisione= model.NumeroCommissione,
                IdCliente= model._IdCliente
            };

            _preventiveRepository.SavePreventive(tPreventive, EnumUseful.typeOfDatabaseOperation.CREATE);
            int id = tPreventive.IdPreventivo;
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveElementWithId(int ? Id)
        {
            if(Id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            _preventiveRepository.RemovePreventiveWithId(Id.Value);

            return Json(new { redirectTo = Url.Action("Index", ControllerName.PreventiveController) });
        }



        [HttpPost]
        public ActionResult GetDataAsync(string filter)
        {

            List<PreventiveViewModel> data = LoadData(filter);

            JsonModel Model = new JsonModel();
            Model.HTMLString = renderPartialViewtostring("PartialInformationContainer", data);

            return Json(Model);
        }

        public JsonResult GetDataToAsyncForDialog(string Filter)
        {

            JsonResult JsonResult = new JsonResult()
            {
                Data= new {object_ = new object[0]},
                JsonRequestBehavior= JsonRequestBehavior.AllowGet
            };

           
            //Prendo i dati dei preventivi filtrati
            List<PreventiveViewModel> data = LoadData(Filter);

            JsonResult.Data = new List<object>();

            if(data!=null && data.Count> 0)
            {
                foreach (var item in data)
                {
                    string DataToShow = item.NumeroPreventivo + " " ;
                    int Id = item.IdPreventivo;

                    ((List<object>)JsonResult.Data).
                        Add(new
                        {
                            @datatoshow =DataToShow ,
                            @valueId = Id ,
                            @optional =-1
                        }
                        );
                }
            }
            return JsonResult;
        }


    }
}