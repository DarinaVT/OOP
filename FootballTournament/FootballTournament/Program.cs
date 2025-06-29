using FootballTournament;

class Program
{
    public static void Main(string[] args)
    {
        var tournament = new Tournament();
        tournament.MatchResult("Allegoric Alaskans;Blithering Badgers;win");
        tournament.MatchResult("Devastating Donkeys;Courageous Californians;draw");
        tournament.MatchResult("Devastating Donkeys;Allegoric Alaskans;win");
        tournament.MatchResult("Courageous Californians;Blithering Badgers;loss");
        tournament.MatchResult("Blithering Badgers;Devastating Donkeys;loss");
        tournament.MatchResult("Allegoric Alaskans;Courageous Californians;win");
        tournament.PrintTable();
    }
}