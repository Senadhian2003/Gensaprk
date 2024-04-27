using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        static int index = 0;
        public override async Task<Cart> Add(Cart entity)
        {
           
            items.Add(entity);
            return entity;
        }

        public override async Task<Cart> Delete(int key)
        {


            Cart cart = await GetByKey(key);

            if (cart == null)
            {
                return null;
            }

            items.Remove(cart);
            return cart;

        }

        public override async Task<Cart> GetByKey(int key)
        {
            Predicate<Cart> predicate = (C) => C.CustomerId == key;

            Cart cart = items.Find(predicate);

            return cart;
        }

        public override async Task<Cart> Update(Cart item)
        {

            Predicate<Cart> predicate = (C) => C.CustomerId == item.CustomerId;

            int indexOfEntity = items.IndexOf(item);

            if (indexOfEntity == -1)
            {
                return null;
            }

            items[indexOfEntity] = item;

            return items[indexOfEntity];


        }

    }
}
