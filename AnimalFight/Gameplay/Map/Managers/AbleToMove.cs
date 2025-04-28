using AnimalFight;

public class AbleToMoveManager : MapManager
{
    public override void Manage(IMapCommand command, Map map)
    {
        if (command is AbleToMoveCommand moveCommand)
        {
            moveCommand.Execute(map);
        }
        else
        {
            _next?.Manage(command, map);
        }
    }
}