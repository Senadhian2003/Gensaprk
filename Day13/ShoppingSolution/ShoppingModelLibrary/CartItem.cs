using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class CartItem
    {

        public int CustomerId { get; set; }//Navigation property
        public int ProductId { get; set; }
        public Product Product { get; set; }//Navigation property
        public int Quantity { get; set; } = 0;
        public double Price { get; set; }
        
        public double ShippingCharge {  get; set; } = 0;
        public DateTime PriceExpiryDate { get; set; }


        public CartItem(Product product, int customerId) {
        
            this.Product = product;
            ProductId = product.Id;
            CustomerId = customerId;

            if (product.Price < 100)
            {
                ShippingCharge = 100;
            }


        }

        public void BuildCartItemFromConsole() {

            Console.WriteLine("Enter The Quantity");

            int quantity = Convert.ToInt32(Console.ReadLine());

           if( quantity > Product.QuantityInHand)
            {
                throw new Exception();
            }
           else
            {
                Quantity = quantity;
                Price = Quantity * Product.Price;
            }
          


        }

        public override string ToString()
        {
            return "Product name\t: " + Product.Name
                    +"\nProduct Price\t: "+ Product.Price
                    + "\nProduct Quantity\t: " + Quantity
                    + "\nCost\t: " + Price
                    + "\nShipping cost\t: " + ShippingCharge;
        }


    }
}
