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

        public IQueryable<tClienti> GetAllCustomers()
        {
            return this.dbEntity.tClienti;
        }

        public tClienti GetCustomerFromId(int Id)
        {
            return this.dbEntity.tClienti.FirstOrDefault(x => x.IdCliente == Id);
        }

        public void SaveCustomer(tClienti cliente, EnumUseful.typeOfDatabaseOperation typeOfDatabaseOperation)
        {
            switch(typeOfDatabaseOperation)
            {
                case EnumUseful.typeOfDatabaseOperation.EDIT:
                    tClienti CustomerToEdit = dbEntity.tClienti.FirstOrDefault(x => x.IdCliente == cliente.IdCliente);
                    if (CustomerToEdit!= null)
                    {
                        CustomerToEdit.RagioneSociale = cliente.RagioneSociale;
                        CustomerToEdit.CodiceUniklima = cliente.CodiceUniklima;
                        CustomerToEdit.Indirizzo = cliente.Indirizzo;
                        CustomerToEdit.CAP = cliente.CAP;
                        CustomerToEdit.Citta = cliente.Citta;
                        CustomerToEdit.Provincia = cliente.Provincia;
                    }

                    break;
                case EnumUseful.typeOfDatabaseOperation.CREATE:

                    if (cliente!= null)
                    {
                        dbEntity.tClienti.Add(cliente);
                    }

                    break;                

            }

            try
            {
                dbEntity.SaveChanges();
            }
            catch (Exception ee)
            {
                Console.WriteLine(ee.Message);
               
            }
            

        }


        public void RemoveCustomerWithId(int Id)
        {
            tClienti Element = this.dbEntity.tClienti.FirstOrDefault(x => x.IdCliente == Id);

            if (Element != null)
            {
                dbEntity.tClienti.Remove(Element);
                dbEntity.SaveChangesAsync();

            }
            
        }

        public void Dispose()
        {

        }

    }
}
