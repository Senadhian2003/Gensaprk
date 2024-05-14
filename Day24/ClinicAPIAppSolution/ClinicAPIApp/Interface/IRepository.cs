using System.Threading.Tasks;

namespace ClinicAPIApp.Interface
{
    public interface IRepository<K,T> where T : class
    {
        Task<T> Add(T entity);

        Task<T> GetByKey(K key);
        Task<IList<T>> GetAll();

        Task<T> Update(T entity);

        Task<T> DeleteByKey(K key);

    }
}
