using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public interface IRepository <K, T>
    {
        T Add(T entity);

        ICollection<T> GetAll();

        T GetByKey(K id);

        T Update(T entity);

        T Delete(K id);

    }
}
