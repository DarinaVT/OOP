namespace BalloonPoppingGame;

public interface IBalloon
{
    int Coefficient { get; }
    BalloonType BalloonType { get; }
    bool Popped(Player player, int dartCoefficient);
}

public enum BalloonType
{
    Red,
    Blue,
    Black
}
