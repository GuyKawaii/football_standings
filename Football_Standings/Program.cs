// See https://aka.ms/new-console-template for more information

using Football_Standings;
using Football_Standings.test;

// load teams and setup
var (teamsList, teamMapDictionary) = CsvProcessor.LoadTeamsFromCsv(Path.Combine("test", "teams.csv"));

// Console Write tests
Console.WriteLine("hello");
// Console.WriteLine(LeagueProcessor.LoadLeagueFromCsv("E:\\Code\\RiderProjects\\FootballProject\\Football_Standings\\CsvFiles\\TestLeagueCsv.csv").LeagueName);

// display 
StandingsDisplay.PrintCurrentStandings(teamsList);

// loop(22) for round files 22
Console.WriteLine(teamMapDictionary);
RoundProcessor.ProcessRoundFiles(teamMapDictionary, "test");
Console.WriteLine(teamMapDictionary);

// display
// StandingsDisplay.PrintCurrentStandings(teamsList);

// upper lower 10 rounds

// display


// EXTRA generate dummy data
// CsvGenerator.Generate22("test");

