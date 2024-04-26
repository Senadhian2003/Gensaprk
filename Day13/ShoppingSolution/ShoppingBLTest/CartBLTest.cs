using NUnit.Framework.Internal;
using ShoppingBLLibrary;
using ShoppingBLLibrary.Exceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShoppingBLTest
{
    public class CartBLTest
    {

        CartBL cartBL;
        ProductBL productBL;
        CustomerBL customerBL;
        [SetUp]
        public void Setup()
        {
            customerBL = new CustomerBL();
            cartBL = new CartBL();
            productBL = new ProductBL();
            Product product1 = new Product() { Name = "Shoes", Price = 100, QuantityInHand = 10 };

           productBL.AddProduct(product1);
           
        }

        [Test]
        public void AddToCart()
        {
            Customer customer1 = new Customer() { Name = "Sena", Age = 18, Phone = "8678900238" };

            customerBL.AddCustomer(customer1, cartBL);


            CartItem cartItem = cartBL.AddToCart(customer1,1,productBL);
            Assert.IsNotNull(cartItem);

        }

        [Test]
        public void AddToCartFail()
        {
            Customer customer1 = new Customer() { Name = "Sena", Age = 18, Phone = "8678900238" };

            customerBL.AddCustomer(customer1, cartBL);


            CartItem cartItem = cartBL.AddToCart(customer1, 1, productBL);

            Product product2 = new Product() { Name = "boxes", Price = 100, QuantityInHand = 10 };
            Product product3= new Product() { Name = "Shirts", Price = 100, QuantityInHand = 10 };
            Product product4 = new Product() { Name = "Bottle", Price = 100, QuantityInHand = 10 };
            Product product5 = new Product() { Name = "Pants", Price = 100, QuantityInHand = 10 };

            productBL.AddProduct(product2);
            productBL.AddProduct(product3);
            productBL.AddProduct(product4);
            

            var expression = Assert.Throws<ListFullException>(() => productBL.AddProduct(product5));

            Assert.IsNotNull("The Cart List is Full new item cannot be added",expression.Message);

        }



    }
}
