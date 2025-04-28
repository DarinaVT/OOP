using AnimalFight;

public class EuropeLand : GroupBase, IEurope, ILandHabitat
{
    public override ContinentType Continent => ContinentType.Europe;
    public override EnvironmentType Environment => EnvironmentType.Land;

    public EuropeLand()
    {
        var habitat = new Animal.AnimalHabitat(Continent, Environment);

        Animals = new List<Animal>()
        {
            new Animal(new Animal.AnimalAppearance("Boar", "🐗"), new Animal.AnimalStats(10, 90), habitat),
            new Animal(new Animal.AnimalAppearance("Fox", "🦊"), new Animal.AnimalStats(8, 80), habitat),
            new Animal(new Animal.AnimalAppearance("Rabbit", "🐇"), new Animal.AnimalStats(3, 40), habitat),
            new Animal(new Animal.AnimalAppearance("Hedgehog", "🦔"), new Animal.AnimalStats(6, 50), habitat),
            new Animal(new Animal.AnimalAppearance("Wolf", "🐺"), new Animal.AnimalStats(12, 100), habitat)
        };
    }
    public override List<Animal> GetAnimals() => Animals;
}