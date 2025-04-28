using AnimalFight;

public abstract class Booster
{
    public string Emoji { get; }
    public Position Position { get; set; }

    protected Booster(string emoji, Position position)
    {
        Emoji = emoji;
        Position = position;
    }

    public abstract void ApplyBoost(Player player);
}