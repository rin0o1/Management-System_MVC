using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm_DataUtilities.ViewModel
{
    public class TestToRemoveViewModel
    {

        public TestToRemoveViewModel()
        {
            this.Nome= "Giacomo";
            this.Cognome = "Pierfederici";
            this.Id = 3;
        }

        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Id { get; set; }
     
    }
}
