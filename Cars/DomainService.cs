using CarCollector;
using CarCollector.Persistence;
using Cars.DomainModel;
using Cars.Persistence;
using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Cars
{
    // todo: Create appropriate namespace
    public class CarService : ICarService
    {
        private readonly IAsyncRepository<Car> _carRepository;

        public CarService(IAsyncRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task CreateDummyDataAsync()
        {
            await ((CarRepository)_carRepository).CreateDummyDataAsync().ConfigureAwait(false);
        }

        public IObservable<Car> GetAll()
        {
            return _carRepository.GetAll().ToObservable<Car>();
        }
    }
}
