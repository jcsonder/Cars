using Cars.Domain;
using Cars.Persistence;
using System.Collections.Generic;

namespace Cars
{
    // todo: Create appropriate namespace
    public class CarService : ICarService
    {
        private readonly IRepository<ICar> _carRepository;

        public CarService(IRepository<ICar> carRepository)
        {
            _carRepository = carRepository;
        }

        public void CreateDummyData()
        {
            ((CarRepository)_carRepository).CreateDummyData();
        }

        public IList<ICar> GetAll()
        {
            return _carRepository.GetAll();
        }
    }
}
