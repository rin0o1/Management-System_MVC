using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm_DataUtilities.ViewModel
{
    //Filtro per la ricerca 
    public class FilterForSearchBar
    {
      
    }

    //Filtro per poter filtrare i tipo di dati da visualizzare ES: Mostrare solo gli elementi che hanno cose in comune
    //-1 valore utilizzato per indicare il primo filtro
    public class FilterForDataVisualization
    {
        public FilterForDataVisualization() ///Da rivedere, se non ci sono filtri bisognerebbe mostare tutto 
        {
            Value = -1;
            TextToShow = "Tutti";            
        }
      
        public int  Value { get; set; }
        public string TextToShow { get; set; }
    }

    //Filtro per poter scegliere il tipo di sottopagina da visualizzare

    //=======================================================================================
    //RIVEDERE QUESTA CLASSE, LE SOTTOPAGINE POTREBBERO ESSERE GESTITE IN ALTRO MODO
    //=======================================================================================
    public class FilterForUnderPage
    {

    }

    //Classe utile per gestire alcune informazioni della pagina
    public class PageParameters
    {
        public PageParameters()
        {
            HasScrollButton = true;
        }
        public string PageTitle { get; set; }
        public List<FilterForDataVisualization> FilterForData { get; set; }

        public string ControllerName { get; set; }

        public bool HasScrollButton { get; set; }
    }
        

}
