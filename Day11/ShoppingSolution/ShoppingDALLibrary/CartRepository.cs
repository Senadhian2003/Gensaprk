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
        public override Cart Add(Cart entity)
        {
            entity.Id = ++index;
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
            Predicate<Cart> predicate = (C) => C.Id == key;

            Cart customer = items.ToList().Find(predicate);

            return customer;
        }

        public override Cart Update(Cart item)
        {

            Predicate<Cart> predicate = (C) => C.Id == item.Id;

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
