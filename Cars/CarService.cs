using Cars.Domain;
using Cars.Persistence;
using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace Cars
{
    // todo: Create appropriate namespace
    public class CarService : ICarService
    {
        private readonly IAsyncRepository<ICar> _carRepository;

        public CarService(IAsyncRepository<ICar> carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task CreateDummyDataAsync()
        {
            await ((CarRepository)_carRepository).CreateDummyDataAsync().ConfigureAwait(false);
        }

        public IObservable<ICar> GetAll()
        {
            return _carRepository.GetAll().ToObservable<ICar>();
        }
    }
}
