using AnimalFight;

public class AbleToMoveCommand : IMapCommand
{
    private readonly Position _position;
    public bool CanMove { get; private set; }

    public AbleToMoveCommand(Position position)
    {
        _position = position;
    }

    public void Execute(Map map)
    {
        CanMove = map.InnerAbleToMove(_position);
    }
}