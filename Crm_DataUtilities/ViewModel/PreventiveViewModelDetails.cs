using Crm_Entities;
using System;
using System.ComponentModel.DataAnnotations;


namespace Crm_DataUtilities.ViewModel
{

    public class PreventiveViewModel
    {
        public PreventiveViewModel() { }
        public PreventiveViewModel(tPreventivi preventive)
        {
            this.IdPreventivo = preventive.IdPreventivo;
            this.NumeroPreventivo = preventive.NumeroPreventivo;
            if (preventive.Data.HasValue)
            {
                this.Data = preventive.Data.Value.ToShortDateString();
            }
            else
            {
                this.Data = null;
            }


            this.Riferimento = preventive.Riferimento;
            this.Listino = preventive.Listino;
        }


        public int IdPreventivo { get; set; }

        [Display(Name = "NUMERO PREVENTIVO")]
        public string NumeroPreventivo { get; set; }

        [Display(Name = "DATA")]
        public string Data { get; set; }

        [Display(Name = "RIFERIMENTO")]
        public string Riferimento { get; set; }

        [Display(Name = "LISTINO")]
        public string Listino { get; set; }


    }

    public class PreventiveDetailsViewModel
    {
        public PreventiveDetailsViewModel() { }
        public PreventiveDetailsViewModel(tPreventivi p)
        {
            this.IdPreventivo = p.IdPreventivo;
            this.NumeroPreventivo = p.NumeroPreventivo;
            
            if (p.Data.HasValue)
            {                
                this.Data = p.Data.Value.Date;
            }
            else
            {
                this.Data = null;
            }
            
            this.Durata = p.Durata;
            this.Oggetto = p.Oggetto;
            this.Allegati = p.Allegati;
            this.Riferimento = p.Riferimento;
            this.Progetto = p.Progetto;
            //this.IdOperatore = 1;
            this.Operatore = p.Operatore;
            this.AddebitoTrasportato = p.AddebitoTrasporto;
            this.Pagamento = p.Pagamento;
            this.Consegna = p.Consegna;
            this.NotaApertura = p.NotaApertura;
            this.NotaChiusura = p.NotaChiusura;
            this.NumeroCommissione = p.NumeroCommissione;

            if (!String.IsNullOrEmpty(p.DataInizioLavori))
            {
                this.DataInizioLavori =p.DataInizioLavori;
            }
            else
            {
                this.DataInizioLavori = null;
            }
            this.Referenza = p.Referenza;
            this.NoteAndamento = p.NoteAndamento;
            this.TotaleArticoliListino = Convert.ToDouble(p.Totale);
            this.ImportoTotaleScontato = Convert.ToDouble( p.Variazione);
            this.ScontoGenerale = p.Sconto  ;
            this._IdCliente = Convert.ToInt32(p.IdCliente);
            this.Attenzione = p.Attenzione;
            this.ListinoInVigore = p.Listino ;
            //this._IdOrdine = 5;
        }

        public int          IdPreventivo          { get; set; }
        public string       NumeroPreventivo       { get; set; }
        public  DateTime?     Data                      { get; set; }
        public string      Durata                    { get; set; }
        public string       Oggetto                  { get; set; }
        public string       Riferimento               { get; set; }
        public string       Progetto              { get; set; }
        public string       AddebitoTrasportato { get; set; }
        public string       Pagamento         { get; set; }
        public string       Consegna              { get; set; }
        public string       NotaApertura                  { get; set; }
        public string       NotaChiusura                  { get; set; }
        public string       Cartella              { get; set; }
        public string     NumeroCommissione                 { get; set; }
        public string  DataInizioLavori          { get; set; }
        public string       Referenza                 { get; set; }
        public string       NoteAndamento             { get; set;}
        public double  ?     TotaleArticoliListino               { get; set; }
        public double     ?  ImportoTotaleScontato             { get; set; }
        public double    ?   ScontoGenerale             { get; set; }
        public int  ?      _IdCliente                { get; set; }
        public int          _IdOrdine                  { get; set; }
        public string ListinoInVigore { get; set; }
        public string Attenzione { get; set; }
        public string Allegati { get; set; }
        public int IdOperatore { get; set; }
        public string Operatore { get; set; }
    }
}
