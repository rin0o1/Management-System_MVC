using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;
using System.Web;
using System.Web.Mvc;


using Crm_DataUtilities.ViewModel;
using Crm_DataUtilities.Repository;

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
            List<FilterForDataVisualization> _filterForDataVisualization = new List<FilterForDataVisualization>()
            {
                new FilterForDataVisualization()
                {
                    Value= 0,
                    TextToShow= "Annullato"
                },
                new FilterForDataVisualization()
                {
                    Value= 1,
                    TextToShow= "Aperto"
                }
            };

            ViewBag.filterForDataVisualization = _filterForDataVisualization;

            PageParameters _pageParameters = new PageParameters();
            _pageParameters.PageTitle = this.Title;
            _pageParameters._filterfordata = _filterForDataVisualization;

            ViewBag.pageParameters = _pageParameters;
            ViewBag.pageTitle = Title;

            return View();
        }



    }
}