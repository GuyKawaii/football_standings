namespace Football_Standings;

using System.Collections.Generic;
using System.IO;

public class LeagueProcessor
{
    public static League LoadLeagueFromCsv(string filepath)
    {
        League LeagueInfo = null;
        using (var reader = new StreamReader(filepath))
        {
            
            var line = reader.ReadLine();
            var values = line.Split(',');

            // Assuming the CSV format is: LeagueName, PositionsForChampionsLeague,PositionForEuropeLeague e.t.c.
            LeagueInfo = new League(
                values[0],
                Int32.Parse(values[1]),
                Int32.Parse(values[2]),
                Int32.Parse(values[3]),
                Int32.Parse(values[4]),
                Int32.Parse(values[5]));
            
        }
        
        Console.WriteLine("Trying to return processed league: ");
        Console.WriteLine(LeagueInfo);
        
        return LeagueInfo;


    }
}