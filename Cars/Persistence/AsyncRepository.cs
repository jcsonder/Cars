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

        public async Task<T> GetByIdAsync(long id)
        {
            // todo: return await ???
            return await Task.Factory.StartNew(() => Session.Get<T>(id));
        }

        public async Task CreateAsync(T entity)
        {
            await Task.Factory.StartNew(() => Session.Save(entity));
        }

        public async Task UpdateAsync(T entity)
        {
            await Task.Factory.StartNew(() => Session.Update(entity));
        }

        public async Task DeleteAsync(long id)
        {
            await Task.Factory.StartNew(() => Session.Delete(Session.Load<T>(id)));
        }
    }
}
