using AnimalFight;

public class TileCommand : IMapCommand
{
    private readonly Position _position;
    public object Result { get; private set; }

    public TileCommand(Position position)
    {
        _position = position;
    }

    public void Execute(Map map)
    {
        Result = map.InnerTile(_position);
    }
}