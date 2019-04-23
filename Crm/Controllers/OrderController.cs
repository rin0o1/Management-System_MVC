using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using System.Web;
using System.Web.Mvc;


using Crm_DataUtilities.ViewModel;
using Crm_DataUtilities.Repository;
using Crm_Global;

namespace Crm.Controllers
{
    public class OrderController : Controller
    {
        private string Title = " Gestione Ordini ";

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            //if (User.Identity.IsAuthenticated)
            //{
            //}
        }

        // GET: Order
        public ActionResult Index()
        {
            //Utility per poter aggiunere dinamicamente i filtri per ogni pagina
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


            ViewBag.filterForDataVisualization = FilterForDataVisualization;

            PageParameters _pageParameters = new PageParameters()
            {
                PageTitle = this.Title,
                FilterForData = FilterForDataVisualization,
                ControllerName = ControllerName.OrderController
            };
            
            ViewBag.pageParameters = _pageParameters;
            ViewBag.pageTitle = Title;

            return View();
        }

    }
}