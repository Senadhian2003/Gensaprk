using Microsoft.EntityFrameworkCore;
using PizzaApp.Models;

namespace PizzaApp.Contexts
{
    public class PizzaAppContext : DbContext
    {

       public PizzaAppContext(DbContextOptions options) : base(options) {
        
       }

        public DbSet<User> Users { get; set; }

        public DbSet<UserCredential> UserCredentials { get; set; }

        public DbSet<Pizza> Pizzas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Pizza>().HasData(

                new Pizza() { Id = 101, Name = "Chicken Pizza", size = "Medium", price = 60, Availability = "In Stock" },
                new Pizza() { Id = 102, Name = "Paneer Pizza", size = "Small", price = 100, Availability = "Out of stock" },
                new Pizza() { Id = 103, Name = "Cheese Pizza", size = "Large", price = 150, Availability = "In Stock"}
                );




        }
        


    }
}
