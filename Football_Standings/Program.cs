// See https://aka.ms/new-console-template for more information

using Football_Standings;
using Football_Standings.test;

// ### generate data - COMMENT OUT ###
// CsvGenerator.Generate22("test");
// CsvGenerator.Generate10("test");

// main loop for program (for the user to choose a scenario to play out)
// userinput for choosing a type of test ie. what folder to read with




// load teams and setup
var (teamsList, teamMapDictionary) = CsvProcessor.LoadTeamsFromCsv(Path.Combine("test", "teams.csv"));
var league = CsvProcessor.LoadLeagueFromCsv("test");



// folder
// RoundProcessor.ProcessLeague(teamMapDictionary, league, "test");
// Console.WriteLine("they did the first");
// sub folder
// RoundProcessor.ProcessLeague(teamMapDictionary, league, Path.Combine("test", "playAgainstSelf"));
// RoundProcessor.ProcessLeague(teamMapDictionary, league, Path.Combine("test", "sameOpponent"));

bool running = true;
while (running)
{
    // string input = """
    // 1. run complete turnament 32 rounds
    // 2. run test team playing itself
    // 3. run test team playing itself
    // [Enter] to quit
    // """;

    // Console.WriteLine(input);
    Console.WriteLine("1. run complete turnament 32 rounds");
    Console.WriteLine("2. run test team playing itself");
    Console.WriteLine("Enter to quit");
    string userInput = Console.ReadLine();

    switch (userInput)
    {
        case "1":
            RoundProcessor.ProcessLeague(teamMapDictionary, league, "test");
            break;
        case "2":
            RoundProcessor.ProcessLeague(teamMapDictionary, league, "test");
            break;

        default:
            running = false;
            break;
    }


}



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

