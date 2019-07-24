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
                        CustomerToEdit.Categoria = cliente.Categoria;
                        CustomerToEdit.Cellulare1 = cliente.Cellulare1;
                        CustomerToEdit.Classe = cliente.Classe;
                        CustomerToEdit.Indirizzo = cliente.Indirizzo;
                        CustomerToEdit.CAP = cliente.CAP;
                        CustomerToEdit.Citta = cliente.Citta;
                        CustomerToEdit.Provincia = cliente.Provincia;
                        CustomerToEdit.P_Iva = cliente.P_Iva;
                        CustomerToEdit.Banca = cliente.Banca;
                        CustomerToEdit.CIN = cliente.CIN;
                        CustomerToEdit.ABI = cliente.ABI;
                        CustomerToEdit.CAB = cliente.CAB;
                        CustomerToEdit.ContoCorrente = cliente.ContoCorrente;
                        CustomerToEdit.IBAN = cliente.IBAN;
                        CustomerToEdit.TelefonoUfficio = cliente.TelefonoUfficio;
                        CustomerToEdit.Telefax = cliente.Telefax;
                        CustomerToEdit.Conttato1 = cliente.Conttato1;
                        CustomerToEdit.Conttato2 = cliente.Conttato2;
                        CustomerToEdit.Contatto3 = cliente.Contatto3;
                        CustomerToEdit.Cellulare3 = cliente.Cellulare3;
                        CustomerToEdit.Referente1 = cliente.Referente1;
                        CustomerToEdit.Referente2 = cliente.Referente2;
                        CustomerToEdit.Note1 = cliente.Note1;
                        CustomerToEdit.Note2 = cliente.Note2;
                        CustomerToEdit.Note3 = cliente.Note3;
                        CustomerToEdit.Note4 = cliente.Note4;
                        CustomerToEdit.Fornitori = cliente.Fornitori;
                        CustomerToEdit.Titolari = cliente.Titolari;
                        CustomerToEdit.Soci = cliente.Soci;
                        CustomerToEdit.Segretari = cliente.Segretari;
                        CustomerToEdit.Amministrativi = cliente.Amministrativi;
                        CustomerToEdit.UfficioTecnico = cliente.UfficioTecnico;
                        CustomerToEdit.IndirizzoEmail = cliente.IndirizzoEmail;
                        CustomerToEdit.SitoInternet = cliente.SitoInternet;
                        CustomerToEdit.ConsensoDati = cliente.ConsensoDati;
                        CustomerToEdit.Data_ = cliente.Data_;
                        CustomerToEdit.FatturatoGlobale = cliente.FatturatoGlobale;
                        CustomerToEdit.s_GUID = cliente.s_GUID;
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
