using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartItemRepository
    {
        static int index = 0;
        protected List<CartItem> items = new List<CartItem>();
        public ICollection<CartItem> GetAll()
        {
            
            return items.ToList<CartItem>();
        }

        public  CartItem Add(CartItem entity)
        {
            
            items.Add(entity);
            return entity;
        }

        public  CartItem Delete(CartItem cartItem)
        {

            if (cartItem == null)
            {
                return null;
            }

            items.Remove(cartItem);
            return cartItem;

        }

        public  CartItem GetByKey(int customerId,int productId)
        {
            CartItem cartItem = null;
            foreach (var item in items)
            {
                if(item.CustomerId == customerId && item.ProductId == productId)
                {
                    cartItem = item;
                    return cartItem;
                }

            }
            return cartItem;
        }

        //public  CartItem Update(CartItem item)
        //{

        //    Predicate<CartItem> predicate = (C) => C.CartId == item.CartId;

        //    int indexOfEntity = items.IndexOf(item);

        //    if (indexOfEntity == -1)
        //    {
        //        return null;
        //    }

        //    items[indexOfEntity] = item;

        //    return items[indexOfEntity];


        //}


    }
}
