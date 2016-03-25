using Cars.Domain;
using Cars.DomainModel;
using Cars.Persistence.Helper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cars.Persistence
{
    public class CarRepository : AsyncRepository<ICar>
    {
        public CarRepository(IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
        }

        public Task CreateDummyDataAsync()
        {
            List<Task> tasks = new List<Task>();

            tasks.Add(Task.Factory.StartNew(() =>
            {
                Car car = new SportCar("Porsche", "356", "silver");
                base.CreateAsync(car);
                ////Task.Delay(2000).Wait();
            }));

            tasks.Add(Task.Factory.StartNew(() =>
            {
                Car car = new SportCar("VW", "Beetle", "purple");
                CreateAsync(car);
            }));

            tasks.Add(Task.Factory.StartNew(() =>
            {
                Car truck = new Truck("Ford", "F-350", "blue");
                CreateAsync(truck);
            }));

            return Task.WhenAll(tasks);
        }
    }
}
