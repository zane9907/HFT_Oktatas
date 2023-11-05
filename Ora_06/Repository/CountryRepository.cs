using Ora_06.Data;
using Ora_06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora_06.Repository
{
    public class CountryRepository : IRepository<Country>
    {
        private CompanyDbContext _ctx;

        public CountryRepository(CompanyDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Create(Country t)
        {
            _ctx.Add(t);
            _ctx.SaveChanges();
        }

        public void Delete(string id)
        {
            Country toBeDeleted = Get(id);
            _ctx.Remove(toBeDeleted);
            _ctx.SaveChanges();
        }

        public Country Get(string id)
        {
            return _ctx.Countries.SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<Country> GetAll()
        {
            return _ctx.Countries.AsQueryable();
        }
    }
}
