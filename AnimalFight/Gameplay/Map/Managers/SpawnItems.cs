
using AnimalFight;

public class SpawnItemsManager : MapManager
{
    public override void Manage(IMapCommand command, Map map)
    {
        if (command is SpawnItemsCommand spawnCommand)
        {
            spawnCommand.Execute(map);
        }
        else
        {
            _next?.Manage(command, map);
        }
    }
}