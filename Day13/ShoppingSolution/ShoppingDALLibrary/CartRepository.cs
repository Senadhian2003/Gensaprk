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
        public override Cart Add(Cart entity)
        {
           
            items.Add(entity);
            return entity;
        }

        public override Cart Delete(int key)
        {


            Cart customer = GetByKey(key);

            if (customer == null)
            {
                return null;
            }

            items.Remove(customer);
            return customer;

        }

        public override Cart GetByKey(int key)
        {
            Predicate<Cart> predicate = (C) => C.CustomerId == key;

            Cart customer = items.Find(predicate);

            return customer;
        }

        public override Cart Update(Cart item)
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
