using AnimalFight;

public class HealthBooster : Booster
{
    public int HealthPoints { get; }

    public HealthBooster(Position position, int heal = 10) : base("❤️", position)
    {
        HealthPoints = heal;
    }

    public override void ApplyBoost(Player player)
    {
        player.ApplyHealthBoost(HealthPoints);
    }
}
