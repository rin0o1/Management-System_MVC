using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Crm_Entities;
using Crm_Global;
using Crm_DataUtilities;

namespace Crm_DataUtilities.Repository
{   
    public class CustomerRepository
    {
        private MyDataEntities dbEntity;

        public CustomerRepository  (MyDataEntities dbEntity=null)
        {
            this.dbEntity = dbEntity ?? new MyDataEntities();
        }

        public IQueryable<tCliente> GetAllCustomers()
        {
            return this.dbEntity.tCliente;
        }

        public tCliente GetCustomerFromId(int Id)
        {
            return this.dbEntity.tCliente.FirstOrDefault(x => x.Id == Id);
        }

    }
}
