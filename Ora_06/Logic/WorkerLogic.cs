using Ora_06.Models;
using Ora_06.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora_06.Logic
{
    public class WorkerLogic : ILogic<Worker>
    {
        private IRepository<Worker> _repository;

        public WorkerLogic(IRepository<Worker> repository)
        {
            _repository = repository;
        }

        public void Create(Worker t)
        {
            _repository.Create(t);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public Worker Get(string id)
        {
            return _repository.Get(id);
        }

        public IQueryable<Worker> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
