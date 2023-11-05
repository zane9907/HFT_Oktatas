using Ora_06.Data;
using Ora_06.Logic;
using Ora_06.Models;
using Ora_06.Repository;

namespace Ora_06
{
    public class Program
    {
        static void Main(string[] args)
        {
            CompanyDbContext ctx = new CompanyDbContext();

            IRepository<Worker> workerRepository = new WorkerRepository(ctx);
            IRepository<Company> companyRepository = new CompanyRepository(ctx);
            IRepository<Country> countryRepository = new CountryRepository(ctx);


            ILogic<Worker> workerLogic = new WorkerLogic(workerRepository);
            ILogic<Company> companyLogic = new CompanyLogic(companyRepository);
            ILogic<Country> countryLogic = new CountryLogic(countryRepository);


            var workers = workerLogic.GetAll();

            Company c = new Company()
            {
                CountryId = "2",
                CompanyName = "TEST",
                OwnerName = "YES",
                Id = "6"
            };

            companyLogic.Create(c);


            var companies = companyLogic.GetAll();

            companyLogic.Delete(c.Id);
            companies = companyLogic.GetAll();


            ;
            ;
        }
    }
}