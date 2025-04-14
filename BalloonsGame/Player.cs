
namespace BalloonPoppingGame;
public abstract class Player
{
    public string Name { get; set; }
    public int Score { get; set; }
    public bool MissTurn { get; set; }
    public int RedPopped { get; set; }
    public int BluePopped { get; set; }
    public int BlackPopped { get; set; }

    public void AddPoints()
    {
        Score++;
    }

    public void MissNextTurn()
    {
        MissTurn = true;
    }

    public void PoppedAmount(BalloonType type)
    {
        switch (type)
        {
            case BalloonType.Red:
                RedPopped++;
                break;
            case BalloonType.Blue:
                BluePopped++;
                break;
            case BalloonType.Black:
                BlackPopped++;
                break;
        }
    }

    public int TotalPopped()
    {
        return RedPopped + BluePopped + BlackPopped;
    }
}
public class RedPlayer : Player
{
    public RedPlayer()
    {
        Name = "Red player";
    }
}

public class BluePlayer : Player
{
    public BluePlayer()
    {
        Name = "Blue player";
    }
}
