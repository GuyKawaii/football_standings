using System;
using System.Collections.Generic;
using System.Linq;

public enum MatchLocation {
    Home,
    Outer
}

public class Team : IComparable<Team> {
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

    // keep track of teams played
    private ISet<string> homeTeams;
    private ISet<string> outerTeams;

    public Team(string abbreviation, string name, string specialRanking) {
        Abbreviation = abbreviation;
        Name = name;
        SpecialRanking = specialRanking;

        homeTeams = new HashSet<string>();
        outerTeams = new HashSet<string>();
    }

    public void UpdateMatchResult(string opposingTeam, int goalsFor, int goalsAgainst, MatchLocation location) {
        GamesPlayed++;
        GoalsFor += goalsFor;
        GoalsAgainst += goalsAgainst;

        if (goalsFor > goalsAgainst) {
            Wins++;
            UpdateStreak('W');
        }
        else if (goalsFor == goalsAgainst) {
            Draws++;
            UpdateStreak('D');
        }
        else {
            Losses++;
            UpdateStreak('L');
        }

        // Match location
        if (location == MatchLocation.Home) 
        {
            outerTeams.Add(opposingTeam);
        }
        else if (location == MatchLocation.Outer) 
        {
            homeTeams.Add(opposingTeam);
        }
        else {
            throw new ArgumentException("Location has to be set");
        }
    }

    private void UpdateStreak(char result) {
        if (Streak.Count == 5) {
            Streak.Dequeue();
        }

        Streak.Enqueue(result);
    }

    public string GetStreakDisplay() {
        return Streak.Any() ? string.Join("|", Streak) : "-";
    }

    // method to return if opposing team is played
    public bool hasPlayed(string opponent) {
        return outerTeams.Contains(opponent) || homeTeams.Contains(opponent);
    }

    public void ResetOpponents() {
        homeTeams.Clear();
        outerTeams.Clear();
    }


    // Implementing the IComparable interface for sorting
    public int CompareTo(Team other) {
        // Tiered comparison
        if (this.Points != other.Points)
            return other.Points - this.Points;
        if (this.GoalDifference != other.GoalDifference)
            return other.GoalDifference - this.GoalDifference;
        if (this.GoalsFor != other.GoalsFor)
            return other.GoalsFor - this.GoalsFor;
        // fallback
        return this.Name.CompareTo(other.Name);
    }
}