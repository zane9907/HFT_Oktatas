using Ora_06.Models;
using Ora_06.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora_06.Logic
{
    public class CompanyLogic : ILogic<Company>
    {
        private IRepository<Company> _repository;

        public CompanyLogic(IRepository<Company> repository)
        {
            _repository = repository;
        }

        public void Create(Company t)
        {
            _repository.Create(t);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public Company Get(string id)
        {
            return _repository.Get(id);
        }

        public IQueryable<Company> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
