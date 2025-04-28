using AnimalFight;

public class MovePlayerCommand : IMapCommand
{
    private readonly Position _position;

    public MovePlayerCommand(Position position)
    {
        _position = position;
    }

    public void Execute(Map map)
    {
        map.InnerMovePlayer(_position);
    }
}