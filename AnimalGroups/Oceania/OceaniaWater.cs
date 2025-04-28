using AnimalFight;

public class OceaniaWater : GroupBase, IOceania, IWaterHabitat
{
    public override ContinentType Continent => ContinentType.Oceania;
    public override EnvironmentType Environment => EnvironmentType.Water;

    public OceaniaWater()
    {
        var habitat = new Animal.AnimalHabitat(Continent, Environment);

        Animals = new List<Animal>()
        {
            new Animal(new Animal.AnimalAppearance("Crocodile", "🐊"), new Animal.AnimalStats(10, 80), habitat),
            new Animal(new Animal.AnimalAppearance("Barrier reef shark", "🦈"), new Animal.AnimalStats(12, 100), habitat),
            new Animal(new Animal.AnimalAppearance("Tasmanian devil", "😈"), new Animal.AnimalStats(15, 90), habitat),
            new Animal(new Animal.AnimalAppearance("Sea turtle", "🐢"), new Animal.AnimalStats(8, 90), habitat),
            new Animal(new Animal.AnimalAppearance("Clownfish", "🐡"), new Animal.AnimalStats(6, 70), habitat)
        };
    }
    public override List<Animal> GetAnimals() => Animals;
}