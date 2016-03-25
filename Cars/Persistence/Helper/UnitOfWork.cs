using Cars.DomainModel;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.IO;

namespace Cars.Persistence.Helper
{
    public class UnitOfWork : IUnitOfWork
    {
        const string DbFileName = "Cars.sqlite";

        private static readonly ISessionFactory _sessionFactory;
        private ITransaction _transaction;

        public ISession Session { get; set; }

        static UnitOfWork()
        {
            _sessionFactory = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile(DbFileName)                          )
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Car>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
        }

        public UnitOfWork()
        {
            Session = _sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                Session.Close();
            }
        }

        private static void BuildSchema(Configuration config)
        {
            if (!File.Exists(DbFileName))
            {
                new SchemaExport(config)
                  .Create(false, true);
            }
            else
            {
                FileInfo info = new FileInfo(DbFileName);
                long size = info.Length;
                if (size == 0)
                {
                    new SchemaExport(config).Create(false, true);
                }
            }
        }
    }
}
