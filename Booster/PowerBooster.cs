using AnimalFight;

public class PowerBooster : Booster
{
    public int PowerPoints { get; }

    public PowerBooster(Position position, int boost = 2) : base("⚡", position)
    {
        PowerPoints = boost;
    }

    public override void ApplyBoost(Player player)
    {
        player.ApplyPowerBoost(PowerPoints);
    }
}