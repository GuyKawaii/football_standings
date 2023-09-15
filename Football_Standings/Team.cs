using System;
using System.Collections.Generic;
using System.Linq;

public class Team : IComparable<Team>
{
    public string Abbreviation { get; set; }
    public string Name { get; set; }
    public string SpecialRanking { get; set; }
    public int Position { get; set; }
    public int GamesPlayed { get; set; }
    public int Wins { get; set; }
    public int Draws { get; set; }
    public int Losses { get; set; }
    public int GoalsFor { get; set; }
    public int GoalsAgainst { get; set; }
    public int GoalDifference => GoalsFor - GoalsAgainst;
    public int Points => Wins * 3 + Draws;
    public Queue<char> Streak { get; private set; } = new Queue<char>(5);

    public Team(string abbreviation, string name, string specialRanking)
    {
        Abbreviation = abbreviation;
        Name = name;
        SpecialRanking = specialRanking;
    }

    public void UpdateMatchResult(string opposingTeam, int goalsFor, int goalsAgainst)
    {
        GamesPlayed++;
        GoalsFor += goalsFor;
        GoalsAgainst += goalsAgainst;

        if (goalsFor > goalsAgainst)
        {
            Wins++;
            UpdateStreak('W');
        }
        else if (goalsFor == goalsAgainst)
        {
            Draws++;
            UpdateStreak('D');
        }
        else
        {
            Losses++;
            UpdateStreak('L');
        }
    }

    private void UpdateStreak(char result)
    {
        if (Streak.Count == 5)
        {
            Streak.Dequeue();
        }
        Streak.Enqueue(result);
    }

    public string GetStreakDisplay()
    {
        return Streak.Any() ? string.Join("|", Streak) : "-";
    }
    
    // Implementing the IComparable interface for sorting
    public int CompareTo(Team other)
    {
        if (this.Points != other.Points)
            return other.Points.CompareTo(this.Points);
        if (this.GoalDifference != other.GoalDifference)
            return other.GoalDifference.CompareTo(this.GoalDifference);
        if (this.GoalsFor != other.GoalsFor)
            return other.GoalsFor.CompareTo(this.GoalsFor);
        return this.Name.CompareTo(other.Name);
    }
}