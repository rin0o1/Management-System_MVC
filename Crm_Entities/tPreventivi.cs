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
    
    public partial class tPreventivi
    {
        public int IdPreventivo { get; set; }
        public Nullable<double> IdCliente { get; set; }
        public Nullable<System.DateTime> Data { get; set; }
        public Nullable<double> IdOrdine { get; set; }
        public string NumeroPreventivo { get; set; }
        public string NumeroOrdine { get; set; }
        public string Riferimento { get; set; }
        public string Allegati { get; set; }
        public string Oggetto { get; set; }
        public string Attenzione { get; set; }
        public string Durata { get; set; }
        public bool Confermato { get; set; }
        public string Operatore { get; set; }
        public string AddebitoTrasporto { get; set; }
        public Nullable<decimal> Totale { get; set; }
        public string Variazione { get; set; }
        public Nullable<decimal> Importo { get; set; }
        public string Pagamento { get; set; }
        public string Consegna { get; set; }
        public string NotaApertura { get; set; }
        public string NotaChiusura { get; set; }
        public Nullable<double> Sconto { get; set; }
        public string Progetto { get; set; }
        public string DataInizioLavori { get; set; }
        public string NoteAndamento { get; set; }
        public string NumeroCommissione { get; set; }
        public string Referenza { get; set; }
        public string Listino { get; set; }
    }
}
