using Ora_06.Models;
using Ora_06.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora_06.Logic
{
    public class CountryLogic : ILogic<Country>
    {
        private IRepository<Country> _repository;

        public CountryLogic(IRepository<Country> repository)
        {
            _repository = repository;
        }

        public void Create(Country t)
        {
            _repository.Create(t);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public Country Get(string id)
        {
            return _repository.Get(id);
        }

        public IQueryable<Country> GetAll()
        {
            return _repository.GetAll();
        }
    }
}
