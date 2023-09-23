using System.Text;

namespace Football_Standings.test;

public static class CsvGenerator
{
    static string _rootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
    static Random Rnd = new Random(42);


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

        // round robin over 2 files
        for (int i = 1; i < teams.Count; i++)
        {
            int halfTeamsCount = teams.Count / 2;

            // Creating first file
            StringBuilder csvContent1 = new StringBuilder();
            csvContent1.AppendLine("home,home goals,away,away goals");
            for (int j = 0; j < halfTeamsCount; j++)
            {
                csvContent1.AppendLine(
                    $"{teams[j % teams.Count]},{Rnd.Next(lowerGoals, upperGoals)},{teams[(j + i) % teams.Count]},{Rnd.Next(lowerGoals, upperGoals)}");
            }

            string fileName1 = $"round-{fileCount}.csv";
            string fullPath1 = Path.Combine(_rootDir, filePath, fileName1);
            File.WriteAllText(fullPath1, csvContent1.ToString());
            fileCount++;

            // Check if there are any teams left
            if (halfTeamsCount * 2 < teams.Count) halfTeamsCount++;

            // Creating second file
            StringBuilder csvContent2 = new StringBuilder();
            csvContent2.AppendLine("home,home goals,away,away goals");
            for (int j = halfTeamsCount; j < teams.Count; j++)
            {
                csvContent2.AppendLine(
                    $"{teams[j % teams.Count]},{Rnd.Next(lowerGoals, upperGoals)},{teams[(j + i) % teams.Count]},{Rnd.Next(lowerGoals, upperGoals)}");
            }

            string fileName2 = $"round-{fileCount + teams.Count - 2}.csv";
            string fullPath2 = Path.Combine(_rootDir, filePath, fileName2);
            File.WriteAllText(fullPath2, csvContent2.ToString());
        }
    }
}