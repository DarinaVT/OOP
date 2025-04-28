using AnimalFight;

public abstract class GameManager
{
    protected GameManager _next;
    public GameManager SetNext(GameManager next)
    {
        _next = next;
        return next;
    }
    public abstract bool Manage(ConsoleKey key, Game game);
}