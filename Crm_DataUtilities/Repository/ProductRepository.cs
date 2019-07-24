using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crm_Entities;
using Crm_DataUtilities;
using Crm_Global;


namespace Crm_DataUtilities.Repository
{

    
    public class ProductRepository
    {
        private MyDataEntities dbEntity;

        public ProductRepository (MyDataEntities dbEntity=null)
        {
            this.dbEntity = dbEntity ?? new MyDataEntities();

        }



        public IQueryable<tProdoct> GetAllProducts()
        {
            return this.dbEntity.tProdoct;
        }

        public tProdoct GetProductFromId (int Id)
        {
            return this.dbEntity.tProdoct.FirstOrDefault(x=> x.IdProdotto==Id);
        }




    }
}
