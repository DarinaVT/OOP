using AnimalFight;

public class EuropeWater : GroupBase, IEurope, IWaterHabitat
{
    public override ContinentType Continent => ContinentType.Europe;
    public override EnvironmentType Environment => EnvironmentType.Water;

    public EuropeWater()
    {
        var habitat = new Animal.AnimalHabitat(Continent, Environment);

        Animals = new List<Animal>()
        {
            new Animal(new Animal.AnimalAppearance("Seal", "🦭"), new Animal.AnimalStats(9, 80), habitat),
            new Animal(new Animal.AnimalAppearance("Dolphin", "🐬"), new Animal.AnimalStats(7, 70), habitat),
            new Animal(new Animal.AnimalAppearance("Swan", "🦢"), new Animal.AnimalStats(5, 60), habitat),
            new Animal(new Animal.AnimalAppearance("Fish", "🐟"), new Animal.AnimalStats(3, 30), habitat),
            new Animal(new Animal.AnimalAppearance("Otter", "🦦"), new Animal.AnimalStats(10, 90), habitat)
        };
    }
    public override List<Animal> GetAnimals() => Animals;
}