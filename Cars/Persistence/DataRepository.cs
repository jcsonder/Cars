using Cars.DomainModel;
using Cars.Persistence.Helper;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Cars.Persistence
{
    public class DataRepository
    {
        ISessionFactory _sessionFactory = null;
        ISession _session = null;

        public DataRepository()
        {
            _sessionFactory = NHibernateHelper.CreateSessionFactory();
            _session = _sessionFactory.OpenSession();
        }

        public Task CreateCarsAsync()
        {
            List<Task> tasks = new List<Task>();

            tasks.Add(Task.Factory.StartNew(() =>
            {
                Car car = new SportCar("Porsche", "356", "silver");
                SaveCar(car);
                ////Task.Delay(2000).Wait();
            }));

            tasks.Add(Task.Factory.StartNew(() =>
            {
                Car car = new SportCar("VW", "Beetle", "purple");
                SaveCar(car);
                ////Task.Delay(2000).Wait();
            }));

            tasks.Add(Task.Factory.StartNew(() =>
            {
                Car truck = new Truck("Ford", "F-350", "blue");
                SaveCar(truck);
                ////Task.Delay(2000).Wait();
            }));

            return Task.WhenAll(tasks);
        }

        public IObservable<Car> GetCars()
        {
            return QueryCars();
        }

        private void SaveCar(Car car)
        {
            using (ISession session = _sessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Save(car);
                transaction.Commit();
            }
        }

        private IObservable<Car> QueryCars()
        {
            // todo: How does this work without keeping the session?
            return _session.Query<Car>().ToObservable<Car>();
        }    
    }
}
