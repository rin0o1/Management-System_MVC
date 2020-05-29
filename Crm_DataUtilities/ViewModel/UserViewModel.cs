using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Crm_Entities;
namespace Crm_DataUtilities.ViewModel
{
   public class UserViewModel
   {
        public UserViewModel() { }
        public UserViewModel(tUser user) {
            this.Name = user.Name;
            this.Cognome = user.Surname;
            this.isAvaible = user.IsAvaible ?? false;
        }

        public string Name { get; set; }
        public string Cognome { get; set; }        

        public bool isAvaible { get; set; }

   }
}
