using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> _promptsListReflection = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _reflectionQuestionsList = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times?",
        "What did you learn about yourself?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity()
        : base("Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience.")
    {
    }

    public void Run()
    {
        StartMessage();

        string prompt = GetRandomPrompt(_promptsListReflection);
        DisplayPrompt(prompt);

        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder each of the following questions:");
        PauseSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        Random rand = new Random();

        while (DateTime.Now < endTime)
        {
            string question = _reflectionQuestionsList[rand.Next(_reflectionQuestionsList.Count)];
            Console.Write($"\n{question} ");
            PauseSpinner(5);
        }

        EndMessage();
    }
}