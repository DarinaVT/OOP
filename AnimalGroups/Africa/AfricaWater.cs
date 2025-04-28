using AnimalFight;

public class AfricaWater : GroupBase, IAfrica, IWaterHabitat
{
    public override ContinentType Continent => ContinentType.Africa;
    public override EnvironmentType Environment => EnvironmentType.Water;

    public AfricaWater()
    {
        var habitat = new Animal.AnimalHabitat(Continent, Environment);

        Animals = new List<Animal>()
        {
            new Animal(new Animal.AnimalAppearance("Hippo", "🦛"), new Animal.AnimalStats(13, 100), habitat),
            new Animal(new Animal.AnimalAppearance("Crocodile", "🐊"), new Animal.AnimalStats(10, 110), habitat),
            new Animal(new Animal.AnimalAppearance("Tiger fish", "🐠"), new Animal.AnimalStats(2, 80), habitat),
            new Animal(new Animal.AnimalAppearance("Turtle", "🐢"), new Animal.AnimalStats(5, 90), habitat),
            new Animal(new Animal.AnimalAppearance("Shark", "🦈"), new Animal.AnimalStats(15, 150), habitat)
        };
    }
    public override List<Animal> GetAnimals() => Animals;
}
