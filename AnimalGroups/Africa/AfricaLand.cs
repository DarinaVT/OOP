using AnimalFight;

public class AfricaLand : GroupBase, IAfrica, ILandHabitat
{
    public override ContinentType Continent => ContinentType.Africa;
    public override EnvironmentType Environment => EnvironmentType.Land;

    public AfricaLand()
    {
        var habitat = new Animal.AnimalHabitat(Continent, Environment);

        Animals = new List<Animal>()
        {
            new Animal(new Animal.AnimalAppearance("Lion", "🦁"), new Animal.AnimalStats(15, 200), habitat),
            new Animal(new Animal.AnimalAppearance("Elephant", "🐘"), new Animal.AnimalStats(12, 120), habitat),
            new Animal(new Animal.AnimalAppearance("Rhino", "🦏"), new Animal.AnimalStats(10, 150), habitat),
            new Animal(new Animal.AnimalAppearance("Leopard", "🐆"), new Animal.AnimalStats(11, 130), habitat),
            new Animal(new Animal.AnimalAppearance("Zebra", "🦓"), new Animal.AnimalStats(7, 100), habitat)
        };
    }
    public override List<Animal> GetAnimals() => Animals;
}