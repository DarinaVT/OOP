using AnimalFight;

public class AsiaWater : GroupBase, IAsia, IWaterHabitat
{
    public override ContinentType Continent => ContinentType.Asia;
    public override EnvironmentType Environment => EnvironmentType.Water;

    public AsiaWater()
    {
        var habitat = new Animal.AnimalHabitat(Continent, Environment);

        Animals = new List<Animal>()
        {
            new Animal(new Animal.AnimalAppearance("Dragon", "🐉"), new Animal.AnimalStats(12, 100), habitat),
            new Animal(new Animal.AnimalAppearance("Crab", "🦀"), new Animal.AnimalStats(8, 80), habitat),
            new Animal(new Animal.AnimalAppearance("Shrimp", "🦐"), new Animal.AnimalStats(5, 40), habitat),
            new Animal(new Animal.AnimalAppearance("Frog", "🐸"), new Animal.AnimalStats(6, 50), habitat),
            new Animal(new Animal.AnimalAppearance("Dolphin", "🐬"), new Animal.AnimalStats(10, 90), habitat)
        };
    }
    public override List<Animal> GetAnimals() => Animals;
}