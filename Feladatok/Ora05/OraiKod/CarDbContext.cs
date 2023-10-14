using Microsoft.EntityFrameworkCore;
using Ora05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora05
{
    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Person> People { get; set; }

        public CarDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("carDb").UseLazyLoadingProxies();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(x => x.Person)
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            Person p1 = new Person()
            {
                Name = "Person1",
                Age = 25
            };

            List<Car> cars = new List<Car>()
            {
                new Car()
                {
                    Name = "Suzuki",
                    Year = 1998,
                    PersonId = p1.Id
                },
                new Car()
                {
                    Name = "Skoda",
                    Year = 2002,
                    PersonId = p1.Id
                }
            };


            modelBuilder.Entity<Car>().HasData(cars);
            modelBuilder.Entity<Person>().HasData(p1);
        }
    }
}
