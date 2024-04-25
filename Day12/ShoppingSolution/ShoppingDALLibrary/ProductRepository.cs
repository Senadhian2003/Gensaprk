using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {
        static int index = 0;
        public override Product Add(Product entity)
        {
            entity.Id = ++index;
            items.Add(entity);
            return entity;
        }

        public override Product Delete(int key)
        {


            Product customer = GetByKey(key);

            if (customer == null)
            {
                return null;
            }

            items.Remove(customer);
            return customer;

        }

        public override Product GetByKey(int key)
        {
            Predicate<Product> predicate = (C) => C.Id == key;

            Product customer = items.Find(predicate);

            return customer;
        }

        public override Product Update(Product item)
        {

            Predicate<Product> predicate = (C) => C.Id == item.Id;

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
