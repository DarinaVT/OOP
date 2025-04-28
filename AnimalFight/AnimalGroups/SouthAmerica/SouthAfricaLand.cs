using AnimalFight;

public class SouthAmericaLand : GroupBase, ISouthAmerica, ILandHabitat
{
    public override ContinentType Continent => ContinentType.SouthAmerica;
    public override EnvironmentType Environment => EnvironmentType.Land;

    public SouthAmericaLand()
    {
        var habitat = new Animal.AnimalHabitat(Continent, Environment);

        Animals = new List<Animal>()
        {
            new Animal(new Animal.AnimalAppearance("Jaguar", "🐆"), new Animal.AnimalStats(15, 90), habitat),
            new Animal(new Animal.AnimalAppearance("Macaw", "🦜"), new Animal.AnimalStats(5, 50), habitat),
            new Animal(new Animal.AnimalAppearance("Sloth", "🦥"), new Animal.AnimalStats(7, 70), habitat),
            new Animal(new Animal.AnimalAppearance("Anaconda", "🐍"), new Animal.AnimalStats(13, 100), habitat),
            new Animal(new Animal.AnimalAppearance("Monkey", "🐒"), new Animal.AnimalStats(8, 80), habitat)
        };
    }
    public override List<Animal> GetAnimals() => Animals;
}