using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

using Crm_DataUtilities;
using Crm_Entities;
using Crm_Global;

namespace Crm_DataUtilities.Repository
{
    public class StageRepository
    {
        private MyDataEntities dbEntity;
        public StageRepository(MyDataEntities dbEntity) {
            this.dbEntity = dbEntity ?? new MyDataEntities();                       
        }

        public IEnumerable <tStage> getAllStages()
        {
            return this.dbEntity.tStage.Where(x=> x.IsProducing==true);
        }

        public tStage getStageFromId(int id) {
            return null;
        }
        

    }
}
