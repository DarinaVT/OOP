namespace AnimalFight;

public interface IAnimalGroup
{
    List<Animal> Animals { get; }
    abstract List<Animal> GetAnimals();
    public ContinentType Continent { get; }
    public EnvironmentType Environment { get; }
}
