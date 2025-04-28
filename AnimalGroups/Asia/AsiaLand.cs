using AnimalFight;

public class AsiaLand : GroupBase, IAsia, ILandHabitat
{
    public override ContinentType Continent => ContinentType.Asia;
    public override EnvironmentType Environment => EnvironmentType.Land;

    public AsiaLand()
    {
        var habitat = new Animal.AnimalHabitat(Continent, Environment);

        Animals = new List<Animal>()
        {
            new Animal(new Animal.AnimalAppearance("Tiger", "🐅"), new Animal.AnimalStats(13, 100), habitat),
            new Animal(new Animal.AnimalAppearance("Panda", "🐼"), new Animal.AnimalStats(8, 80), habitat),
            new Animal(new Animal.AnimalAppearance("Monkey", "🐒"), new Animal.AnimalStats(7, 70), habitat),
            new Animal(new Animal.AnimalAppearance("Gorilla", "🦍"), new Animal.AnimalStats(11, 90), habitat),
            new Animal(new Animal.AnimalAppearance("Camel", "🐪"), new Animal.AnimalStats(10, 80), habitat)
        };
    }
    public override List<Animal> GetAnimals() => Animals;
}