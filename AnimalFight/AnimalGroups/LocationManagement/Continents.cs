namespace AnimalFight;
public interface IAfrica : IAnimalGroup
{
    ContinentType Continent => ContinentType.Africa;
};
public interface IAntarctica : IAnimalGroup 
{
    ContinentType Continent => ContinentType.Antarctica;
};
public interface IAsia : IAnimalGroup 
{
    ContinentType Continent => ContinentType.Asia;
};
public interface IEurope : IAnimalGroup 
{
    ContinentType Continent => ContinentType.Europe;
};
public interface INorthAmerica : IAnimalGroup 
{
    ContinentType Continent => ContinentType.NorthAmerica;
};
public interface IOceania : IAnimalGroup 
{
    ContinentType Continent => ContinentType.Oceania;
};
public interface ISouthAmerica : IAnimalGroup
{
    ContinentType Continent => ContinentType.SouthAmerica;
}
public enum ContinentType { Africa, Antarctica, Asia, Europe, NorthAmerica, Oceania, SouthAmerica }
