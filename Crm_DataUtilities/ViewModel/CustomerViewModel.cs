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

        public CustomerViewModel(tClienti c)
        {
            IdCliente = c.IdCliente;
            Nome = c.RagioneSociale;
            CittaDitta = c.Citta;
            CodiceUniclima = c.CodiceUniklima;
        }
            

        public int IdCliente { get; set; }

        //potrebbe contenere il nome del titolare
        [Display(Name ="Nome")]
        public string Nome { get; set; }
                
        [Display(Name ="Codice Uniclima")]
        public string CodiceUniclima { get; set; }
        
        [Display(Name ="Citta Ditta")]
        public string CittaDitta { get; set; }

    }


    public class CustomerDetailsViewModel
    {
        public CustomerDetailsViewModel(tClienti c)
        {
            this.Id = c.IdCliente;
            this.RagioneSociale = c.RagioneSociale;
            this.CodiceUniclima = c.CodiceUniklima;
            this.Indirizzo = c.Indirizzo;
            this.CAP = c.CAP ?? 0;
            this.Citta = c.Citta;
            this.Provincia = c.Provincia;
        }

        public int Id { get; set; }
        public string RagioneSociale { get; set; }
        public string CodiceUniclima { get; set; }
        public string Indirizzo { get; set; }
        public double CAP { get; set; }
        public string Citta { get; set; }
        public string Provincia { get; set; }

    }
}
