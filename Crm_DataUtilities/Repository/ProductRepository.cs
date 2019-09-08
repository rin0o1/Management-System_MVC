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



        public IQueryable<tListini> GetAllProducts()
        {
            return this.dbEntity.tListini;
        }

        public tListini GetProductFromId (int Id)
        {
            return this.dbEntity.tListini.FirstOrDefault(x=> x.IdListino==Id);
        }

        public void SaveProduct (tListini prodoct,EnumUseful.typeOfDatabaseOperation typeOfDatabaseOperation)
        {
            switch (typeOfDatabaseOperation)
            {
                case EnumUseful.typeOfDatabaseOperation.EDIT:
                    tListini prodoct_ = dbEntity.tListini.FirstOrDefault(x=> x.IdListino== prodoct.IdListino);
                    if (prodoct_!= null)
                    {
                        prodoct_.IdListino = prodoct.IdListino;
                        prodoct_.Codice = prodoct.Codice;
                        prodoct_.Descrizione = prodoct.Descrizione;
                        prodoct_.Prezzo = prodoct.Prezzo;
                        prodoct_.IdDitta = prodoct.IdDitta;

                    }

                    break;
                case EnumUseful.typeOfDatabaseOperation.CREATE:
                    if (prodoct!=null)
                    {
                        dbEntity.tListini.Add(prodoct);
                    }
                    break;
                case EnumUseful.typeOfDatabaseOperation.SAVE:
                    break;
                default:
                    break;
            }

            dbEntity.SaveChanges();
        }

        public void RemovePreventiveWithId(int id)
        {
            tListini prodoct =
                dbEntity.
                tListini.
                FirstOrDefault(x=> x.IdListino==id);

            if (prodoct!= null)
            {
                dbEntity.tListini.Remove(prodoct);
                dbEntity.SaveChangesAsync();
            }
        }

        public void Dispose()
        { }

    }
}
