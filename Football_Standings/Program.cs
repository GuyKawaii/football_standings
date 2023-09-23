// See https://aka.ms/new-console-template for more information

using Football_Standings;
using Football_Standings.test;

// load teams and setup
var (teamsList, teamMapDictionary) = CsvProcessor.LoadTeamsFromCsv(Path.Combine("test", "teams.csv"));
var league = CsvProcessor.LoadLeagueFromCsv("test");

CsvGenerator.Generate22("test");
RoundProcessor.ProcessLeague(teamMapDictionary, league, "test");


// Console.WriteLine(LeagueProcessor.LoadLeagueFromCsv("E:\\Code\\RiderProjects\\FootballProject\\Football_Standings\\CsvFiles\\TestLeagueCsv.csv").LeagueName);



// display
// TableDisplay.PrintCurrentStandings(teamsList);

// loop(22) for round files 22
// Console.WriteLine(teamMapDictionary);
// RoundProcessor.ProcessRoundFiles(teamMapDictionary, "test");
// RoundProcessor.ProcessRound(teamMapDictionary, "test");
// Console.WriteLine(teamMapDictionary);

// StandingsDisplay.PrintCurrentStandings(teamMapDictionary.Values.ToList());

// display
// StandingsDisplay.PrintCurrentStandings(teamsList);

// upper lower 10 rounds



// display


// ### generate data ###

