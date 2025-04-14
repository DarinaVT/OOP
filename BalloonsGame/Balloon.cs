
namespace BalloonPoppingGame;

public abstract class Balloon : IBalloon
{
    public int Coefficient { get; }
    public BalloonType BalloonType { get; }
    protected Events GameEvent { get; }

    protected Balloon(int coefficient, BalloonType type, Events gameEvent)
    {
        Coefficient = coefficient;
        BalloonType = type;
        GameEvent = gameEvent;
    }

    public abstract bool Popped(Player player, int coefficient);
}
public class RedBalloon : Balloon
{
    public RedBalloon(int coefficient, BalloonType type, Events gameEvent) : base(coefficient, type, gameEvent) {}

    public override bool Popped(Player player, int dartCoefficient)
    {
        if (dartCoefficient <= Coefficient)
        {
            return false;
        }

        if (player.Name == "Red player")
        {
            player.AddPoints();
            GameEvent.PoppedBalloon(player, this);
            return true;
        }
        else
        {
            Game.Instance.RedPlayer.AddPoints();
            Console.WriteLine($"{player.Name} popped a {BalloonType} balloon");
            player.PoppedAmount(BalloonType);
        }

        return true;
    }
}

public class BlueBalloon : Balloon
{
    public BlueBalloon(int coefficient, BalloonType type, Events gameEvent) : base(coefficient, type, gameEvent) { }

    public override bool Popped(Player player, int dartCoefficient)
    {
        if (dartCoefficient <= Coefficient)
        {
            return false;
        }

        if (player.Name == "Blue player")
        {
            player.AddPoints();
            GameEvent.PoppedBalloon(player, this);
            return true;
        }
        else
        {
            Game.Instance.BluePlayer.AddPoints();
            Console.WriteLine($"{player.Name} popped a {BalloonType} balloon");
            player.PoppedAmount(BalloonType);
        }
        return true;
    }
}

public class BlackBalloon : Balloon
{
    public BlackBalloon(int coefficient, BalloonType type, Events gameEvent)
        : base(coefficient, type, gameEvent) { }

    public override bool Popped(Player player, int dartCoefficient)
    {
        if (dartCoefficient <= Coefficient)
        {
            return false;
        }

        player.MissNextTurn();
        GameEvent.PoppedBalloon(player, this);
        return true;
    }
}
