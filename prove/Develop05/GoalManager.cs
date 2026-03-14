public class GoalManager
{
    public int totalPoints = 0;
    private List<Goal> goals = new List<Goal>();

    public void GainPoints(int points)
    {
        totalPoints += points;
    }
    public string GetRank()
    {
    if (totalPoints >= 5000)
        return "Master";
    else if (totalPoints >= 2000)
        return "Champion";
    else if (totalPoints >= 1000)
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
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == "2")
        {
            goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == "3")
        {
            Console.Write("Target times: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }
    }

    public void DisplayGoalShort()
    {
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetInfo()}");
        }
    }

    public void RecordEvent()
    {
        DisplayGoalShort();

        Console.Write("Which goal did you complete? ");
        int index = int.Parse(Console.ReadLine()) - 1;

        int points = goals[index].RecordEvent();
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

        Random rand = new Random();
        int i = rand.Next(messages.Count);

        Console.WriteLine(messages[i]);
    }

    public void SaveGoals(string filepath)
    {
        List<string> lines = new List<string>();

        foreach (Goal g in goals)
        {
            lines.Add(g.GetStringRepresentation());
        }

        File.WriteAllLines(filepath, lines);
    }

    public void LoadGoals(string filepath)
    {
        if (!File.Exists(filepath)) return;

        string[] lines = File.ReadAllLines(filepath);

        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
    }
}