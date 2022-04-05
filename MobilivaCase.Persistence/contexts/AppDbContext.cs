using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MobilivaCase.Domain.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileManagement.Persistence.EF
{   
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseMySQL(@"server=localhost;user=root;password=1234;database=MobilivaCaseDb");

            return new AppDbContext(optionsBuilder.Options);
        }
    }

    public class AppDbContext : DbContext
    {
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        // Add Fake Data Product
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {           
            modelBuilder.Entity<Product>().HasData(
                 new Faker<Product>()
                .RuleFor(x => x.Category, a => a.Commerce.ProductName())
                .RuleFor(x => x.CreateDate, a => a.Date.Between(DateTime.Now.AddYears(-2), DateTime.Now))
                .RuleFor(x => x.Description, a => a.Name.FullName())
                .RuleFor(x => x.Status, true)
                .RuleFor(x => x.Unit, a => a.Random.Int(1, 10))
                .RuleFor(x => x.UnitPrice, a => a.Random.Decimal())
                .Generate(1000)
            );            
        }
    }

}
