using System.Diagnostics.Metrics;
using Football_Standings.Exceptions;

namespace Football_Standings;

public static class RoundProcessor
{
    static string _rootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

    public static void ProcessLeague(Dictionary<string, Team> dictTeams, League league, string filepath)
    {
        // display initial
        List<Team> teams = dictTeams.Values.ToList();
        Console.WriteLine("#####################");
        Console.WriteLine("### Initial setup ###");
        Console.WriteLine("#####################");
        TableDisplay.PrintCurrentStandings(teams);


        // all teams play eachother
        for (int i = 1; i <= 22; i++)
        {
            String completePath = Path.Combine(_rootDir, filepath, $"round-{i}.csv");

            ProcessRound(dictTeams, completePath);
        }

        // create fractions - reset opponents
        teams.Sort();
        teams.ForEach(team => team.ResetOpponents());

        List<Team> upperFraction = teams.GetRange(0, 6);
        List<Team> lowerFraction = teams.GetRange(6, 6);
        Dictionary<string, Team> upperFractionDict =
            upperFraction.ToDictionary(team => team.Abbreviation, team => team);
        Dictionary<string, Team> lowerFractionDict =
            lowerFraction.ToDictionary(team => team.Abbreviation, team => team);

        // set special rankings
        // LeagueOld league = new LeagueOld("lala", 2, 1, 1, 1, 2);
        teams.ForEach(team =>
            team.SpecialRanking =
                (team.SpecialRanking == "R" || team.SpecialRanking == "P") ? "" : team.SpecialRanking);

        // get promotions
        // int totalPromotions = league.GetLeaguePromotions().Sum(position => position.Number);
        // int totalRelegations = league.GetLeagueRelegations().Sum(position => position.Number);

        // display initial fractions
        Console.WriteLine("");
        Console.WriteLine("######################################");
        Console.WriteLine("### Rankings after first 22 rounds ###");
        Console.WriteLine("######################################");
        TableDisplay.PrintCurrentStandings(upperFraction, lowerFraction, null);

        // each fraction play each other
        for (int i = 23; i <= 32; i++)
        {
            String completePath = Path.Combine(_rootDir, filepath, $"round-{i}.csv");

            ProcessRound(upperFractionDict, completePath);
            ProcessRound(lowerFractionDict, completePath);
        }

        // display final standings
        Console.WriteLine("");
        Console.WriteLine("######################################");
        Console.WriteLine("### FINAL Rankings after 32 rounds ###");
        Console.WriteLine("######################################");
        TableDisplay.PrintCurrentStandings(upperFraction, lowerFraction, league);
    }

    public static void ProcessRound(Dictionary<string, Team> dictTeams, string filepath)
    {
        using (var reader = new StreamReader(filepath))
        {
            // Discard the header
            reader.ReadLine();

            // Read rows
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();

                var values = line.Split(',');

                // discard invalid team match-up
                if (!dictTeams.ContainsKey(values[0]) || !dictTeams.ContainsKey(values[2]))
                {
                    continue;
                }

                // if (teamMap.ContainsKey(values[0]) && teamMap.ContainsKey(values[2]))
                Team home = dictTeams[values[0]];
                Team away = dictTeams[values[2]];

                int homePoints = int.Parse(values[1]);
                int awayPoints = int.Parse(values[3]);


                // check for match restrictions
                if (away.Abbreviation == home.Abbreviation)
                {
                    throw new SameTeamException($"{home.Abbreviation} in file:{filepath}");
                }

                if (away.HasPlayed(home.Abbreviation, MatchLocation.Outer) ||
                    home.HasPlayed(away.Abbreviation, MatchLocation.Home))
                {
                    throw new DuplicateTeamException($"{home.Abbreviation} vs {away.Abbreviation} in file:{filepath}");
                }


                home.UpdateMatchResult(away.Abbreviation, homePoints, awayPoints, MatchLocation.Home);
                away.UpdateMatchResult(home.Abbreviation, awayPoints, homePoints, MatchLocation.Outer);
            }
        }
    }
}