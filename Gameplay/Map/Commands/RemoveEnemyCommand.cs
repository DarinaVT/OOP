using AnimalFight;

public class RemoveEnemyCommand : IMapCommand
{
    private readonly Position _position;

    public RemoveEnemyCommand(Position position)
    {
        _position = position;
    }

    public void Execute(Map map)
    {
        map.InnerRemoveEnemy(_position);
    }
}