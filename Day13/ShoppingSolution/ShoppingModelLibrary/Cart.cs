using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary
{
    public class Cart
    {
         
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }//Navigation property

        public List<CartItem> CartItems { get; set; }//Navigation property. } }


        public Cart(Customer customer) {
            
            Customer = customer;
            this.CustomerId = customer.Id;
            CartItems = new List<CartItem>();
        }

    }
}
