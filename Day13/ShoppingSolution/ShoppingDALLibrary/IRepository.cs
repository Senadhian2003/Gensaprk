using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public interface IRepository <K, T>
    {
        Task<T> Add(T entity);

       Task <List<T>> GetAll();

        Task<T> GetByKey(K id);

        Task<T> Update(T entity);

        Task<T> Delete(K id);

    }
}
