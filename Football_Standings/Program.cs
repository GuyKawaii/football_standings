// See https://aka.ms/new-console-template for more information

using Football_Standings;

// load teams and setup
var (teamsList, teamMapDictionary) = CsvProcessor.LoadTeamsFromCsv(Path.Combine("test", "teams.csv"));

// Console Write tests
Console.Write("hello");
Console.WriteLine(LeagueProcessor.LoadLeagueFromCsv("E:\\Code\\RiderProjects\\FootballProject\\Football_Standings\\CsvFiles\\TestLeagueCsv.csv").LeagueName);
// display 

// loop(22) for round files 22

// display


// upper lower 10 rounds

// display

