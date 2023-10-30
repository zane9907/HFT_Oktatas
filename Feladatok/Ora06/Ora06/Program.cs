using Ora06.Data;
using Ora06.Logic;
using Ora06.Models;
using Ora06.Repository;

namespace Ora06
{
    class Program
    {
        static void Main(string[] args)
        {
            CarDbContext ctx = new CarDbContext();
            IRepository<Car> carRepository = new CarRepository(ctx);
            ILogic<Car> carLogic = new CarLogic(carRepository);


            var list = carLogic.GetAll();

            Car c1 = carLogic.Get(list.First().Id);

            carLogic.Create(new Car
            {
                Name = "Ford",
                Year = 2023
            });

            carLogic.Delete(c1.Id);


            //var cars = ctx.Cars.ToList();
            //var people = ctx.People.ToList();
            //var schools = ctx.Schools.ToList();
            ;
            ;
        }
    }
}