using Cars.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Persistence
{
    public interface IAsyncRepository<T> 
        where T : IEntity
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(long id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(long id);
    }
}
