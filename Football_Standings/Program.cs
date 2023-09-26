using Football_Standings;
using Football_Standings.Exceptions;

// ### Keep disabled when not necessary ###
// CsvGenerator.Generate22(Path.Combine("test", "wholeTournament"));
// CsvGenerator.Generate10(Path.Combine("test", "wholeTournament"));

bool running = true;
while (running)
{
    Console.WriteLine("Select an option:");
    Console.WriteLine("1. Run complete tournament for 32 rounds");
    Console.WriteLine("2. Run test team playing against itself");
    Console.WriteLine("3. Run test team playing against each other");
    Console.WriteLine("Press [Enter] to quit");

    string userInput = Console.ReadLine();

    if (string.IsNullOrEmpty(userInput))
    {
        running = false;
        continue;
    }

    // Load teams and setup
    var (teamsList, teamMapDictionary) = CsvProcessor.LoadTeamsFromCsv(Path.Combine("test", "teams.csv"));
    League league = CsvProcessor.LoadLeagueFromCsv("test");

    try
    {
        switch (userInput)
        {
            case "1":
                RoundProcessor.ProcessLeague(teamMapDictionary, league, Path.Combine("test", "wholeTournament"));
                break;
            case "2":
                RoundProcessor.ProcessLeague(teamMapDictionary, league, Path.Combine("test", "playAgainstSelf"));
                break;
            case "3":
                RoundProcessor.ProcessLeague(teamMapDictionary, league, Path.Combine("test", "sameOpponent"));
                break;
            default:
                running = false;
                break;
        }
    }
    catch (Exception e)
    {
        Console.WriteLine("");
        Console.WriteLine("!!! Scenario stopped !!!");

        switch (e)
        {
            case SameTeamException:
                Console.WriteLine($"Team has played against itself: {e.Message}");
                break;
            case DuplicateTeamException:
                Console.WriteLine($"Teams have played each other before: {e.Message}");
                break;
            default:
                Console.WriteLine("Other error");
                Console.WriteLine(e.ToString());
                break;
        }
    }

    Console.WriteLine("");
}