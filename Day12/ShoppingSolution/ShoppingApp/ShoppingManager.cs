using ShoppingBLLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingApp
{
    public class ShoppingManager
    {
        ProductBL productBL;
        CustomerBL customerBL;
        CartBL cartBL;
        CartItemBL cartItemBL;
        public ShoppingManager() { 
        
            productBL = new ProductBL();
            customerBL = new CustomerBL();
            cartBL = new CartBL();
            cartItemBL = new CartItemBL();

        }

        public void check()
        {
            try
            {

                Product product1 = new Product() { Name = "Shoes", Price = 100, QuantityInHand = 10 };
                Product product2 = new Product() { Name = "Box", Price = 50, QuantityInHand = 10 };
                Product product3 = new Product() { Name = "Pencils", Price = 25, QuantityInHand = 10 };

                productBL.AddProduct(product1);
                productBL.AddProduct(product2);
                productBL.AddProduct(product3);



                List<Product> products = productBL.GetProducts();

                Customer customer1 = new Customer() { Name = "Sena", Age = 18, Phone = "8678900238" };
                Customer customer2 = new Customer() { Name = "Spiderman", Age = 10, Phone = "8678900238" };

                customerBL.AddCustomer(customer1, cartBL);
                customerBL.AddCustomer(customer2, cartBL);

                List<Customer> customers = customerBL.GetAll();

                foreach (var item in products)
                {
                    Console.WriteLine(item);

                }

                Cart cart = cartBL.GetCartByKey(1);
                Console.WriteLine(cart.Customer.Name);

                cartItemBL.AddToCart(customer1, 1, productBL, cartBL);
                cartItemBL.AddToCart(customer1, 2, productBL, cartBL);

                double total = cartBL.Checkout(customer1, cartItemBL);
                Console.WriteLine("Total\t: " + total);

                List<CartItem> cartItems = cartItemBL.GetAll();

                foreach (var item in cartItems)
                {
                    Console.WriteLine(item);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void Main(string[] args)
        {
            ShoppingManager shoppingManager = new ShoppingManager();
            shoppingManager.check();


        }


    }
}
