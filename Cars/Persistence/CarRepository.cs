using Cars.Domain;
using Cars.DomainModel;
using Cars.Persistence.Helper;

namespace Cars.Persistence
{
    public class CarRepository : Repository<ICar>
    {
        public CarRepository(IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
        }

        public void CreateDummyData()
        {
            Session.Save(new SportCar("Porsche", "356", "silver"));
            Session.Save(new SportCar("VW", "Beetle", "purple"));
            Session.Save(new Truck("Ford", "F-350", "blue"));
        }
    }
}
