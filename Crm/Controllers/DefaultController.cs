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
    public class DefaultController : Controller
    {
        public string Title;
        public PageParameters _pageParameters;
        public List<FilterForDataVisualization> FilterForDataVisualization;


        public DefaultController()
        {
            
        }

        public virtual void SetParameters()
        {
            ViewBag.pageParameters = _pageParameters;
            ViewBag.pageTitle = Title;
            ViewBag.filterForDataVisualization = FilterForDataVisualization;
        }

    }

    
}