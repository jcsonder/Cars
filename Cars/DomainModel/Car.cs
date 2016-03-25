using Cars.Domain;
using FluentNHibernate.Data;

namespace Cars.DomainModel
{
    public abstract class Car : Entity, ICar
    {
        private string _name;
        private string _model;
        private string _color;

        /// <summary>
        /// Empty constructor for NHibernate
        /// </summary>
        public Car()
        {
        }

        public Car(string name, string model, string color)
        {
            _name = name;
            _model = model;
            _color = color;
        }

        public virtual string Name { get { return _name; } }
        public virtual string Model { get { return _model; } }
        public virtual string Color { get { return _color; } }

        public abstract string Drive();

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}-{3}", Id, Name, Model, Color);
        }
    }
}
