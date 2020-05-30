using Crm_Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Crm_Entities;

namespace Crm_DataUtilities.ViewModel
{
    public class ProductionSituationModel
    {
        public ProductionSituationModel() { }
        public ProductionSituationModel(tStage stage  ) {

            this.badProductValue = stage.NumberBadProductValue ?? 0.0;
            this.niceProductValue = stage.NumberNiceProductValue ?? 0.0;
            this.totalProduction = badProductValue + totalProduction;
            this.productName = stage.tProduct.tProductCategory.Descrizione;
            this.machineName = stage.tMachine.Name;
            this.machineStateDescription = stage.tMachine.tMachineState.NameState;
            this.idStage = stage.idStage;
            users = new List<UserViewModel>();                   
            foreach (tShift item in stage.tShift.ToList())
            {
                users.Add(new UserViewModel(item.tUser));
            }
        }

        public int idStage { get; set; }
        public string machineStateDescription { get; set; }
        public double totalProduction { get; set; }
        public double badProductValue { get; set; }
        public double niceProductValue { get; set; }
        public List<UserViewModel> users { get; set; }
        public string machineName { get; set; }
        public string productName { get; set; }
    }
}

