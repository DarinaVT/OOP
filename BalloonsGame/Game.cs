namespace BalloonPoppingGame;

public class Game
{
    private static Game _instance;
    public static Game Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new Game();
            }
            return _instance;
        }
    }
    private Bonus _bonusPoints = new Bonus();
    public RedPlayer RedPlayer { get; }
    public BluePlayer BluePlayer { get; }
    public List<IBalloon> Balloons { get; private set; }
    private Random Random { get; }
    private Events Event { get; }

   
    private Game()
    {
        Event = new Events();
        RedPlayer = new RedPlayer();
        BluePlayer = new BluePlayer();
        Balloons = new List<IBalloon>();
        Random = new Random();
    }

    public void Initialise(int totalBalloons)
    {
        Balloons = new List<IBalloon>();
        RedPlayer.MissTurn = false;
        BluePlayer.MissTurn = false;
        RedPlayer.Score = 0;
        BluePlayer.Score = 0;
        RedPlayer.RedPopped = 0;
        RedPlayer.BluePopped = 0;
        RedPlayer.BlackPopped = 0;
        BluePlayer.RedPopped = 0;
        BluePlayer.BluePopped = 0;
        BluePlayer.BlackPopped = 0;

        int coloredBalloons = totalBalloons * 2 / 3;
        int blackBalloons = totalBalloons - coloredBalloons;

        for (int i = 0; i < coloredBalloons; i++)
        {
            Balloons.Add(new RedBalloon(Random.Next(1, 51), BalloonType.Red, Event));
            Balloons.Add(new BlueBalloon(Random.Next(1, 51), BalloonType.Blue, Event));
        }

        for (int i = 0; i < blackBalloons; i++)
        {
            Balloons.Add(new BlackBalloon(Random.Next(1, 51), BalloonType.Black, Event));
        }
    }

    public void Round()
    {
        if (RedPlayer.MissTurn)
        {
            Console.WriteLine($"{RedPlayer.Name} misses a turn");
            RedPlayer.MissTurn = false;
        }
        else
        {
            TakeTurn(RedPlayer);
            if (Balloons.Count == 0) return;
        }

        if (BluePlayer.MissTurn)
        {
            Console.WriteLine($"{BluePlayer.Name} misses a turn");
            BluePlayer.MissTurn = false;
        }
        else
        {
            TakeTurn(BluePlayer);
        }
    }

    private void TakeTurn(Player player)
    {

        if (Balloons.Count == 0)
        {
            return;
        }
        int index = Random.Next(Balloons.Count);
        IBalloon balloon = Balloons[index];
        int dartCoefficient = Random.Next(1, 51);
        dartCoefficient = _bonusPoints.AddBonus(dartCoefficient);

        if (balloon.Popped(player, dartCoefficient))
        {
            Balloons.RemoveAt(index);
        }
    }

    public void ShowStatistics()
    {
        Event.FinalResults(RedPlayer, BluePlayer);
    }
}
