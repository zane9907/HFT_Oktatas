using System.Runtime.CompilerServices;

namespace Ora_05
{
    public class Program
    {
        static void Main(string[] args)
        {
            CompanyDbContext db = new CompanyDbContext();
            var workers = db.Workers.ToList();
            var companies = db.Companies.ToList();


            var t1 = workers.Where(x => x.IsActive).ToList();

            var t2 = workers.Where(x => !x.IsActive).Average(x => x.Age);

            var t3 = workers.Where(x=> x.Balance >= 2000).Select(x => x.Name).ToList();

            var t4 = workers.GroupBy(x => x.Gender).Select(x => new
            {
                Gender = x.Key,
                Count = x.Count()
            }).ToList();


            var t5 = workers.GroupBy(x => x.EyeColor).OrderBy(x => x.Count()).FirstOrDefault();


            //var t6 = workers.Where(x => x.Company.Country == "Italy").Select(x => x.Name).ToList();

            var t6 = (from x in workers
                     join y in companies
                     on x.CompanyID equals y.Id
                     where y.Country == "Italy"
                     select x.Name).ToList();


            var t7 = workers.Where(x => x.Registered.Year >= 2016 && x.Registered.Year <= 2020).Select(x => new
            {
                Name = x.Name,
                Age = x.Age
            }).ToList();


            var t8 = workers.Where(x => x.Gender == "male").Sum(x => x.Balance);


            var t9 = workers.GroupBy(x => x.Age).OrderBy(x=>x.Count()).FirstOrDefault();


            ;
            ;
        }
    }
}