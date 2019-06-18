using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Crm_Global;
using Crm_Entities;


namespace Crm_DataUtilities.ViewModel
{
    public class PreventiveDetailsViewModel
    {
        //public PreventiveDetailsViewModel(tPreventive tPreventive){}
        

        //Rimuovere questo costruttore di prova
        public PreventiveDetailsViewModel()
        {
            this.IdPreventivo = 1;
            this.NumeroPreventivo = "3";
            //this.Data       
            this.Durata = 10;
            this.Oggetto = "nessuno";
            this.Riferimento = "nessuno";
            this.Progetto = "nessuno";
            this.IdOperatore = 3;
            this.AddebitoTrasportato = "nessuno";
            this.Pagamento = "nessuno";
            this.Consegna = "nessuno";
            this.NotaApertura = "nessuno";
            this.NotaChiusura = "nessuno";
            this.Cartella = "nessuno";
            this.NumeroCommissione = "nessuno";
            //this.DataInizioLavori = ;
            this.Referenza = "nessuno";
            this.NoteAndamento = "nessuno";
            this.TotaleArticoliListino = 18;
            this.ImportoTotaleScontato = 15;
            this.ScontoGenerale = 10;
            this._IdCliente = 5;
            this._IdOrdine = 5;
            
        }

        public int          IdPreventivo          { get; set; }
        public string       NumeroPreventivo       { get; set; }
        public DateTime     Data                      { get; set; }
        public int          Durata                    { get; set; }
        public string       Oggetto                  { get; set; }
        public string       Riferimento               { get; set; }
        public string       Progetto              { get; set; }
        public string       AddebitoTrasportato { get; set; }
        public string       Pagamento         { get; set; }
        public string       Consegna              { get; set; }
        public string       NotaApertura                  { get; set; }
        public string       NotaChiusura                  { get; set; }
        public string       Cartella              { get; set; }
        public string       NumeroCommissione                 { get; set; }
        public DateTime     DataInizioLavori          { get; set; }
        public string       Referenza                 { get; set; }
        public string       NoteAndamento             { get; set;}
        public double       TotaleArticoliListino               { get; set; }
        public double       ImportoTotaleScontato             { get; set; }
        public double       ScontoGenerale             { get; set; }
        public int          _IdCliente                { get; set; }
        public int          _IdOrdine                  { get; set; }
        public int IdOperatore { get; set; }

        public string Operatore { get; set; }
    }
}
