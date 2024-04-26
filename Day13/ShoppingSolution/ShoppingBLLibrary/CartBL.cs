using ShoppingBLLibrary.Exceptions;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CartBL
    {
        
       
        
        readonly CartRepository _repository;
        public CartBL()
        {
            _repository = new CartRepository();
        }

        public Cart CreateCart(Cart cart)
        {
            Cart result = _repository.Add(cart);

            if (result != null)
            {
                return result;
            }
            throw new InsertErrorException("Cart");

        }

        public CartItem AddToCart(Customer customer, int productId, ProductBL productBL)
        {
            Product product = productBL.GetProductByKey(productId);

            CartItem cartItem = new CartItem(product, customer.Id);
            cartItem.BuildCartItemFromConsole();


            cartItem = UpdateCart(customer.Id, cartItem);

            return cartItem;

        }


        public CartItem UpdateCart(int customerId, CartItem cartItem)
        {

            Cart cart = GetCartByKey(customerId);

            if (cart.CartItems.Count >= 5)
            {
                throw new ListFullException("Cart");
            }

            cart.CartItems.Add(cartItem);

            return cartItem;

        }
        public Cart GetCartByKey(int customerId)
        {
            Cart result = _repository.GetByKey(customerId);

            if (result != null)
            {
                return result;
            }
            throw new ElementNotFoundException("Cart");
        }

        public CartItem DeleteCart(int customerId, int productId)
        {
            Cart cart = GetCartByKey(customerId);

            CartItem cartItem = cart.CartItems.FirstOrDefault((c) => c.ProductId == productId);

            if(cartItem != null)
            {
                cart.CartItems.Remove(cartItem);
                return cartItem;
            }

            throw new ElementNotFoundException("Cart Item");



        }


        public double Checkout(Customer customer, ProductBL productBL)
        {
            Cart cart = GetCartByKey(customer.Id);

            double total = 0;

            int countOfitems = 0;

            foreach (CartItem item in cart.CartItems)
            {
                total += (item.Price + item.ShippingCharge);
                Console.WriteLine(item);
                countOfitems++;
                productBL.Update(item.Product, item.Quantity);
               
            }

            cart.CartItems.Clear();

            if (countOfitems >= 3 && total > 1500)
            {
                total = total * 0.05;
            }

            return total;


        }





    }
}
