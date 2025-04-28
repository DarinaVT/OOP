using AnimalFight;

public class MovePlayerManager : MapManager
{
    public override void Manage(IMapCommand command, Map map)
    {
        if (command is MovePlayerCommand moveCommand)
        {
            moveCommand.Execute(map);
        }
        else
        {
            _next?.Manage(command, map);
        }
    }
}