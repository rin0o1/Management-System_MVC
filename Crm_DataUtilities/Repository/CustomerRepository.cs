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

        public void SaveCustomer(tCliente cliente, EnumUseful.typeOfDatabaseOperation typeOfDatabaseOperation)
        {
            switch(typeOfDatabaseOperation)
            {
                case EnumUseful.typeOfDatabaseOperation.EDIT:
                    tCliente CustomerToEdit = dbEntity.tCliente.FirstOrDefault(x => x.Id == cliente.Id);
                    if (CustomerToEdit!= null)
                    {
                        CustomerToEdit.RagioneSociale = cliente.RagioneSociale;
                        CustomerToEdit.CodiceUniclima = cliente.CodiceUniclima;
                        CustomerToEdit.Indirizzo = cliente.Indirizzo;
                        CustomerToEdit.CAP = cliente.CAP;
                        CustomerToEdit.Citta = cliente.Citta;
                        CustomerToEdit.Provincia = cliente.Provincia;
                    }

                    break;
                case EnumUseful.typeOfDatabaseOperation.CREATE:

                    if (cliente!= null)
                    {
                        dbEntity.tCliente.Add(cliente);
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
            tCliente Element = this.dbEntity.tCliente.FirstOrDefault(x => x.Id == Id);

            if (Element != null)
            {
                dbEntity.tCliente.Remove(Element);
                dbEntity.SaveChangesAsync();

            }
            
        }

        public void Dispose()
        {

        }

    }
}
