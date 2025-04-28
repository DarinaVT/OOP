using AnimalFight;

public class DrawMapManager : MapManager
{
    public override void Manage(IMapCommand command, Map map)
    {
        if (command is DrawMapCommand drawCommand)
        {
            drawCommand.Execute(map);
        }
        else
        {
            _next?.Manage(command, map);
        }
    }
}