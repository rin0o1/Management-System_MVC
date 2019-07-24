using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using Crm_Entities;
using Crm_Global;

namespace Crm_DataUtilities.ViewModel
{
    public class CustomerViewModel
    {

        public CustomerViewModel(tCliente c)
        {
            IdCliente = c.Id;
            Nome = c.CodiceUniclima;
            Email = c.IndirizzoEmail;
            ContattoDiRiferimento = c.Conttato1;
            Classe = c.Classe;
            CittaDitta = c.Citta;
            CodiceUniclima = c.CodiceUniclima;
        }
            
        public CustomerViewModel(int n)
        {
            IdCliente = 1;
            Nome = (n > 1) ? "Paolo" : "Gennaro";
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
        public int? Classe { get; set; }

        [Display(Name ="Codice Uniclima")]
        public string CodiceUniclima { get; set; }

        public int IdDitta { get; set; }

        [Display (Name ="Ditta")]
        public string Ditta { get; set; }

        [Display(Name ="Citta Ditta")]
        public string CittaDitta { get; set; }

    }


    public class CustomerDetailsViewModel
    {
        public CustomerDetailsViewModel()
        {
            this.Id = 1;
            this.RagioneSociale = "nessuno";
            this.CodiceUniclima = "nessuno";
            this.Categoria = "nessuno";
            this.Classe = 6;
            this.Indirizzo = "nessuno";
            this.CAP = 5;
            this.Citta = "nessuno";
            this.Provincia = "nessuno";
            this.P_Iva = "nessuno";
            this.Banca = "nessuno";
            this.CIN = "nessuno";
            this.ABI = "nessuno";
            this.CAB = "nessuno";
            this.ContoCorrente = "nessuno";
            this.IBAN = "nessuno";
            this.TelefonoUfficio = "nessuno";
            this.Telefax = "nessuno";
            this.Contatto1 = "nessuno";
            this.Cellulare1 = "nessuno";
            this.Referente1 = "nessuno";
            this.Referente2 = "nessuno";
            this.Nota = "nessuno";
            this.Fornitori = "nessuno";
            this.Titolari ="nessuno";
            this.Soci = "nessuno";
            this.Segretari = "nessuno";
            this.Amministrativi = "nessuno";
            this.UfficioTecnico = "nessuno";
            this.Email = "nessuno";
            this.IndirizzoInternet = "nessuno";
            this.ConsensoDati = "nessuno";
            this.FatturatoGloable = 7;

        }
        public CustomerDetailsViewModel(tCliente c)
        {
            this.Id = c.Id;
            this.Data = c.Data_;
            this.RagioneSociale = c.RagioneSociale;
            this.CodiceUniclima = c.CodiceUniclima;
            this.Categoria = c.Categoria;
            this.Classe = c.Classe;
            this.Indirizzo = c.Indirizzo;
            this.CAP = c.CAP ?? 0 ;
            this.Citta = c.Citta;
            this.Provincia = c.Provincia;
            this.P_Iva = c.P_Iva;
            this.Banca = c.Banca;
            this.CIN = c.CIN;
            this.ABI = c.ABI;
            this.CAB = c.CAB;
            this.ContoCorrente = c.ContoCorrente;
            this.IBAN = c.IBAN;
            this.TelefonoUfficio = c.TelefonoUfficio;
            this.Telefax = c.Telefax;
            this.Contatto1 = c.Conttato1;
            this.Cellulare1 = c.Cellulare1;
            this.Referente1 = c.Referente1;
            this.Referente2 = c.Referente2;
            this.Nota = c.Note1;
            this.Fornitori = c.Fornitori;
            this.Titolari = c.Titolari;
            this.Soci = c.Soci;
            this.Segretari = c.Segretari;
            this.Amministrativi = c.Amministrativi;
            this.UfficioTecnico = c.UfficioTecnico;
            this.Email = c.IndirizzoEmail;
            this.IndirizzoInternet = c.SitoInternet;
            this.ConsensoDati = c.ConsensoDati;
            this.FatturatoGloable = c.FatturatoGlobale ?? 0;
            this.Note1 = c.Note1;
        }

        public int Id { get; set; }
        public string RagioneSociale { get; set; }
        public string CodiceUniclima { get; set; }
        public string Categoria { get; set; }
        public int? Classe { get; set; }
        public string Indirizzo { get; set; }
        public int CAP { get; set; }
        public string Citta { get; set; }
        public string Provincia { get; set; }
        public string P_Iva { get; set; }
        public string Banca { get; set; }
        public string CIN { get; set; }
        public string ABI { get; set; }
        public string CAB { get; set; }
        public string ContoCorrente { get; set; }
        public string IBAN { get; set; }
        public string TelefonoUfficio { get; set; }
        public string Telefax { get; set; }
        public string Contatto1 { get; set; }
        public string Cellulare1 { get; set; }
        public string Referente1 { get; set; }
        public string Referente2 { get; set; }
        public string Nota { get; set; }
        public string Fornitori { get; set; }
        public string Titolari { get; set; }
        public string Soci { get; set; }
        public string Segretari { get; set; }
        public string Amministrativi { get; set; }
        public string UfficioTecnico { get; set; }
        public string Email { get; set; }
        public string IndirizzoInternet { get; set; }
        public string ConsensoDati { get; set; }
        public double FatturatoGloable { get; set; }
        public DateTime? Data { get; set; }
        //Create la tabella ordini, attraverso la join
        public string NomeDitta { get; set; }
        public string Note1 { get; set; }

    }
}
