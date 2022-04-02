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

    public  class AppDbContext:DbContext
    {
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product>  Products { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions):base(dbContextOptions)
        {

        }
    }
}
