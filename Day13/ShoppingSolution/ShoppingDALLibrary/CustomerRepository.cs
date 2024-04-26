﻿using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CustomerRepository : AbstractRepository<int, Customer>
    {
        public CustomerRepository() { }

        static int index = 0;
        public override Customer Add(Customer entity)
        {
            entity.Id = ++index;
            items.Add(entity);
            return entity;
        }

        public override Customer Delete(int key)
        {


            Customer customer = GetByKey(key);

            if (customer == null)
            {
                return null;
            }

            items.Remove(customer);
            return customer;

        }

        public override Customer GetByKey(int key)
        {
            Predicate<Customer> predicate = (C) => C.Id == key;

            Customer customer = items.Find(predicate);

            return customer;
        }

        public override Customer Update(Customer item)
        {
           
            Predicate<Customer> predicate = (C) => C.Id == item.Id;

            int indexOfEntity = items.IndexOf(item);

            if(indexOfEntity == -1)
            {
                return null;
            }

            items[indexOfEntity] = item;

            return items[indexOfEntity];


        }
    }
}
