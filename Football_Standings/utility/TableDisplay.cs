namespace Football_Standings;

public static class TableDisplay
{
    public static void PrintCurrentStandings(List<Team> teams)
    {
        // Sorting teams - refer to teams for algorithm
        teams.Sort();

        // Header
        Console.WriteLine(
            "Position | Special Mark | Club Name         | GP  |  W  |  D  |  L  | GF  | GA  | GD  | Pts  | Streak");
        Console.WriteLine(
            "---------|--------------|-------------------|-----|-----|-----|-----|-----|-----|-----|------|----------");

        // Each team's stats
        for (int i = 0; i < teams.Count; i++)
        {
            Console.WriteLine(
                $"{i + 1,-8} | {teams[i].SpecialRanking,-12} | {teams[i].Name,-17} | {teams[i].GamesPlayed,3} | {teams[i].Wins,3} | {teams[i].Draws,3} | {teams[i].Losses,3} | {teams[i].GoalsFor,3} | {teams[i].GoalsAgainst,3} | {teams[i].GoalDifference,3} | {teams[i].Points,4} | {teams[i].GetStreakDisplay(),-6}");
        }
    }

    public static void PrintCurrentStandings(List<Team> upper, List<Team> lower, LeagueOld? league)
    {
        List<Position> promotions = null;
        List<Position> relegations = null;

        if (league != null)
        {
            promotions = league.GetLeaguePromotions();
            relegations = league.GetLeagueRelegations();
        }


        // Sorting teams - refer to teams for algorithm
        upper.Sort();
        lower.Sort();

        // Header for the upper fraction
        Console.WriteLine("Upper Fraction Standings:");
        Console.WriteLine(
            "Position | Special Mark | Club Name         | GP  |  W  |  D  |  L  | GF  | GA  | GD  | Pts  | Streak    | Promotion |");
        Console.WriteLine(
            "---------|--------------|-------------------|-----|-----|-----|-----|-----|-----|-----|------|-----------| --------- |");

        // Display the upper fraction standings
        for (int i = 0; i < upper.Count; i++)
        {
            Console.Write(
                $"{i + 1,-8} | {upper[i].SpecialRanking,-12} | {upper[i].Name,-17} | {upper[i].GamesPlayed,3} | {upper[i].Wins,3} | {upper[i].Draws,3} | {upper[i].Losses,3} | {upper[i].GoalsFor,3} | {upper[i].GoalsAgainst,3} | {upper[i].GoalDifference,3} | {upper[i].Points,4} | {upper[i].GetStreakDisplay(),-9} |");

            // promotions
            if (promotions?.Count > 0)
            {
                Console.WriteLine($" {promotions[0].Name}");

                if (--promotions[0].Number <= 0)
                {
                    promotions.RemoveAt(0);
                }
            }
            else
            {
                Console.WriteLine("");
            }
        }

        // Header for the lower fraction
        Console.WriteLine("\nLower Fraction Standings:");
        Console.WriteLine(
            "Position | Special Mark | Club Name         | GP  |  W  |  D  |  L  | GF  | GA  | GD  | Pts  | Streak    | Relegation |");
        Console.WriteLine(
            "---------|--------------|-------------------|-----|-----|-----|-----|-----|-----|-----|------|-----------| ---------- |");

        // Display the lower fraction standings
        for (int i = 0; i < lower.Count; i++)
        {
            Console.Write(
                $"{i + 1,-8} | {lower[i].SpecialRanking,-12} | {lower[i].Name,-17} | {lower[i].GamesPlayed,3} | {lower[i].Wins,3} | {lower[i].Draws,3} | {lower[i].Losses,3} | {lower[i].GoalsFor,3} | {lower[i].GoalsAgainst,3} | {lower[i].GoalDifference,3} | {lower[i].Points,4} | {lower[i].GetStreakDisplay(),-9} |");

            // relegations ### todo not fixed for buttom up
            if (promotions?.Count > 0)
            {
                Console.WriteLine($" {promotions[0].Name}");

                if (--promotions[0].Number <= 0)
                {
                    promotions.RemoveAt(0);
                }
            }
            else
            {
                Console.WriteLine("");
            }
        }
        
        Console.WriteLine("upper");
        upper.ForEach(team => Console.WriteLine(team.Abbreviation));
        Console.WriteLine("lower");
        lower.ForEach(team => Console.WriteLine(team.Abbreviation));
    }
}