using AnimalFight;

public class TileManager : MapManager
{
    public override void Manage(IMapCommand command, Map map)
    {
        if (command is TileCommand tileCommand)
        {
            tileCommand.Execute(map);
        }
        else
        {
            _next?.Manage(command, map);
        }
    }
}