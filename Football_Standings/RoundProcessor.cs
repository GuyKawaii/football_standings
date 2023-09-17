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

                if (teamMap.ContainsKey(values[0]) & teamMap.ContainsKey(values[2]))
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
                    
                    // Goal for & goal against
                    //teamMap[values[0]].UpdateMatchResult(teamMap[values[3]],hometeamGoals,outteamGoals);
                    //teamMap[values[1]].UpdateMatchResult();
                    
                    teamMap[values[0]].GoalsFor += hometeamGoals;
                    teamMap[values[2]].GoalsAgainst += outteamGoals;
                    teamMap[values[1]].GoalsFor += outteamGoals;
                    teamMap[values[3]].GoalsAgainst += hometeamGoals;
                }

            }
            
        }

    }
}
        
        
        
