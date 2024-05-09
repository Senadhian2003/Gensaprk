using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RequestTrackerDALLibrary.Interface
{
    public interface IRepository<K,T> where T : class
    {
        
        Task<T> Add(T entity);

        Task<T> Get(K key);

        Task<IList<T>> GetAll();

        Task<T> Update(T entity);

        Task<T> Delete(K key);


    }
}
