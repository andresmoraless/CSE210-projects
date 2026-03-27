using System;

/*
I exceeded the requirements by adding a level system based on the user's
total points and displaying random motivational messages when a goal is recorded
to make the program more engaging!
*/

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Show Score");
            Console.WriteLine("7. Quit");

            string choice = Console.ReadLine();

            if (choice == "1")
                manager.CreateGoal();
            else if (choice == "2")
                manager.DisplayGoalsShort();
            else if (choice == "3")
                manager.RecordEvent();
            else if (choice == "4")
                manager.SaveGoals("goals.txt");
            else if (choice == "5")
                manager.LoadGoals("goals.txt");
            else if (choice == "6")
            {
                Console.WriteLine($"Total Points: {manager.GetTotalPoints()}");
                Console.WriteLine($"Rank: {manager.GetRank()}");
            }
            else if (choice == "7")
                break;
        }
    }
}