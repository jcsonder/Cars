using Cars.DomainModel;
using FluentNHibernate.Mapping;

namespace Cars.Persistence.Map
{
    public class SportCarMap : SubclassMap<SportCar>
    {
        public SportCarMap()
        {
            DiscriminatorValue(1);
        }
    }
}
