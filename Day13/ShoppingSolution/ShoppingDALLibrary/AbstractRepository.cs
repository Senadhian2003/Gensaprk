using ShoppingModelLibrary;

namespace ShoppingDALLibrary
{
    public abstract class AbstractRepository<K, T> : IRepository<K, T>
    {
        protected List<T> items = new List<T>();
       
        public abstract Task<T> Add(T item);
        public async Task <List<T>> GetAll()
        {
          
            return items.ToList<T>();
        }

        public abstract Task <T> Delete(K key);
        



        public abstract Task<T> GetByKey(K key);

        public abstract Task<T> Update(T item);

    }
}
