using Microsoft.EntityFrameworkCore;
using PizzaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp.Contexts
{
    public class PizzaShopContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=4N8CBX3\\SQLEXPRESS;Integrated Security=true;Initial Catalog=dbPizzaShop");
        }
        public DbSet<Pizza> Pizzas { get; set; }

    }
}
