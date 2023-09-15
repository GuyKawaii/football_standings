// See https://aka.ms/new-console-template for more information

using Football_Standings;
using System.IO;
using System.Reflection;
using System;
using System.IO;



var (teamsList, teamMapDictionary) = CsvProcessor.LoadTeamsFromCsv(Path.Combine("test", "teams.csv"));
Console.Write("hello");












// // path to the csv file
// string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
// string path = Path.Combine(directory, "test", "teams.csv");
// string projectRootDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;


// Console.WriteLine("path");
// Console.WriteLine(directory);
// Console.WriteLine(path);
// Console.WriteLine(projectRootDirectory);
// Console.WriteLine(Path.Combine(projectRootDirectory, "abc",  "test.csv"));
// Console.WriteLine(Path.Combine("abc",  "test.csv"));



// string[] lines = File.ReadAllLines(path);
// foreach(string line in lines)
// {
//     string[] columns = line.Split(',');
//     foreach (string column in columns) {
//         Console.WriteLine(column);
//     }
// }