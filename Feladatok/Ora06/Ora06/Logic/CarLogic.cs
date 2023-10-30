using Ora06.Models;
using Ora06.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora06.Logic
{
    public class CarLogic : ILogic<Car>
    {
        IRepository<Car> _repository;

        public CarLogic(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public void Create(Car entity)
        {
            _repository.Create(entity);
        }

        public void Delete(string id)
        {
            _repository.Delete(id);
        }

        public Car Get(string id)
        {
            return _repository.Get(id);
        }

        public IQueryable<Car> GetAll()
        {
            return _repository.GetAll();
        }



    }
}
