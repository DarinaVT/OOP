
namespace BalloonPoppingGame;

public class Events
{
    public void PoppedBalloon(Player player, IBalloon balloon)
    {
        Console.WriteLine($"{player.Name} popped a {balloon.BalloonType} balloon");
        player.PoppedAmount(balloon.BalloonType);

        if (balloon.BalloonType == BalloonType.Black)
        {
            Console.WriteLine($"{player.Name} will miss a turn");
        }
    }

    private void PlayerStats(Player player)
    {
        Console.WriteLine($"{player.Name} - {player.Score}");
    }

    private void Winner(Player redPlayer, Player bluePlayer)
    {
        if (redPlayer.Score > bluePlayer.Score)
        {
            Console.WriteLine($"The winner is {redPlayer.Name}");
        }
        else if (redPlayer.Score < bluePlayer.Score)
        {
            Console.WriteLine($"The winner is {bluePlayer.Name}");
        }
        else
        {
            Console.WriteLine("It's a draw");
        }
    }

    public void FinalResults(Player redPlayer, Player bluePlayer)
    {
        Console.WriteLine("Final result:");
        PlayerStats(redPlayer);
        PlayerStats(bluePlayer);
        Winner(redPlayer, bluePlayer);
    }
}
