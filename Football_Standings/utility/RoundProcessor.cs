using System.Diagnostics.Metrics;

namespace Football_Standings;

public static class RoundProcessor
{
    static string _rootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

    static public void ProcessRoundFiles(Dictionary<string, Team> dictTeams, string filepath)
    {
        var teamMap = dictTeams;


        using (var reader = new StreamReader(Path.Combine(_rootDir, filepath, "round-1.csv")))
        {
            // Read to discard the header
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                //
                var line = reader.ReadLine();
                var values = line.Split(',');


                if (teamMap.ContainsKey(values[0]) && teamMap.ContainsKey(values[2]))
                {
                    var hometeamGoals = Int16.Parse(values[1]);
                    var outteamGoals = Int16.Parse(values[3]);

                    // Win/Loss/Draw calculation

                    if (hometeamGoals > outteamGoals)
                    {
                        teamMap[values[0]].Wins += 1;
                        teamMap[values[2]].Losses += 1;
                    }
                    else if (hometeamGoals < outteamGoals)
                    {
                        teamMap[values[0]].Losses += 1;
                        teamMap[values[2]].Wins += 1;
                    }
                    else
                    {
                        teamMap[values[0]].Draws += 1;
                        teamMap[values[2]].Draws += 1;
                    }

                    // Games for and against for home and away teams
                    //home
                    teamMap[values[0]].GoalsFor += hometeamGoals;
                    teamMap[values[0]].GoalsAgainst += outteamGoals;
                    //away
                    teamMap[values[2]].GoalsFor += outteamGoals;
                    teamMap[values[2]].GoalsAgainst += hometeamGoals;

                    // Games played
                    teamMap[values[0]].GamesPlayed += 1;
                    teamMap[values[2]].GamesPlayed += 1;
                }

                // if (teamMap.ContainsKey(values[0]) & teamMap.ContainsKey(values[2]))
                // {
                //     var hometeamGoals = Int16.Parse(values[1]);
                //     var outteamGoals = Int16.Parse(values[3]);

                //     // Win/Loss/Draw calculation

                //     if (hometeamGoals > outteamGoals)
                //     {
                //         teamMap[values[0]].Wins += 1;
                //         teamMap[values[2]].Losses += 1;
                //     }
                //     else if (hometeamGoals < outteamGoals)
                //     {
                //         teamMap[values[0]].Losses += 1;
                //         teamMap[values[2]].Wins += 1;
                //     }
                //     else
                //     {
                //         teamMap[values[0]].Draws += 1;
                //         teamMap[values[2]].Draws += 1;
                //     }

                //     // Goal for & goal against
                //     //teamMap[values[0]].UpdateMatchResult(teamMap[values[3]],hometeamGoals,outteamGoals);
                //     //teamMap[values[1]].UpdateMatchResult();

                //     teamMap[values[0]].GoalsFor += hometeamGoals;
                //     teamMap[values[2]].GoalsAgainst += outteamGoals;
                //     teamMap[values[1]].GoalsFor += outteamGoals;
                //     teamMap[values[3]].GoalsAgainst += hometeamGoals;
                // }

                // var line = reader.ReadLine();
                //
                // Console.WriteLine(line);
                // var values = line.Split(',');
                //
                // Team home =  dictTeams[values[0]];
                // Team away =  dictTeams[values[2]];
                // int homePoints = Int16.Parse(values[1]);
                // int awayPoints = Int16.Parse(values[3]);
                //
                // if (!dictTeams.ContainsKey(values[0]) || !dictTeams.ContainsKey(values[2])) {
                //     return;
                // }
                //
                // home.UpdateMatchResult(away.Abbreviation, homePoints, awayPoints);
                // away.UpdateMatchResult(home.Abbreviation, awayPoints, homePoints);
            }
        }
    }


    public static void ProcessLeague(Dictionary<string, Team> dictTeams, League leage, string filepath)
    {
        for (int i = 1; i <= 22; i++)
        {
            String completePath = Path.Combine(_rootDir, filepath, $"round-{i}.csv");

            ProcessRound(dictTeams, completePath);
        }

        // create fractions
        List<Team> teams = dictTeams.Values.ToList();
        teams.Sort();
        teams.ForEach(team => team.ResetOpponents());

        List<Team> upperFraction = teams.GetRange(0, 6);
        List<Team> lowerFraction = teams.GetRange(6, 6);
        Dictionary<string, Team> upperFractionDict = upperFraction.ToDictionary(team => team.Abbreviation, team => team);
        Dictionary<string, Team> lowerFractionDict = upperFraction.ToDictionary(team => team.Abbreviation, team => team);

        // for (int i = 23; i <= 32; i++)
        // {
        //     String completePath = Path.Combine(_rootDir, filepath, $"round-{i}.csv");

        //     ProcessRound(upperFractionDict, completePath);
        //     ProcessRound(lowerFractionDict, completePath);
        // }

        // set special rankings
        LeagueOld league = new LeagueOld("lala", 2, 1, 1, 1, 2);
        upperFraction.ForEach(team =>
            team.SpecialRanking =
                (team.SpecialRanking == "R" || team.SpecialRanking == "P") ? "" : team.SpecialRanking);

        lowerFraction.ForEach(team =>
            team.SpecialRanking =
                (team.SpecialRanking == "R" || team.SpecialRanking == "P") ? "" : team.SpecialRanking);

        int totalPromotions = league.GetLeaguePromotions().Sum(position => position.Number);
        int totalRelegations = league.GetLeagueRelegations().Sum(position => position.Number);


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

                Team home = dictTeams[values[0]];
                Team away = dictTeams[values[2]];

                int homePoints = int.Parse(values[1]);
                int awayPoints = int.Parse(values[3]);

                // discard invalid team match-up
                if (!dictTeams.ContainsKey(values[0]) || !dictTeams.ContainsKey(values[2]))
                {
                    continue;
                }

                // check for match restrictions
                if (away.HasPlayed(home.Abbreviation, MatchLocation.Outer) ||
                    home.HasPlayed(away.Abbreviation, MatchLocation.Home) ||
                    away.Abbreviation == home.Abbreviation)
                {
                    if (filepath == @"c:\Users\danie\UNRAID_SHARE\RiderProjects\Football_Standings\Football_Standings\test\round-12.csv
")
                    {
                        Console.WriteLine("hello debug");
                    }


                    Console.WriteLine("Prohibited: Repeated Matches with same opponent or Self");
                    Console.WriteLine(filepath);
                    break;
                }


                home.UpdateMatchResult(away.Abbreviation, homePoints, awayPoints, MatchLocation.Home);
                away.UpdateMatchResult(home.Abbreviation, awayPoints, homePoints, MatchLocation.Outer);
            }
        }
    }
}