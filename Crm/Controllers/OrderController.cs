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
    public class OrderController : DefaultController
    {
        

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
            Title = " Gestione Ordini ";
            //Utility per poter aggiunere dinamicamente i filtri per ogni pagina
            #region FILTER FOR DATA VISUALIZATION
             FilterForDataVisualization = new List<FilterForDataVisualization>()
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
            

             _pageParameters = new PageParameters()
            {
                PageTitle = this.Title,
                FilterForData = FilterForDataVisualization,
                ControllerName = ControllerName.OrderController
            };

            SetParameters();

            return View();
        }

    }
}