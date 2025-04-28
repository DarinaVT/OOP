using AnimalFight;
using System.Xml.Linq;
public class Animal
{
    public string Name { get; }
    public string Emoji { get; }
    public int Power { get; set; }
    public int Life { get; set; }
    public Position Position { get; set; }
    public ContinentType Continent { get; }
    public EnvironmentType Environment { get; }
    public int MaxLife { get; }
    public int MaxPower { get; }

    public Animal(AnimalAppearance appearance, AnimalStats stats, AnimalHabitat habitat)
    {
        Name = appearance.Name;
        Emoji = appearance.Emoji;
        Power = stats.Power;
        MaxPower = stats.Power;
        Life = stats.Life;
        MaxLife = stats.Life;
        Continent = habitat.Continent;
        Environment = habitat.Environment;
        Position = new Position(0, 0);
    }
    public class AnimalAppearance
    {
        public string Name { get; }
        public string Emoji { get; }

        public AnimalAppearance(string name, string emoji)
        {
            Name = name;
            Emoji = emoji;
        }
    }

    public class AnimalStats
    {
        public int Power { get; set; }
        public int Life { get; set; }

        public AnimalStats(int power, int life)
        {
            Power = power;
            Life = life;
        }
    }

    public class AnimalHabitat
    {
        public ContinentType Continent { get; }
        public EnvironmentType Environment { get; }

        public AnimalHabitat(ContinentType continent, EnvironmentType environment)
        {
            Continent = continent;
            Environment = environment;
        }
    }
    public Animal AddAnimal(Position position)
    {
        return new Animal(new AnimalAppearance(Name, Emoji), new AnimalStats(Power, Life), new AnimalHabitat(Continent, Environment))
        {
            Position = position
        };
    }
}