using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private int _totalPoints = 0;
    private List<Goal> _goals = new List<Goal>();

    public int GetTotalPoints()
    {
        return _totalPoints;
    }

    public void GainPoints(int points)
    {
        _totalPoints += points;
    }

    public string GetRank()
    {
        if (_totalPoints >= 5000)
            return "Master";
        else if (_totalPoints >= 2000)
            return "Champion";
        else if (_totalPoints >= 1000)
            return "Achiever";
        else
            return "Beginner";
    }

    public void CreateGoal()
    {
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");

        string type = Console.ReadLine();

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string description = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (type == "3")
        {
            Console.Write("Target times: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void DisplayGoalsShort()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals created yet.");
            return;
        }

        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetInfo()}");
        }
    }

    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals available.");
            return;
        }

        DisplayGoalsShort();

        Console.Write("Which goal did you complete? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid goal selection.");
            return;
        }

        int points = _goals[index].RecordEvent();
        GainPoints(points);

        Console.WriteLine($"You earned {points} points!");

        List<string> messages = new List<string>()
        {
            "Great job!",
            "Keep it up!",
            "You're doing amazing!",
            "LET'S GOOO!",
            "Nice work!"
        };

        Random random = new Random();
        int randomIndex = random.Next(messages.Count);

        Console.WriteLine(messages[randomIndex]);
    }

    public void SaveGoals(string filepath)
    {
        List<string> lines = new List<string>();

        lines.Add($"TotalPoints,{_totalPoints}");

        foreach (Goal goal in _goals)
        {
            lines.Add(goal.GetStringRepresentation());
        }

        File.WriteAllLines(filepath, lines);

        Console.WriteLine("Goals saved successfully.");
    }

    public void LoadGoals(string filepath)
    {
        if (!File.Exists(filepath))
        {
            Console.WriteLine("Save file not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filepath);

        _goals.Clear();
        _totalPoints = 0;

        foreach (string line in lines)
        {
            string[] parts = line.Split(",");

            if (parts[0] == "TotalPoints")
            {
                _totalPoints = int.Parse(parts[1]);
            }
            else if (parts[0] == "SimpleGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                bool isComplete = bool.Parse(parts[4]);

                _goals.Add(new SimpleGoal(name, description, points, isComplete));
            }
            else if (parts[0] == "EternalGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);

                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (parts[0] == "ChecklistGoal")
            {
                string name = parts[1];
                string description = parts[2];
                int points = int.Parse(parts[3]);
                int timesCompleted = int.Parse(parts[4]);
                int target = int.Parse(parts[5]);
                int bonus = int.Parse(parts[6]);

                _goals.Add(new ChecklistGoal(name, description, points, target, bonus, timesCompleted));
            }
        }

        Console.WriteLine("Goals loaded successfully.");
    }
}