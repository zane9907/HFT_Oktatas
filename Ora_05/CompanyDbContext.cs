using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Ora_05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora_05
{
    public class CompanyDbContext : DbContext
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Company> Companies { get; set; }

        public CompanyDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("companyDb").UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Worker> workers = ParseJSON<Worker>("workers.json");
            List<Company> companies = ParseJSON<Company>("companies.json");


            modelBuilder.Entity<Worker>()
                .HasOne(x => x.Company)
                .WithMany(x => x.Workers)
                .HasForeignKey(x => x.CompanyID)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Worker>().HasData(workers);
            modelBuilder.Entity<Company>().HasData(companies);
        }


        private List<T> ParseJSON<T>(string path)
        {
            string json = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<List<T>>(json);
        }
    }
}
