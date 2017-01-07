using Cars.Domain;
using System.Collections.Generic;

namespace Cars
{
    public interface ICarService
    {
        void CreateDummyData();

        IList<ICar> GetAll();
    }
}
