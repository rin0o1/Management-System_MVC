using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Crm_DataUtilities.ViewModel;

namespace Crm.Controllers
{
    public class HomeController : Controller
    {
        private string Title = "Home";
        public ActionResult Index()
        {

            PageParameters _pageParameters = new PageParameters();
            _pageParameters.PageTitle = this.Title;
            _pageParameters.HasMenu = false;

            ViewBag.pageParameters = _pageParameters;
            ViewBag.pageTitle = Title;


            return View();
        }



    }
}