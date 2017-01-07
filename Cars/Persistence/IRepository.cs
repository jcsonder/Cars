using Cars.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cars.Persistence
{
    public interface IRepository<T> 
        where T : IEntity
    {
        IList<T> GetAll();
        T GetById(long id);
        void Create(T entity);
        void Update(T entity);
        void Delete(long id);
    }
}
