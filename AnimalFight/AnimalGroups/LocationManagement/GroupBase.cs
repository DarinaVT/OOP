namespace AnimalFight
{
    public abstract class GroupBase : IAnimalGroup
    {
        public List<Animal> Animals { get; protected set; } = new List<Animal>();
        public abstract ContinentType Continent { get; }
        public abstract EnvironmentType Environment { get; }
        public virtual List<Animal> GetAnimals() => Animals;
    }
}