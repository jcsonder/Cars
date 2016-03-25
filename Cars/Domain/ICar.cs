namespace Cars.Domain
{
    public interface ICar : IEntity
    {
        string Name { get; }
        string Model { get; }
        string Color { get; }
        string Drive();
    }
}
