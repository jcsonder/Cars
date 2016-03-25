namespace Cars.DomainModel
{
    public class Truck : Car
    {
        public Truck()
        { }

        public Truck(string name, string model, string color)
            : base(name, model, color)
        { }

        public override string Drive()
        {
            return ("grrrrrrrrrrrr i'm a truck - " + Name);
        }
    }
}
