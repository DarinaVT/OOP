using AnimalFight;

public static class AnimalDivision
{
    public static IAnimalGroup? AnimalList(ContinentType continent, EnvironmentType environment)
    {
        return (continent, environment) switch
        {
            (ContinentType.Africa, EnvironmentType.Land) => new AfricaLand(),
            (ContinentType.Africa, EnvironmentType.Water) => new AfricaWater(),

            (ContinentType.Asia, EnvironmentType.Land) => new AsiaLand(),
            (ContinentType.Asia, EnvironmentType.Water) => new AsiaWater(),

            (ContinentType.SouthAmerica, EnvironmentType.Land) => new SouthAmericaLand(),
            (ContinentType.SouthAmerica, EnvironmentType.Water) => new SouthAmericaWater(),

            (ContinentType.Europe, EnvironmentType.Land) => new EuropeLand(),
            (ContinentType.Europe, EnvironmentType.Water) => new EuropeWater(),

            (ContinentType.Antarctica, EnvironmentType.Land) => new AntarcticaLand(),
            (ContinentType.Antarctica, EnvironmentType.Water) => new AntarcticaWater(),

            (ContinentType.Oceania, EnvironmentType.Land) => new OceaniaLand(),
            (ContinentType.Oceania,EnvironmentType.Water) => new OceaniaWater(),

            (ContinentType.NorthAmerica , EnvironmentType.Land) => new NorthAmericaLand(),
            (ContinentType.NorthAmerica, EnvironmentType.Water) => new NorthAmericaLand(),

            _ => null
        };
    }
}