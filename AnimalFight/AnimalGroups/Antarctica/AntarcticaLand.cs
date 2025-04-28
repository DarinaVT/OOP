using AnimalFight;

public class AntarcticaLand : GroupBase, IAntarctica, ILandHabitat
{
    public override ContinentType Continent => ContinentType.Antarctica;
    public override EnvironmentType Environment => EnvironmentType.Land;

    public AntarcticaLand()
    {
        var habitat = new Animal.AnimalHabitat(Continent, Environment);

        Animals = new List<Animal>()
        {
            new Animal(new Animal.AnimalAppearance("Emperor penguin", "🐧"), new Animal.AnimalStats(8, 80), habitat),
            new Animal(new Animal.AnimalAppearance("Seal", "🦭"), new Animal.AnimalStats(9, 70), habitat),
            new Animal(new Animal.AnimalAppearance("Polar Bear", "🐻‍"), new Animal.AnimalStats(15, 110), habitat),
            new Animal(new Animal.AnimalAppearance("Antarctic fox", "🦊"), new Animal.AnimalStats(12, 100), habitat),
            new Animal(new Animal.AnimalAppearance("Petrel", "🐦"), new Animal.AnimalStats(7, 60), habitat)
        };
    }
    public override List<Animal> GetAnimals() => Animals;
}