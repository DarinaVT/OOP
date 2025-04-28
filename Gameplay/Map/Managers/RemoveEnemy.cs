using AnimalFight;

public class RemoveEnemyManager : MapManager
{
    public override void Manage(IMapCommand command, Map map)
    {
        if (command is RemoveEnemyCommand removeCommand)
        {
            removeCommand.Execute(map);
        }
        else
        {
            _next?.Manage(command, map);
        }
    }
}