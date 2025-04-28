using AnimalFight;

public class QuitCommand : GameManager
{
    public override bool Manage(ConsoleKey key, Game game)
    {
        if (key == ConsoleKey.Escape)
        {
            game.QuitGame = true;
            return true;
        }

        if (_next != null)
        {
            return _next.Manage(key, game);
        }

        return false;
    }
}
