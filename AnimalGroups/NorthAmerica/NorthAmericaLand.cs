using AnimalFight;

public class NorthAmericaLand : GroupBase, INorthAmerica, ILandHabitat
{
    public override ContinentType Continent => ContinentType.NorthAmerica;
    public override EnvironmentType Environment => EnvironmentType.Land;

    public NorthAmericaLand()
    {
        var habitat = new Animal.AnimalHabitat(Continent, Environment);

        Animals = new List<Animal>()
        {
            new Animal(new Animal.AnimalAppearance("Grizzly bear", "🐻"), new Animal.AnimalStats(15, 110), habitat),
            new Animal(new Animal.AnimalAppearance("Wolf", "🐺"), new Animal.AnimalStats(17, 100), habitat),
            new Animal(new Animal.AnimalAppearance("Bison", "🐃"), new Animal.AnimalStats(10, 80), habitat),
            new Animal(new Animal.AnimalAppearance("Eagle", "🦅"), new Animal.AnimalStats(8, 70), habitat),
            new Animal(new Animal.AnimalAppearance("Moose", "🫎"), new Animal.AnimalStats(12, 90), habitat)
        };
    }
    public override List<Animal> GetAnimals() => Animals;
}