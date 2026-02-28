using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    private string _activityName;
    private string _activityDescription;
    private int _activityDuration;

    public Activity(string name, string description)
    {
        _activityName = name;
        _activityDescription = description;
    }

    public void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName}.\n");
        Console.WriteLine(_activityDescription);
        Console.Write("\nHow long (in seconds) would you like your session? ");
        _activityDuration = int.Parse(Console.ReadLine());

        Console.WriteLine("\nGet ready...");
        PauseSpinner(3);
    }

    public void EndMessage()
    {
        Console.WriteLine("\nWell done!!");
        PauseSpinner(3);
        Console.WriteLine($"\nYou have completed the {_activityName} for {_activityDuration} seconds.");
        PauseSpinner(3);
    }

    public int GetDuration()
    {
        return _activityDuration;
    }

    public void PauseSpinner(int seconds)
    {
        List<string> spinner = new List<string> { "|", "/", "-", "\\" };

        DateTime endTime = DateTime.Now.AddSeconds(seconds);
        int i = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write(spinner[i]);
            Thread.Sleep(250);
            Console.Write("\b \b");

            i++;
            if (i >= spinner.Count)
                i = 0;
        }
    }

    public void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public string GetRandomPrompt(List<string> list)
    {
        Random rand = new Random();
        int index = rand.Next(list.Count);
        return list[index];
    }

    public void DisplayPrompt(string prompt)
    {
        Console.WriteLine($"\n--- {prompt} ---\n");
    }
}