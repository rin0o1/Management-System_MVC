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
    
    public partial class tListini
    {
        public int IdListino { get; set; }
        public string Codice { get; set; }
        public string Descrizione { get; set; }
        public string Prezzo { get; set; }
        public Nullable<int> IdDitta { get; set; }
    
        public virtual tDitte tDitte { get; set; }
    }
}