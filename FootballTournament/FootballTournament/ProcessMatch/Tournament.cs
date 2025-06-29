namespace FootballTournament;

public class Tournament : ITable
{
    private Dictionary<string, TeamData> _teams = new();
    private TeamData GetOrAddTeam(string teamName)
    {
        if (!_teams.ContainsKey(teamName))
        {
            _teams[teamName] = new TeamData(teamName);
        }
        return _teams[teamName];
    }

    public void MatchResult(string match)
    {
        var parts = match.Split(';');
        var firstTeam = GetOrAddTeam(parts[0]);
        var secondTeam = GetOrAddTeam(parts[1]);
        var result = parts[2];

        switch (result)
        {
            case "win":
                firstTeam.RecordMatch("win");
                secondTeam.RecordMatch("loss");
                break;
            case "loss":
                firstTeam.RecordMatch("loss");
                secondTeam.RecordMatch("win");
                break;
            case "draw":
                firstTeam.RecordMatch("draw");
                secondTeam.RecordMatch("draw");
                break;
        }
    }
    public void PrintTable()
    {
        Console.WriteLine("Team                           | MP |  W |  D |  L |  P |");
        var sortedTeams = _teams.Values.OrderByDescending(mp => mp.MP).ThenByDescending(p => p.P);
        foreach(var team in sortedTeams)
        {
            team.PrintData();
        }
    }
}