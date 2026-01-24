using System;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGen = new PromptGenerator();

        while (true)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine();
            Console.WriteLine();

            if (choice == "1")
            {
                string prompt = promptGen.GetRandomPrompt();
                Console.WriteLine(prompt);
                Console.Write("> ");
                string response = Console.ReadLine();

                // EXCEEDING REQUIREMENTS:
                // Ask the user for a mood rating (1–5) and store it with the entry.
                int mood = GetMoodFromUser();

                string date = DateTime.Now.ToShortDateString();

                Entry entry = new Entry(date, prompt, response, mood);
                journal.AddEntry(entry);

                Console.WriteLine("Entry added.\n");
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();

                journal.LoadFromFile(filename);
                Console.WriteLine("Journal loaded.\n");
            }
            else if (choice == "4")
            {
                Console.Write("What is the filename? ");
                string filename = Console.ReadLine();

                journal.SaveToFile(filename);
                Console.WriteLine("Journal saved.\n");
            }
            else if (choice == "5")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Try again.\n");
            }
        }
    }

    static int GetMoodFromUser()
    {
        while (true)
        {
            Console.Write("Mood today (1–5)? ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int mood) && mood >= 1 && mood <= 5)
            {
                Console.WriteLine();
                return mood;
            }

            Console.WriteLine("Please enter a number from 1 to 5.\n");
        }
    }
}
