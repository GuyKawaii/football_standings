namespace Football_Standings;

public class RoundProcessor
{
    public void ProcessRoundFiles(Dictionary<string,Team> teams)
    {
        
        
        var teamMap = teams;
        

        using (var reader = new StreamReader(Path.Combine(_rootDir, filepath)))
        {
            // Read to discard the header
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');
                
                    foreach (var teamValuePair in teamMap)
                    {
                        if (teamValuePair.Key.Contains(values[0]) & teamValuePair.Key.Contains(values[2]))
                        {
                            // Adds Win/Loss/Draw to team based on info from round
                            if (Int16.Parse(values[1]) > Int16.Parse(values[3]))
                            {
                                teamValuePair.Value.Wins += 1;
                            }
                            else if (Int16.Parse(values[1]) < Int16.Parse(values[3]))
                            {
                                teamValuePair.Value.Losses += 1;
                            }
                            else
                            {
                                teamValuePair.Value.Draws += 1;
                            }
                            
                            // 
                            
                            
                            
                            
                            
                            
                            
                        }
                        
                    }

            // Assuming the CSV format is: Abbreviation,Full club name,Special ranking
                var team = new Team(values[0], values[1], values[2]);

                teams.Add(team);
                teamMap[team.Abbreviation] = team;
            }
        }
        
        
        try
        {
            
        }
        catch (Exception e)
        {
            
        }
    }
}