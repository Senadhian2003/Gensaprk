using Microsoft.EntityFrameworkCore;
using VmSqlDemoApp.Models;

namespace VmSqlDemoApp.Context
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }


        


        }
}
