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
using System.Threading.Tasks;
using System.Threading;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using System.Net.Mail;


using Crm_DataUtilities.Repository;
using Crm_DataUtilities.ViewModel;
using Crm_Global;
using Crm_Entities;


namespace Crm.Controllers
{
    public class CustomerAndListinoController : DefaultController
    {
        // GET: CustomerAndListino 
        public ActionResult Index()
        {
            Title = "Listino";

             _pageParameters = new PageParameters()
             {
                PageTitle = this.Title,
                ControllerName = ControllerName.CustomerAndListino,  
                FilterForData = null,
                HasMenu=false, HasGeneralFilter=false
            };


            SetParameters();
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> GetDataForEmail(SendDataListinoViewModel data)
        {

            if (data == null || data.IdCustomer<0) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


            string To = data.EmailCustomer;

            string Message = " \n Prezzo totale: " + data.Prodotto.ToString() + "/€" +
                              /* "€ .  Prodotto: " + data.Prodotto +*/ ". \n " + data.TestoAggiuntivo;
            string Subject = "INVIO LISTINO DEL PRODOTTO: "+ data.Prodotto;

            MailManager mm = new MailManager();

            //In questo modo la pagina non viene bloccato ma non ho la conferma
            //Thread a = new Thread(() =>mm.SendEmail(To, Message, Subject));
            //a.Start();

            //In questo modo ho la conferma ma la pagina viene bloccata
            if (await mm.SendEmailWithEmailAsync(To, Message, Subject))
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            
            
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
    }
}