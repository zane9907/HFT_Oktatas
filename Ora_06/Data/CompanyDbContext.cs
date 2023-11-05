using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Ora_06.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora_06.Data
{
    public class CompanyDbContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Company> Companies { get; set; }

        public DbSet<Country> Countries { get; set; }

        public CompanyDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("companyDb").UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Worker> workers = ParseJSON<Worker>("workers.json");
            List<Company> companies = ParseJSON<Company>("companies2.json");
            List<Country> countries = ParseJSON<Country>("countries.json");


            modelBuilder.Entity<Worker>()
                .HasOne(x => x.Company)
                .WithMany(x => x.Workers)
                .HasForeignKey(x => x.CompanyID)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Company>()
                .HasOne(x => x.Country)
                .WithMany(x => x.Companies)
                .HasForeignKey(x => x.CountryId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Worker>().HasData(workers);
            modelBuilder.Entity<Company>().HasData(companies);
            modelBuilder.Entity<Country>().HasData(countries);
        }


        private List<T> ParseJSON<T>(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
}
