﻿using ShoppingModelLibrary;

namespace ShoppingDALLibrary
{
    public abstract class AbstractRepository<K, T> : IRepository<K, T>
    {
        protected List<T> items = new List<T>();
       
        public abstract T Add(T item);
        public ICollection<T> GetAll()
        {
          
            return items.ToList<T>();
        }

        public abstract T Delete(K key);
        



        public abstract T GetByKey(K key);

        public abstract T Update(T item);

    }
}
