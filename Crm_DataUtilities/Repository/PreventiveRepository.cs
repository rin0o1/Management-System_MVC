using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

using Crm_Entities;
using Crm_DataUtilities;
using Crm_Global;

namespace Crm_DataUtilities.Repository
{
    public class PreventiveRepository : IDisposable
    {
        private MyDataEntities dbEntity;
        public PreventiveRepository(MyDataEntities dbEntity=null)
        {
            this.dbEntity = dbEntity ?? new MyDataEntities();
        }

        public IQueryable<tPreventive> GetAllPreventives()
        {
            return this.dbEntity.tPreventive;
        }

        public void Dispose()
        {
           
        }
    }
}
