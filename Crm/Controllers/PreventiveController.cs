using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
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
                    Value= 0,
                    TextToShow= "Annullato",

                },
                new FilterForDataVisualization()
                {
                    Value= 1,
                    TextToShow= "Aperto"
                },
                new FilterForDataVisualization()
                {
                    Value= 2,
                    TextToShow= "CHiuso"
                }
            };

            #endregion

            //ViewBag.filterForDataVisualization = FilterForDataVisualization;

            PageParameters _pageParameters = new PageParameters()
            {
                PageTitle = this.Title,
                ControllerName = ControllerName.OrderController,
                FilterForData = FilterForDataVisualization
            };


            ViewBag.pageParameters = _pageParameters;
            ViewBag.pageTitle = Title;

            var Data = this.LoadData();
            return View(Data);
        }

        public List<PreventiveViewModel> LoadData()
        {
            var AllPreventives= _preventiveRepository.GetAllPreventives();

            foreach (tPreventive item in AllPreventives.ToList())
            {
                PreventiveViewModel p = new PreventiveViewModel();
            }

            return new List<PreventiveViewModel>()
            {
                new PreventiveViewModel(),
                new PreventiveViewModel(),
                new PreventiveViewModel()
            };
        }
    }
}