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

        public IQueryable<tPreventiveDetails> GetAllPreventives()
        { 
            return this.dbEntity.tPreventiveDetails.Take(10);
        }

        public tPreventiveDetails GetPreventiveFromId(int Id)
        {
            return this.dbEntity.tPreventiveDetails.FirstOrDefault(x => x.IdPreventivo == Id);
        }

        //Cambiare questo switch in base al reale nome della tabella nel database
        public void SavePreventive(tPreventiveDetails preventive, EnumUseful.typeOfDatabaseOperation typeOfDatabaseOperation)
        {
            
            switch (typeOfDatabaseOperation)
            {
                
                case EnumUseful.typeOfDatabaseOperation.EDIT:
                    tPreventiveDetails PreventiveToEdit = dbEntity.tPreventiveDetails.FirstOrDefault(
                        x => x.IdPreventivo == preventive.IdPreventivo
                        );

                    if(PreventiveToEdit!=null)
                    {
                        PreventiveToEdit.IdCliente = preventive.IdCliente;
                        PreventiveToEdit.NumeroPreventivo = preventive.NumeroPreventivo;
                        PreventiveToEdit.Riferimento = preventive.Riferimento;
                        PreventiveToEdit.Allegati = preventive.Allegati;
                        PreventiveToEdit.Oggetto = preventive.Oggetto;
                        PreventiveToEdit.Attenzione = preventive.Attenzione;
                        PreventiveToEdit.Durata = preventive.Durata;
                        PreventiveToEdit.Data_ = preventive.Data_;
                        PreventiveToEdit.Confermato = preventive.Confermato;
                        PreventiveToEdit.Operatore = preventive.Operatore;
                        PreventiveToEdit.AddebitoTransporto = preventive.AddebitoTransporto;
                        PreventiveToEdit.Sconto = preventive.Sconto;
                        PreventiveToEdit.Progetto = preventive.Progetto;
                        PreventiveToEdit.Variazione = preventive.Variazione;
                        PreventiveToEdit.Totale= preventive.Totale;
                        PreventiveToEdit.Pagamento = preventive.Pagamento;
                        PreventiveToEdit.Consegna = preventive.Consegna;
                        PreventiveToEdit.NotaApertura = preventive.NotaApertura;
                        PreventiveToEdit.NotaChiusura = preventive.NotaChiusura;
                        PreventiveToEdit.NoteAndamaneto = preventive.NoteAndamaneto;
                        PreventiveToEdit.DataInizioLavoro = preventive.DataInizioLavoro;
                        PreventiveToEdit.NumeroCommisione = preventive.NumeroCommisione;
                        PreventiveToEdit.Referenza = preventive.Referenza;
                        PreventiveToEdit.Listino = preventive.Listino;
                            
                    }
                    
                    break;
                case EnumUseful.typeOfDatabaseOperation.CREATE:
                    if (preventive!= null)
                    {
                        dbEntity.tPreventiveDetails.Add(preventive);
                    }
                    break;

            }

            dbEntity.SaveChanges();

        }

        public  void RemovePreventiveWithId(int id)
        {
            tPreventiveDetails PreventiveToDelete =
                dbEntity.
                tPreventiveDetails.
                FirstOrDefault(
                    ptd => ptd.IdPreventivo == id
                    );
            if (PreventiveToDelete != null)
            {
                dbEntity.tPreventiveDetails.Remove(PreventiveToDelete);
                dbEntity.SaveChangesAsync();

            }
        }

        public void Dispose()
        {
           
        }
    }

}
