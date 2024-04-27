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

        public async Task <Cart> CreateCart(Cart cart)
        {
            Cart result = await _repository.Add(cart);

            if (result != null)
            {
                return result;
            }
            throw new InsertErrorException("Cart");

        }

        public async Task<CartItem> AddToCart(Customer customer, int productId, ProductBL productBL)
        {
            Product product = await productBL.GetProductByKey(productId);

            CartItem cartItem = new CartItem(product, customer.Id);
            cartItem.BuildCartItemFromConsole();


            cartItem = await UpdateCart(customer.Id, cartItem);

            return cartItem;

        }


        public async Task<CartItem> UpdateCart(int customerId, CartItem cartItem)
        {

            Cart cart = await GetCartByKey(customerId);

            if (cart.CartItems.Count >= 5)
            {
                throw new ListFullException("Cart");
            }

            cart.CartItems.Add(cartItem);

            return cartItem;

        }
        public async Task<Cart> GetCartByKey(int customerId)
        {
            Cart result = await _repository.GetByKey(customerId);

            if (result != null)
            {
                return result;
            }
            throw new ElementNotFoundException("Cart");
        }

        public async Task<CartItem> DeleteCart(int customerId, int productId)
        {
            Cart cart = await GetCartByKey(customerId);

            CartItem cartItem = cart.CartItems.FirstOrDefault((c) => c.ProductId == productId);

            if(cartItem != null)
            {
                cart.CartItems.Remove(cartItem);
                return cartItem;
            }

            throw new ElementNotFoundException("Cart Item");



        }


        public async Task<double> Checkout(Customer customer, ProductBL productBL)
        {
            Cart cart = await GetCartByKey(customer.Id);

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
