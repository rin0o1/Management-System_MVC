using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Crm_Entities;

namespace Crm_DataUtilities.ViewModel
{
    public class PreventiveViewModel
    {
        public PreventiveViewModel(tPreventive preventive)
        {
            //Unire l'oggetto di EntityFramework  con il modello 
            this.IdPreventivo = preventive.ID;
        }


        //Questo costruttore è solo di utilità per poter gestire la parte grafica ma dovra essere eliminato
        //e sostituito
        public PreventiveViewModel()
        {
            IdPreventivo = 3;
            NumeroPreventivo = "numero preventivo";
            Data = DateTime.Now;
            Riferimento= "riferimento";
            Listino = 1000.5;
        }

        //Chiedere se potrebbero bastare questi elementi
        public int IdPreventivo { get; set; }

        [Display(Name = "NUMERO PREVENTIVO")]
        public string NumeroPreventivo { get; set; }

        [Display(Name = "DATA")]
        public DateTime Data { get; set; }

        [Display(Name = "RIFERIMENTO")]
        public string Riferimento { get; set; }

        [Display(Name = "LISTINO")]
        public double Listino { get; set; }


    }
}
