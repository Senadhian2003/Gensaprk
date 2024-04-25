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
    public class CartItemBL
    {
        readonly CartItemRepository _repository;

        public CartItemBL()
        {
            _repository = new CartItemRepository();
        }

        public CartItem AddToCart(Customer customer, int productId, ProductBL productBL, CartBL cartBL)
        {
            Product product = productBL.GetProduct(productId);

            CartItem cartItem = new CartItem(product, customer.Id);
            cartItem.BuildCartItemFromConsole();    
            CartItem result = _repository.Add(cartItem);

            cartBL.UpdateCart(customer.Id, result);

            return cartItem;

        }

        public CartItem GetCartItem(int customerId, int productId)
        {
            return _repository.GetByKey(customerId, productId); 
        }

        public CartItem RemoveFromCart( CartItem cartItem)
        {
            CartItem result = _repository.Delete(cartItem);

            if (result == null)
            {
                throw new ElementNotFoundException("Cart");
            }

           

            return result;

        }

        public List<CartItem> GetAll()
        {
            List<CartItem> cartlist = _repository.GetAll().ToList();

            if(cartlist.Count==0)
            {
                throw new EmptyListException("Cart");
            }
            return cartlist;

        }

    }
}
