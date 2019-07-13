//------------------------------------------------------------------------------
// <auto-generated>
//     Codice generato da un modello.
//
//     Le modifiche manuali a questo file potrebbero causare un comportamento imprevisto dell'applicazione.
//     Se il codice viene rigenerato, le modifiche manuali al file verranno sovrascritte.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Crm_Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class tPreventiveDetails
    {
        public int IdPreventivo { get; set; }
        public Nullable<int> IdCliente { get; set; }
        public string NumeroPreventivo { get; set; }
        public string NumeroOrdine { get; set; }
        public string Riferimento { get; set; }
        public string Allegati { get; set; }
        public string Oggetto { get; set; }
        public string Attenzione { get; set; }
        public Nullable<System.DateTime> Data_ { get; set; }
        public Nullable<int> Durata { get; set; }
        public Nullable<bool> Confermato { get; set; }
        public string Operatore { get; set; }
        public string AddebitoTransporto { get; set; }
        public Nullable<double> Totale { get; set; }
        public Nullable<double> Variazione { get; set; }
        public Nullable<double> Importo { get; set; }
        public string Pagamento { get; set; }
        public string Consegna { get; set; }
        public string NotaApertura { get; set; }
        public string NotaChiusura { get; set; }
        public Nullable<double> Sconto { get; set; }
        public string Progetto { get; set; }
        public Nullable<System.DateTime> DataInizioLavoro { get; set; }
        public string NoteAndamaneto { get; set; }
        public Nullable<int> NumeroCommisione { get; set; }
        public string Cartella { get; set; }
        public string Referenza { get; set; }
        public Nullable<double> Listino { get; set; }
        public string s_GUID { get; set; }
    
        public virtual tCliente tCliente { get; set; }
    }
}