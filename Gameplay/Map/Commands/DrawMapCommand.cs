namespace AnimalFight;

public class DrawMapCommand : IMapCommand
{
    public void Execute(Map map)
    {
        map.InnerDrawMap();
    }
}