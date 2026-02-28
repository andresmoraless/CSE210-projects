using System;
using System.Collections.Generic;

public class ListingActivity : Activity
{
    private int _userCounter = 0;

    private List<string> _promptsListListing = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who have you helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public ListingActivity()
        : base("Listing Activity",
        "This activity will help you reflect on the good things in your life by listing as many things as you can.")
    {
    }

    public void Run()
    {
        StartMessage();

        string prompt = GetRandomPrompt(_promptsListListing);
        DisplayPrompt(prompt);

        Console.WriteLine("You may begin listing in:");
        Countdown(5);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        _userCounter = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            _userCounter++;
        }

        Console.WriteLine($"\nYou listed {_userCounter} items!");

        EndMessage();
    }
}