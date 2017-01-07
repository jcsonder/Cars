using Cars.Domain;
using System.Collections.Generic;

namespace Cars
{
    interface ICarService
    {
        void CreateDummyData();

        IList<ICar> GetAll();
    }
}
