using FluentNHibernate.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CarCollector.Persistence
{
    public interface IAsyncRepository<T> where T : Entity
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(long id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(long id);
    }
}
