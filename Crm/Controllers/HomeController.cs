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

        [HttpPost]
        public JsonResult ReloadData()
        {
            var AllStage = _StageRepository.getAllStages();
            Random r = new Random();
            List<ProductionSituationValueUpdateViewModel> data = new List<ProductionSituationValueUpdateViewModel>();

            foreach (tStage item in AllStage.ToList())
            {

                ProductionSituationValueUpdateViewModel p = new ProductionSituationValueUpdateViewModel(item);
                p.badProductValue = r.Next(Convert.ToInt32(item.NumberBadProductValue),100);
                p.niceProductValue = r.Next(Convert.ToInt32(item.NumberNiceProductValue), 100);
                p.totalProduction = p.badProductValue + p.niceProductValue;
                data.Add(p);
            }

            JsonResult JsonResult = new JsonResult()
            {
                Data = new { object_ = new object[0] },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };

            JsonResult.Data = new List<object>();

            if (data != null && data.Count > 0)
            {
                foreach (var item in data)
                {
                    ProductionSituationValueUpdateViewModel DataToShow = item;
                    //string Optional = item.Email;
                    string Optional = "";
                    int Id = item.idStaege;

                    ((List<object>)JsonResult.Data).Add(new { @datatoshow = DataToShow, @valueId = Id, @optional = Optional });
                }
            }
            return JsonResult;
            
        }

    }
}