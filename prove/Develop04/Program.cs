using System;

class Program
{
// Exceeds Requirements:
// Added functionality to track how many times each activity 
// (Breathing, Reflection, and Listing) is performed during 
// the session. The user can view these statistics from the menu.
    static int _breathingCount = 0;
    static int _reflectionCount = 0;
    static int _listingCount = 0;

    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("--------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. View Activity Stats");
            Console.WriteLine("5. Quit");
            Console.Write("\nSelect an option: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                BreathingActivity activity = new BreathingActivity();
                activity.Run();
                _breathingCount++;   // increment counter
            }
            else if (choice == "2")
            {
                ReflectingActivity activity = new ReflectingActivity();
                activity.Run();
                _reflectionCount++;  // increment counter
            }
            else if (choice == "3")
            {
                ListingActivity activity = new ListingActivity();
                activity.Run();
                _listingCount++;     // increment counter
            }
            else if (choice == "4")
            {
                ShowStats();
            }
            else if (choice == "5")
            {
                running = false;
            }
            else
            {
                Console.WriteLine("\nInvalid choice. Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }

    static void ShowStats()
    {
        Console.Clear();
        Console.WriteLine("Activity Statistics");
        Console.WriteLine("-------------------");
        Console.WriteLine($"Breathing Activity completed: {_breathingCount} time(s)");
        Console.WriteLine($"Reflection Activity completed: {_reflectionCount} time(s)");
        Console.WriteLine($"Listing Activity completed: {_listingCount} time(s)");
        Console.WriteLine("\nPress Enter to return to the menu...");
        Console.ReadLine();
    }
}