using AnimalFight;

public class SpawnItemsCommand : IMapCommand
{
    public void Execute(Map map)
    {
        map.InnerSpawnItems();
    }
}