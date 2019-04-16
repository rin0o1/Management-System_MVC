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

namespace Crm.Controllers
{
    public class PreventiveController : Controller
    {
        private PreventiveRepository _preventiveRepository;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            _preventiveRepository = new PreventiveRepository();
        }


        public ActionResult Index()
        {
            return View();
        }
    }
}