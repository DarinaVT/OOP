using System.Collections.Generic;

namespace FootballTournament;

public class TeamData : IData
{
    public string Name { get; set; }
    public int MP { get; set; }
    public int W { get; set; }
    public int D { get; set; }
    public int L { get; set; }
    public int P { get; set; }
    public TeamData(string name)
    {
        Name = name;
        MP = W = D = L = P = 0;
    }

    public void RecordMatch(string result)
    {
        MP++;
        switch(result)
        {
            case "win":
                W++; 
                P += 3;  
                break;
            case "loss":
                L++; 
                break;
            case "draw":
                D++;
                P++; 
                break;
        }
    }
    public void PrintData()
    {
        Console.WriteLine($"{Name, -30} | {MP, 2} | {W, 2} | {D, 2} | {L, 2} | {P, 2} |");
    }
}
