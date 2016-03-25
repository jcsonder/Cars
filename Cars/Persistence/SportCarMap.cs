using Cars.DomainModel;
using FluentNHibernate.Mapping;

namespace Cars.Persistence
{
    public class SportCarMap : SubclassMap<SportCar>
    {
        public SportCarMap()
        {
            DiscriminatorValue(1);
        }
    }
}
