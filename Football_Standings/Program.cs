﻿// See https://aka.ms/new-console-template for more information

using Football_Standings;
using System.IO;
using System.Reflection;
using System;
using System.IO;

// path to the csv file
string directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
string path = Path.Combine(directory, "test", "teams.csv");

Console.WriteLine("path");
Console.WriteLine(path);
Console.WriteLine(Directory.GetParent(workingDirectory).Parent.Parent.FullName);



// string[] lines = File.ReadAllLines(path);
// foreach(string line in lines)
// {
//     string[] columns = line.Split(',');
//     foreach (string column in columns) {
//         Console.WriteLine(column);
//     }
// }