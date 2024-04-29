using ShoppingBLLibrary;
using ShoppingBLLibrary.Exceptions;
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
        Customer customer;
        public ShoppingManager() { 
        
            productBL = new ProductBL();
            customerBL = new CustomerBL();
            cartBL = new CartBL();
            Product product1 = new Product() { Name = "Shoes", Price = 100, QuantityInHand = 10 };
            Product product2 = new Product() { Name = "Box", Price = 50, QuantityInHand = 10 };
            Product product3 = new Product() { Name = "Pencils", Price = 25, QuantityInHand = 10 };
            productBL.AddProduct(product1);
            productBL.AddProduct(product2);
            productBL.AddProduct(product3);
        }

        public void PrintMenuForCustomer()
        {
            Console.WriteLine();
            Console.WriteLine("Customer Functionalities");
            Console.WriteLine("1. Display All products");
            Console.WriteLine("2. Add Item to cart");
            Console.WriteLine("3. Remove item from cart");
            Console.WriteLine("4. View Cart Items");
            Console.WriteLine("5. Checkout");
            Console.WriteLine("0. Exit");
            Console.WriteLine();
        }

        async void ShowAllProducts()
        {
            Console.WriteLine("The Products available are...");
           List<Product> productList = await  productBL.GetProducts();

            foreach (Product product in productList)
            {
                Console.WriteLine(product);
            }


        }

        void AddItemToCart()
        {
            try
            {
                Console.WriteLine("Enter the id of the product");
                int productId = Convert.ToInt32(Console.ReadLine());
                cartBL.AddToCart(customer, productId, productBL);
                Console.WriteLine("Item added to cart successfully");
            }
            catch(ElementNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        void RemoveItemFromCart()
        {
            try
            {
                Console.WriteLine("Enter the id of the product");
                int productId = Convert.ToInt32(Console.ReadLine());
                cartBL.DeleteCart(customer.Id, productId);
                Console.WriteLine("Item Removed from cart successfully");
            }
            catch (ElementNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

         async void Checkout()
        {
            double totalAmount = await  cartBL.Checkout(customer, productBL);

            Console.WriteLine("Total amount = "+ totalAmount);

        }
        
        async void ViewCart()
        {
            Console.WriteLine("Items in cart ...");

            List<CartItem> cartItems = await cartBL.ViewCartItems(customer);

            foreach(CartItem cartItem in cartItems)
            {
                Console.WriteLine(cartItem);
               
            }


        }

        async void EmployeeInteraction()
        {
            int choice = 0;

          

            Console.WriteLine("Welcom To Shopping");
            Console.WriteLine("1.Login");
            Console.WriteLine("2.Signup");

            try
            {

                int operation = Convert.ToInt32(Console.ReadLine());

                if (operation == 2)
                {
                    customer= new Customer();
                    customer.BuildCustomerFromConsole();
                    customer = await customerBL.AddCustomer(customer, cartBL);
                    Console.WriteLine("Customer added successfully");
                }

                else
                {
                    Console.WriteLine("Enter your id");
                    int customerId = Convert.ToInt32(Console.ReadLine());
                    customer = await customerBL.GetCustomerById(customerId);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            //if (customers == null)
            //{
            //    Console.WriteLine("There are no customers, Enter your Details");

            //    customer = new Customer();
            //    customer.BuildCustomerFromConsole();
            //   customer =  await customerBL.AddCustomer(customer, cartBL);
            //    Console.WriteLine("New Hr added successfully");
            //    Console.WriteLine();
            //}
            //else
            //{
            //    Console.WriteLine("Hey new user enter your id to login");
            //    int id = Convert.ToInt32(Console.ReadLine());
            //    customer = await customerBL.GetCustomerById(id);
            //    Console.WriteLine();


            //}

           

                do
                {
                    PrintMenuForCustomer();
                    Console.WriteLine("Please select an option");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 0:
                            Console.WriteLine("Bye.....");
                            break;
                        case 1:
                            ShowAllProducts();
                            break;
                        case 2:
                            AddItemToCart();
                            break;
                        case 3:
                           RemoveItemFromCart();
                            break;
                        case 4:
                            ViewCart();
                            break;
                        case 5:
                            Checkout();
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Try again");
                            break;
                    }
                } while (choice != 0);
          
            


            EmployeeInteraction();


        }




        //public async void check()
        //{
        //    try
        //    {

        //Product product1 = new Product() { Name = "Shoes", Price = 100, QuantityInHand = 10 };
        //Product product2 = new Product() { Name = "Box", Price = 50, QuantityInHand = 10 };
        //Product product3 = new Product() { Name = "Pencils", Price = 25, QuantityInHand = 10 };

        //        productBL.AddProduct(product1);
        //        productBL.AddProduct(product2);
        //        productBL.AddProduct(product3);

        //        List<Product> products = await productBL.GetProducts();

        //        Console.WriteLine("Products in list");

        //        foreach (var item in products)
        //        {
        //            Console.WriteLine(item);

        //        }



        //        Customer customer1 = new Customer() { Name = "Sena", Age = 18, Phone = "8678900238" };
        //        Customer customer2 = new Customer() { Name = "Spiderman", Age = 10, Phone = "8678900238" };

        //        customerBL.AddCustomer(customer1, cartBL);
        //        customerBL.AddCustomer(customer2, cartBL);

        //        List<Customer> customers = await customerBL.GetAll();

        //        foreach (var item in customers)
        //        {
        //            Console.WriteLine(item);

        //        }

        //        Cart cart = await cartBL.GetCartByKey(1);
        //        Console.WriteLine(cart.Customer.Name);

        //        cartBL.AddToCart(customer1, 1, productBL);
        //        cartBL.AddToCart(customer1, 2, productBL);

        //        double total = await cartBL.Checkout(customer1,productBL);
        //        Console.WriteLine("Total\t: " + total);

        //        List<Product> final = await productBL.GetProducts();

        //        Console.WriteLine("Products in list");

        //        foreach (var item in final)
        //        {
        //            Console.WriteLine(item);

        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //}

        public static void Main(string[] args)
        {
            ShoppingManager shoppingManager = new ShoppingManager();
            shoppingManager.EmployeeInteraction();


        }


    }
}
