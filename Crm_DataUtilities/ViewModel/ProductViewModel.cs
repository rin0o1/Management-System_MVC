using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using Crm_Entities;

namespace Crm_DataUtilities.ViewModel
{

    public class ProductViewModel
    {

        public ProductViewModel() { }
        public ProductViewModel(tListini p)
        {
            this.IdProdotto = p.IdListino;
            this.NomeProdotto = p.Codice;
            this.PrezzoPerUnita = Convert.ToDouble(p.Prezzo) ;
          
        }


        
        public int IdProdotto { get; set; }

        [Display(Name = "Categoria")]
        public string Categoria { get; set; }
        [Display(Name = "NomeProdotto")]
        public string NomeProdotto { get; set; }
        
        public string UM { get; set; }
        [Display(Name = "Prezzo")]
        public double PrezzoPerUnita { get; set; }


    }

    public class ProductDetailsViewModel
    {
        public ProductDetailsViewModel() { }
        public ProductDetailsViewModel (tListini p)
        {
            this.IdProdotto = p.IdListino;
       
            this.NomeFornitore = (p.tDitte != null) ? p.tDitte.NomeDitta : "-";
            //this.NomeFornitore = "Fornitore";
            this.NomeProdotto = p.Codice;
            this.Descrizione = p.Descrizione;
            //this.UM = p.UM;
            this.PrezzoPerUnita = Convert.ToDouble(p.Prezzo);
           
        }

        public int IdProdotto { get; set; }
        public string Categoria { get; set;}
        public string NomeProdotto { get; set; }
        public string Descrizione { get; set; }
        public string UM { get; set; }
        public double  PrezzoPerUnita { get; set; }
        public string NomeFornitore { get; set; }

       



    }

}