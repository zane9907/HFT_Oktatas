using Ora06.Data;
using Ora06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora06.Repository
{
    public class CarRepository : IRepository<Car>
    {
        CarDbContext ctx;

        public CarRepository(CarDbContext _ctx)
        {
            ctx = _ctx;
        }

        public void Create(Car entity)
        {
            ctx.Add(entity);
        }

        public void Delete(string id)
        {
            Car carToDelete = ctx.Cars.SingleOrDefault(x => x.Id == id);
            ctx.Remove(carToDelete);
        }

        public Car Get(string id)
        {
            return ctx.Cars.SingleOrDefault(x => x.Id == id);
        }
        
        public IQueryable<Car> GetAll()
        {
            return ctx.Cars.AsQueryable();
        }
    }
}
