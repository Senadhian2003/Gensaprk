using ShoppingBLLibrary.Exceptions;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CartBL
    {   
        readonly IRepository<int, Cart> _repository;
        public CartBL() {
            _repository = new CartRepository();

        }

        public Cart AddCart(Cart cart)
        {
            Cart result =  _repository.Add(cart);

            if(result != null)
            {
                return result;
            }
            throw new InsertErrorException("Cart");

        }

        public Cart GetCartByKey(int customerId)
        {
            Cart result = _repository.GetByKey(customerId);

            if(result != null)
            {
                return result;
            }
            throw new ElementNotFoundException("Cart");
        }

        public void UpdateCart(int customerId, CartItem cartItem)
        {

            Cart cart = GetCartByKey(customerId);

            if (cart.CartItems.Count >= 5)
            {
                throw new ListFullException("Cart");
            }

            cart.CartItems.Add(cartItem);

        }

        public void DeleteCart(int customerId, int productId, CartItemBL cartItemBL)
        {
            Cart cart = GetCartByKey(customerId);

            CartItem cartItem = cartItemBL.GetCartItem(customerId, productId);

            if (cart.CartItems.Remove(cartItem))
            {
                Console.WriteLine("Item Removed from cart successfully");
            }
            else
            {
                Console.WriteLine("Item could not be Removed from cart.");
            }

            cartItem = cartItemBL.RemoveFromCart(cartItem);



        }


        public double Checkout(Customer customer, CartItemBL cartItemBL)
        {
            Cart cart = GetCartByKey(customer.Id);

            double total = 0;
            foreach (CartItem item in cart.CartItems)
            {
                total += (item.Price + item.ShippingCharge);
                Console.WriteLine(item);
                
                cartItemBL.RemoveFromCart(item);
            }


            return total;


        }



    }
}
