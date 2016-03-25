using Cars.DomainModel;
using Cars.Persistence;
using System;
using System.Threading.Tasks;

namespace Cars
{
    // todo: Create appropriate namespace
    public class DomainService
    {
        private readonly DataRepository _dataRepository;

        public DomainService()
        {
            _dataRepository = new DataRepository();
        }

        public async Task CreateCarsAsync()
        {
            await _dataRepository.CreateCarsAsync().ConfigureAwait(false);
        }

        public IObservable<Car> GetCars()
        {
            return _dataRepository.GetCars();
        }
    }
}
