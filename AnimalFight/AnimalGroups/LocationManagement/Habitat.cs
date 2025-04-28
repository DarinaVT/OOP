namespace AnimalFight;
public interface ILandHabitat : IAnimalGroup
{
    EnvironmentType Environment => EnvironmentType.Land;
};
public interface IWaterHabitat : IAnimalGroup
{
    EnvironmentType Environment => EnvironmentType.Water;
};
public enum EnvironmentType { Land, Water }
