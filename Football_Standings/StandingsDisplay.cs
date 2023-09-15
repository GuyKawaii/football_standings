namespace Football_Standings;

public static class StandingsDisplay
{
    public static void PrintCurrentStandings(List<Team> teams)
    {
        // Sorting teams - refer to teams for algorithm
        teams.Sort();

        // Header
        Console.WriteLine("Position | Special Mark | Club Name         | GP  |  W  |  D  |  L  | GF  | GA  | GD  | Pts  | Streak");
        Console.WriteLine("---------|--------------|-------------------|-----|-----|-----|-----|-----|-----|-----|------|-------");

        // Each team's stats
        for (int i = 0; i < teams.Count; i++)
        {
            Console.WriteLine($"{i + 1, -8} | {teams[i].SpecialRanking, -12} | {teams[i].Name, -17} | {teams[i].GamesPlayed, 3} | {teams[i].Wins, 3} | {teams[i].Draws, 3} | {teams[i].Losses, 3} | {teams[i].GoalsFor, 3} | {teams[i].GoalsAgainst, 3} | {teams[i].GoalDifference, 3} | {teams[i].Points, 4} | {teams[i].GetStreakDisplay(), -6}");
        }
    }
}