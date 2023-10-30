using Microsoft.EntityFrameworkCore;
using Ora06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora06.Data
{
    public class CarDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<School> Schools { get; set; }

        public CarDbContext()
        {
            Database.EnsureCreated();
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

            modelBuilder.Entity<Person>()
                .HasOne(x => x.School)
                .WithMany(x => x.People)
                .HasForeignKey(x => x.SchoolId)
                .OnDelete(DeleteBehavior.Cascade);

            School s1 = new School()
            {
                Name = "Óbudai Egyetem"
            };

            Person p1 = new Person()
            {
                Name = "Person1",
                Age = 25,
                SchoolId = s1.Id
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
            modelBuilder.Entity<School>().HasData(s1);
        }
    }
}
