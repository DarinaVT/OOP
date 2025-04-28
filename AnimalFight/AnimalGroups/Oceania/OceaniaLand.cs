using AnimalFight;

public class OceaniaLand : GroupBase, IOceania, ILandHabitat
{
    public override ContinentType Continent => ContinentType.Oceania;
    public override EnvironmentType Environment => EnvironmentType.Land;

    public OceaniaLand()
    {
        var habitat = new Animal.AnimalHabitat(Continent, Environment);

        Animals = new List<Animal>()
        {
            new Animal(new Animal.AnimalAppearance("Kangaroo", "🦘"), new Animal.AnimalStats(10, 80), habitat),
            new Animal(new Animal.AnimalAppearance("Koala", "🐨"), new Animal.AnimalStats(5, 70), habitat),
            new Animal(new Animal.AnimalAppearance("Tasmanian Devil", "😈"), new Animal.AnimalStats(15, 100), habitat),
            new Animal(new Animal.AnimalAppearance("Emu", "🐦"), new Animal.AnimalStats(7, 90), habitat),
            new Animal(new Animal.AnimalAppearance("Komodo dragon", "🦎"), new Animal.AnimalStats(8, 80), habitat)
        };
    }
    public override List<Animal> GetAnimals() => Animals;
}