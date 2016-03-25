namespace Cars.DomainModel
{
    public class SportCar : Car
    {
        public SportCar()
        { }

        public SportCar(string name, string model, string color)
            : base(name, model, color)
        { }

        public override string Drive()
        {
            return ("vroooomvroooomvroooomvroooom i'm a sports car - " + Name);
        }
    }
}
