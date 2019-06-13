using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm_DataUtilities.ViewModel
{
    /*si dovra fare la join con l'id del client preso nel repository del controller client*/
    public class SendDataListinoViewModel
    {
        public int IdCustomer { get; set; }

        /*sia l'email che il nome verranno settati succesivamente facendo la join attraverso l'id*/
        public string EmailCustomer { get; set; }

        public string NomeCliente { get; set; }
        public string Prodotto { get; set; }

        public double Listino { get; set; }
        public  string TestoAggiuntivo { get; set; }

    }
}
