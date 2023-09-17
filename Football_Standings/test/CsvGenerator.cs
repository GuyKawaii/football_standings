using System.Text;

namespace Football_Standings.test;

public static class CsvGenerator
{
    static string _rootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
    static Random Rnd = new Random();

    // hardcoded for teams and points can be changed later
    public static void Generate22(string filePath)
    {
        List<string> teams = new List<string>
        {
            "FCK",
            "BIF",
            "AGF",
            "HBK",
            "VFF",
            "AAB",
            "SIF",
            "RFC",
            "EFC",
            "FCM",
            "FCN",
            "HOB"
        };

        // magic numbers
        int fileCount = 1;
        const int lowerGoals = 0;
        const int upperGoals = 6;

        // away shift
        for (int i = 1; i < teams.Count; i++)
        {
            StringBuilder csvContent = new StringBuilder();
            csvContent.AppendLine("home,home goals,away,away goals");
            for (int j = 0; j < teams.Count; j++)
            {
                csvContent.AppendLine(
                    $"{teams[j % teams.Count]},{Rnd.Next(lowerGoals, upperGoals)},{teams[(j + i) % teams.Count]},{Rnd.Next(lowerGoals, upperGoals)}");
            }

            string fileName = $"round-{fileCount}.csv";
            string fullPath = Path.Combine(_rootDir, filePath, fileName);
            File.WriteAllText(fullPath, csvContent.ToString());

            fileCount++;
        }

        // home shift
        for (int i = 1; i < teams.Count; i++)
        {
            StringBuilder csvContent = new StringBuilder();
            csvContent.AppendLine("home,home goals,away,away goals");
            for (int j = 0; j < teams.Count; j++)
            {
                csvContent.AppendLine(
                    $"{teams[(j + i) % teams.Count]},{Rnd.Next(lowerGoals, upperGoals)},{teams[j % teams.Count]},{Rnd.Next(lowerGoals, upperGoals)}");
            }

            string fileName = $"round-{fileCount}.csv";
            string fullPath = Path.Combine(_rootDir, filePath, fileName);
            File.WriteAllText(fullPath, csvContent.ToString());

            fileCount++;
        }
    }
}