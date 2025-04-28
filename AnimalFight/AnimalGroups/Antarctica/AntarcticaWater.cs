using AnimalFight;

public class AntarcticaWater : GroupBase, IAntarctica, IWaterHabitat
{
    public override ContinentType Continent => ContinentType.Antarctica;
    public override EnvironmentType Environment => EnvironmentType.Water;

    public AntarcticaWater()
    {
        var habitat = new Animal.AnimalHabitat(Continent, Environment);

        Animals = new List<Animal>()
        {
            new Animal(new Animal.AnimalAppearance("Whale", "🐋"), new Animal.AnimalStats(12, 100), habitat),
            new Animal(new Animal.AnimalAppearance("Orca", "🐳"), new Animal.AnimalStats(11, 110), habitat),
            new Animal(new Animal.AnimalAppearance("Squid", "🦑"), new Animal.AnimalStats(9, 90), habitat),
            new Animal(new Animal.AnimalAppearance("Krill", "🦐"), new Animal.AnimalStats(7, 70), habitat),
            new Animal(new Animal.AnimalAppearance("Ice fish", "🐟"), new Animal.AnimalStats(5, 60), habitat)
        };
    }
    public override List<Animal> GetAnimals() => Animals;
}
