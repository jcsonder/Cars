namespace Cars.Domain
{
    public interface ICar
    {
        long Id { get; }
        string Name { get; }
        string Model { get; }
        string Color { get; }
        string Drive();
    }
}
