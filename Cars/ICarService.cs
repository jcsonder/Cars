using Cars.Domain;
using System;
using System.Threading.Tasks;

namespace Cars
{
    interface ICarService
    {
        Task CreateDummyDataAsync();

        IObservable<ICar> GetAll();
    }
}
