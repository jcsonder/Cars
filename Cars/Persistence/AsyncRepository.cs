using Cars.Domain;
using Cars.Persistence.Helper;
using NHibernate;
using NHibernate.Linq;
using System.Linq;
using System.Threading.Tasks;

namespace Cars.Persistence
{
    public class AsyncRepository<T> : IAsyncRepository<T> where T : IEntity
    {
        private UnitOfWork _unitOfWork;
        public AsyncRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        protected ISession Session { get { return _unitOfWork.Session; } }

        public IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public Task<T> GetByIdAsync(long id)
        {
            return Task.Factory.StartNew(() => Session.Get<T>(id));
        }

        public Task CreateAsync(T entity)
        {
            return Task.Factory.StartNew(() => Session.Save(entity));
        }

        public Task UpdateAsync(T entity)
        {
            return Task.Factory.StartNew(() => Session.Update(entity));
        }

        public Task DeleteAsync(long id)
        {
            return Task.Factory.StartNew(() => Session.Delete(Session.Load<T>(id)));
        }
    }
}
