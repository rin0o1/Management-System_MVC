using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using Crm_Entities;
using Crm_Global;

namespace Crm_DataUtilities.ViewModel
{
    public class CustomerViewModel
    {

        public CustomerViewModel(tCliente c)
        {
            IdCliente = c.Id;
            Nome = c.RagioneSociale;
            CittaDitta = c.Citta;
            CodiceUniclima = c.CodiceUniclima;
            Email = c.IndirizzoEmail;

        }
            

        public int IdCliente { get; set; }

        //potrebbe contenere il nome del titolare
        [Display(Name ="Nome")]
        public string Nome { get; set; }
                
        [Display(Name ="Codice Uniclima")]
        public string CodiceUniclima { get; set; }
        
        [Display(Name ="Citta Ditta")]
        public string CittaDitta { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

    }


    public class CustomerDetailsViewModel
    {
        public CustomerDetailsViewModel(tCliente c)
        {
            this.Id = c.Id;
            this.RagioneSociale = c.RagioneSociale;
            this.CodiceUniclima = c.CodiceUniclima;
            this.Indirizzo = c.Indirizzo;
            this.CAP = c.CAP ?? 0;
            this.Citta = c.Citta;
            this.Provincia = c.Provincia;            
        }

        public int Id { get; set; }
        public string RagioneSociale { get; set; }
        public string CodiceUniclima { get; set; }
        public string Indirizzo { get; set; }
        public int CAP { get; set; }
        public string Citta { get; set; }
        public string Provincia { get; set; }

    }
}
