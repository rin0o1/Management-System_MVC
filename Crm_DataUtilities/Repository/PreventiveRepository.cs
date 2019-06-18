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

        //Cambiare questo switch in base al reale nome della tabella nel database
        public void SavePreventive(tPreventive preventive, EnumUseful.typeOfDatabaseOperation typeOfDatabaseOperation)
        {
            
            switch (typeOfDatabaseOperation)
            {
                
                case EnumUseful.typeOfDatabaseOperation.EDIT:
                   tPreventive PreventiveToEdit = dbEntity.tPreventive.FirstOrDefault(
                        x => x.ID == preventive.ID
                        );

                    if(PreventiveToEdit!=null)
                    {
                        //Per tutti i campi
                        PreventiveToEdit.Durata = preventive.Durata;
                        PreventiveToEdit.Data = preventive.Data;
                        PreventiveToEdit.ScontoGenerale = preventive.ScontoGenerale;
                        PreventiveToEdit.ImportoTotaleScontato = preventive.ImportoTotaleScontato;
                        PreventiveToEdit.TotalearticoliListino = preventive.TotalearticoliListino;
                        
                    }
                    
                    break;
                case EnumUseful.typeOfDatabaseOperation.CREATE:
                    if (preventive!= null)
                    {
                        dbEntity.tPreventive.Add(preventive);
                    }
                    break;

            }

            dbEntity.SaveChanges();

        }

        public  void RemovePreventiveWithId(int id)
        {
            tPreventive PreventiveToDelete =
                dbEntity.
                tPreventive.
                FirstOrDefault(
                    ptd => ptd.ID == id
                    );
            if (PreventiveToDelete != null)
            {
                dbEntity.tPreventive.Remove(PreventiveToDelete);
                dbEntity.SaveChangesAsync();

            }
        }

        public void Dispose()
        {
           
        }
    }

}
