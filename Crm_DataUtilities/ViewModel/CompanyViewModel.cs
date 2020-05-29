using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Crm_Entities;

namespace Crm_DataUtilities.ViewModel
{
    public class CompanyViewModel
    {
        public CompanyViewModel() { }

        public CompanyViewModel(tDitte Company)
        {
            this.NomeDittaa = Company.NomeDitta;
            this.RagioneSocialeDitta = Company.RagioneSocialeDitta;
            this.EmailDitta = Company.EmailDitta;
            this.CittaDitta = Company.CittaDitta;
            this.IdDitta = Company.IdDitta;
        }

        public int IdDitta { get; set; }
        public string NomeDittaa { get; set; }
        public string RagioneSocialeDitta { get; set; }
        public string EmailDitta { get; set; }
        public string CittaDitta { get; set; }
    }

    public class CompanyViewModelDetails
    {
        public CompanyViewModelDetails() { }

        public CompanyViewModelDetails(tDitte Company)
        {

            this.IdDitta = Company.IdDitta;
            this.NomeDitta = Company.NomeDitta;
            this.RagioneSocialeDitta = Company.RagioneSocialeDitta;
            this.IndirizzoDitta = Company.IndirizzoDitta;
            this.CapDitta = Company.CapDitta;
            this.CittaDitta = Company.CittaDitta;
            this.ProvinciaDitta = Company.ProvinciaDitta;
            this.TelefonoDitta = Company.TelefonoDitta;
            this.FaxDitta = Company.FaxDitta;
            this.UrlDitta = Company.UrlDitta;
            this.P_IvaDitta = Company.P_IvaDitta;
            this.CodiceAgente = Company.CodiceAgente;
            this.Listino = Company.Listino;
            this.Logo = Company.Logo;
        }

        public int IdDitta { get; set; }
        public string NomeDitta { get; set; }
        public string RagioneSocialeDitta { get; set; }
        public string IndirizzoDitta { get; set; }
        public string CapDitta { get; set; }
        public string CittaDitta { get; set; }
        public string ProvinciaDitta { get; set; }
        public string TelefonoDitta { get; set; }
        public string FaxDitta { get; set; }
        public string UrlDitta { get; set; }
        public string EmailDitta { get; set; }
        public string P_IvaDitta { get; set; }
        public string CodiceAgente { get; set; }
        public string Listino { get; set; }
        public string Logo { get; set; }

    }

}
