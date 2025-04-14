using System;
using System.Collections.Generic;
using BalloonPoppingGame;
class Program
{
    public static void Main()
    {
        Game game = Game.Instance;
        game.Initialise(20);

        Console.WriteLine("Balloon popping game");
        
        int maxRounds = 20;
        int round = 0;

        while (game.Balloons.Count > 0 && round < maxRounds)
        {
            Console.WriteLine($"Round {round + 1}");
            game.Round();
            round++;
            Console.WriteLine();
            Thread.Sleep(1500);
        }

        if (round >= maxRounds)
        {
            Console.WriteLine("Maximum rounds reached - ending game");
        }

        Console.WriteLine("Game over");
        game.ShowStatistics();
    }
}
