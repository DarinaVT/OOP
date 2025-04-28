using AnimalFight;

public class SouthAmericaWater : GroupBase, ISouthAmerica, IWaterHabitat
{
    public override ContinentType Continent => ContinentType.SouthAmerica;
    public override EnvironmentType Environment => EnvironmentType.Water;

    public SouthAmericaWater()
    {
        var habitat = new Animal.AnimalHabitat(Continent, Environment);

        Animals = new List<Animal>()
        {
            new Animal(new Animal.AnimalAppearance("Piranha", "🐟"), new Animal.AnimalStats(7, 80), habitat),
            new Animal(new Animal.AnimalAppearance("Turtle", "🐢"), new Animal.AnimalStats(6, 60), habitat),
            new Animal(new Animal.AnimalAppearance("Caiman", "🐊"), new Animal.AnimalStats(10, 90), habitat),
            new Animal(new Animal.AnimalAppearance("Amazon river dolphin", "🐬"), new Animal.AnimalStats(9, 70), habitat),
            new Animal(new Animal.AnimalAppearance("Fish", "🐟"), new Animal.AnimalStats(4, 50), habitat)
        };
    }
    public override List<Animal> GetAnimals() => Animals;
}