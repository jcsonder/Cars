using Cars.DomainModel;
using System;
using System.Threading.Tasks;

namespace CarCollector
{
    interface ICarService
    {
        Task CreateDummyDataAsync();

        IObservable<Car> GetAll();
    }
}
