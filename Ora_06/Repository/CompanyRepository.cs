using Ora_06.Data;
using Ora_06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora_06.Repository
{
    public class CompanyRepository : IRepository<Company>
    {
        private CompanyDbContext _ctx;

        public CompanyRepository(CompanyDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Create(Company t)
        {
            _ctx.Companies.Add(t);
            _ctx.SaveChanges();
        }

        public void Delete(string id)
        {
            Company toBeDeleted = Get(id);
            _ctx.Remove(toBeDeleted);
            _ctx.SaveChanges();
        }

        public Company Get(string id)
        {
            return _ctx.Companies.SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<Company> GetAll()
        {
            return _ctx.Companies.AsQueryable();
        }
    }
}
