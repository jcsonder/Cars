using Cars.DomainModel;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System.IO;

namespace Cars.Persistence.Helper
{
    public class NHibernateHelper
    {
        const string DbFileName = "Cars.sqlite";

        public static ISessionFactory CreateSessionFactory()
        {
            return Fluently.Configure()
              .Database(
                SQLiteConfiguration.Standard
                  .UsingFile(DbFileName)
              )
              .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Car>())
              .ExposeConfiguration(BuildSchema)
              .BuildSessionFactory();
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
