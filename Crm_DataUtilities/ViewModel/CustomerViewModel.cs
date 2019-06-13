using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Crm_DataUtilities.ViewModel
{
    public class CustomerViewModel
    {

        public CustomerViewModel()
        {
            IdCliente = 1;
            Nome = "Paolo";
            Email = "frarino1002@gmail.com";
            ContattoDiRiferimento = "3421996964";
            Classe = 4;
            IdDitta = 6;
            Ditta = "Microelettronics";
            CittaDitta = "Senigallia";
        }

        public int IdCliente { get; set; }

        //potrebbe contenere il nome del titolare
        [Display(Name ="Nome")]
        public string Nome { get; set; }

        [Display(Name ="E-mail")]
        public string Email { get; set; }

        [Display(Name = "Contatto")]
        public string ContattoDiRiferimento { get; set; }
        
        [Display(Name ="Classe")]
        public int Classe { get; set; }

        public int IdDitta { get; set; }

        [Display (Name ="Ditta")]
        public string Ditta { get; set; }

        [Display(Name ="Citta Ditta")]
        public string CittaDitta { get; set; }

    }
}
