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

        public async Task CreateDummyDataAsync()
        {
            await base.CreateAsync(new SportCar("Porsche", "356", "silver"));
            await base.CreateAsync(new SportCar("VW", "Beetle", "purple"));
            await base.CreateAsync(new Truck("Ford", "F-350", "blue"));
        }
    }
}
