using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Crm_DataUtilities.Repository;
using Crm_DataUtilities.ViewModel;
using Crm_Entities;
using Crm_Global;

namespace Crm.Controllers
{
    public class HomeController : DefaultController
    {
        
        private StageRepository _StageRepository;
        private MyDataEntities dbEntity;


        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            dbEntity = new MyDataEntities();
            dbEntity.Database.Connection.Open();
            _StageRepository = new StageRepository(dbEntity);
        }
        
        public ActionResult Index()
        {
            Title = "Ferri Marelli Produzione";

            _pageParameters = new PageParameters()
            {
                PageTitle = this.Title,
                ControllerName = ControllerName.HomeController,
                FilterForData = null,
                HasGeneralFilter = false,
                HasMenu = false
            };

            SetParameters();

            var Data = this.LoadData();

            return View(Data);
        }

        public List<ProductionSituationModel> LoadData(string filter = null)
        {
            var AllStage = _StageRepository.getAllStages();

            List<ProductionSituationModel> list = new List<ProductionSituationModel>();

            foreach (var item in AllStage.ToList())
            {
                list.Add(new ProductionSituationModel(item));
            }

            return list;
            
        }



    }
}