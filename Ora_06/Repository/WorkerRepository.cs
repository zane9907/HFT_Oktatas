using Ora_06.Data;
using Ora_06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora_06.Repository
{
    public class WorkerRepository : IRepository<Worker>
    {
        private CompanyDbContext _ctx;

        public WorkerRepository(CompanyDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Create(Worker t)
        {
            _ctx.Add(t);
            _ctx.SaveChanges();
        }

        public void Delete(string id)
        {
            Worker toBeDeleted = Get(id);
            _ctx.Remove(toBeDeleted);
            _ctx.SaveChanges();
        }

        public Worker Get(string id)
        {
            return _ctx.Workers.SingleOrDefault(x => x.Id == id);
        }

        public IQueryable<Worker> GetAll()
        {
            return _ctx.Workers.AsQueryable();
        }
    }
}
