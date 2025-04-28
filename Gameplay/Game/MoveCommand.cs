using AnimalFight;

class MoveCommand : GameManager
{
    public override bool Manage(ConsoleKey key, Game game)
    {
        var direction = game.GetDirectionFromKey(key);
        if(direction != Direction.None && !game.InCombat)
        {
            game.Move(direction);
            return true;
        }
        if (_next != null)
        {
            return _next.Manage(key, game);
        }
        else
        {
            return false;
        }
    }
}
