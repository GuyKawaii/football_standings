namespace Football_Standings;

using System.Collections.Generic;
using System.IO;

public static class CsvProcessor
{
    static string _rootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
    public static (List<Team> teams, Dictionary<string, Team> teamMap) LoadTeamsFromCsv(string filepath)
    {
        var teams = new List<Team>();
        var teamMap = new Dictionary<string, Team>();

        using (var reader = new StreamReader(Path.Combine(_rootDir, filepath)))
        {
            // Read to discard the header
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                // Assuming the CSV format is: Abbreviation,Full club name,Special ranking
                var team = new Team(values[0], values[1], values[2]);

                teams.Add(team);
                teamMap[team.Abbreviation] = team;
            }
        }

        return (teams, teamMap);
    }
}