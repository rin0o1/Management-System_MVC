//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Crm_Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class tDitte
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tDitte()
        {
            this.tProdoct = new HashSet<tProdoct>();
        }
    
        public int IdDitta { get; set; }
        public string NomeDitta { get; set; }
        public string RagioneSocialeDitta { get; set; }
        public string IndirizzoDitta { get; set; }
        public string CapDitta { get; set; }
        public string CittaDitta { get; set; }
        public string ProvinciaDitta { get; set; }
        public string TelefonoDitta { get; set; }
        public string FaxDitta { get; set; }
        public string UrlDitta { get; set; }
        public string EmailDitta { get; set; }
        public string P_IvaDitta { get; set; }
        public string CodiceAgente { get; set; }
        public string Listino { get; set; }
        public string Logo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tProdoct> tProdoct { get; set; }
    }
}