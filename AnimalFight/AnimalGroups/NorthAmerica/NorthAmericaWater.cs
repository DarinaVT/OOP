using AnimalFight;

public class NorthAmericaWater : GroupBase, INorthAmerica, IWaterHabitat
{
    public override ContinentType Continent => ContinentType.NorthAmerica;
    public override EnvironmentType Environment => EnvironmentType.Water;

    public NorthAmericaWater()
    {
        var habitat = new Animal.AnimalHabitat(Continent, Environment);

        Animals = new List<Animal>()
        {
            new Animal(new Animal.AnimalAppearance("Otter", "🦦"), new Animal.AnimalStats(5, 60), habitat),
            new Animal(new Animal.AnimalAppearance("Whale", "🐋"), new Animal.AnimalStats(10, 50), habitat),
            new Animal(new Animal.AnimalAppearance("Shark", "🦈"), new Animal.AnimalStats(9, 40), habitat),
            new Animal(new Animal.AnimalAppearance("Duck", "🦆"), new Animal.AnimalStats(4, 30), habitat)
        };
    }
    public override List<Animal> GetAnimals() => Animals;
}