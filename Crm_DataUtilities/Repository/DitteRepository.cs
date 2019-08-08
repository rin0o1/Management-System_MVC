using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Crm_DataUtilities;
using Crm_Entities;
using Crm_Global;


namespace Crm_DataUtilities.Repository
{
    public class CompanyRepository
    {
        private MyDataEntities dbEntity;

        public CompanyRepository (MyDataEntities dbEntity= null)
        {
            this.dbEntity = dbEntity ?? new MyDataEntities();

        }
        
        public IQueryable<tDitte> GetAllCompany()
        {
            return this.dbEntity.tDitte;
        }

        public tDitte GetCompanyFromId(int Id)
        {
            return this.dbEntity.tDitte.FirstOrDefault(x=> x.IdDitta== Id);
        }

        public void SaveCompany(tDitte Company, EnumUseful.typeOfDatabaseOperation typeOfDatabaseOperation)
        {
            switch (typeOfDatabaseOperation)
            {
                case EnumUseful.typeOfDatabaseOperation.EDIT:
                    tDitte CompanyToEdit = dbEntity.tDitte.FirstOrDefault(
                        x=> x.IdDitta== Company.IdDitta
                        );

                    if (CompanyToEdit!= null)
                    {
                        CompanyToEdit.IdDitta = Company.IdDitta;
                        CompanyToEdit.NomeDitta = Company.NomeDitta;
                        CompanyToEdit.RagioneSocialeDitta = Company.RagioneSocialeDitta;
                        CompanyToEdit.IndirizzoDitta = Company.IndirizzoDitta;
                        CompanyToEdit.CapDitta = Company.CapDitta;
                        CompanyToEdit.CittaDitta = Company.CittaDitta;
                        CompanyToEdit.ProvinciaDitta = Company.ProvinciaDitta;
                        CompanyToEdit.TelefonoDitta = Company.TelefonoDitta;
                        CompanyToEdit.FaxDitta = Company.FaxDitta;
                        CompanyToEdit.UrlDitta = Company.UrlDitta;
                        CompanyToEdit.EmailDitta = Company.EmailDitta;
                        CompanyToEdit.P_IvaDitta = Company.P_IvaDitta;
                        CompanyToEdit.CodiceAgente = Company.CodiceAgente;
                        CompanyToEdit.Listino = Company.Listino;
                        CompanyToEdit.Logo = Company.Logo;


                    }

                    break;
                case EnumUseful.typeOfDatabaseOperation.CREATE:
                    if (Company!=null)
                    {
                        dbEntity.tDitte.Add(Company);
                    }

                    break;
                case EnumUseful.typeOfDatabaseOperation.SAVE:
                    break;
                default:
                    break;
            }

            dbEntity.SaveChanges();
        }
            


    }
}
