namespace Cars.Persistence.Helper
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
    }
}
