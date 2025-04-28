using AnimalFight;
public abstract class MapManager
{
    protected MapManager _next;

    public void SetNext(MapManager next)
    {
        _next = next;
    }

    public abstract void Manage(IMapCommand command, Map map);
}