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
        public ProductViewModel(tProdoct p)
        {
            this.IdProdotto = p.IdProdotto;
            this.Categoria = p.Categoria;
            this.NomeProdotto = p.NomeProdotto;
            this.PrezzoPerUnita = p.PrezzoPerUnita ?? 0.0;
            this.UM = p.UM;
          
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
        public ProductDetailsViewModel (tProdoct p)
        {
            this.IdProdotto = p.IdProdotto;
            this.Categoria = p.Categoria;
            //this.NomeFornitore = p.tDitte.NomeDitta;
            this.NomeFornitore = "Fornitore";
            this.NomeProdotto = p.NomeProdotto;
            this.Descrizione = p.Descrizione;
            this.UM = p.UM;
            this.PrezzoPerUnita = p.PrezzoPerUnita ?? 0.0;
           
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