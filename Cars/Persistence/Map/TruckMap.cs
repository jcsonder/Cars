using Cars.DomainModel;
using FluentNHibernate.Mapping;

namespace Cars.Persistence.Map
{
    public class TruckMap : SubclassMap<Truck>
    {
        public TruckMap()
        {
            DiscriminatorValue(2);
        }
    }
}
