using Ora08.Model;
using Ora08.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora08.Logic
{
    public class PersonLogic
    {
        private readonly IRepository<Person> _repository;

        public PersonLogic(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public IEnumerable<Person> GetAll()
        {
            return _repository.GetAll();
        }

        public string Description(string name)
        {
            return _repository.GetAll().FirstOrDefault(x => x.Name == name).ToString();
        }

        public Person Get(string name)
        {
            return _repository.GetAll().FirstOrDefault(x => x.Name == name);
        }
    }
}
