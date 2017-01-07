using Cars.Controls;
using Cars.Domain;
using Cars.Persistence;
using Cars.Persistence.Helper;
using Ninject.Modules;

namespace Cars
{
    public class CarsModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICarService>().To<CarService>();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IRepository<ICar>>().To<CarRepository>();
            Bind<ICarsViewModel>().To<CarsViewModel>();
        }
    }
}
