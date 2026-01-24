using System;

public class Entry
{
    public string Date { get; set; }
    public string PromptText { get; set; }
    public string ResponseText { get; set; }

    // EXCEEDING REQUIREMENTS:
    // Added a Mood field (1–5) to each entry and included it in file save/load.
    public int Mood { get; set; }

    public Entry() { }

    public Entry(string date, string promptText, string responseText, int mood)
    {
        Date = date;
        PromptText = promptText;
        ResponseText = responseText;
        Mood = mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {Date} - Mood: {Mood}/5 - Prompt: {PromptText}");
        Console.WriteLine(ResponseText);
        Console.WriteLine();
    }

    // EXCEEDING REQUIREMENTS:
    // Save mood in the file so it persists between sessions.
    // Format: Date|Mood|Prompt|Response
    public string ToFileLine()
    {
        return $"{Date}|{Mood}|{PromptText}|{ResponseText}";
    }

    public static Entry FromFileLine(string line)
    {
        string[] parts = line.Split("|");
        if (parts.Length < 4)
        {
            return new Entry("", "", "", 0);
        }

        string date = parts[0];

        int mood = 0;
        int.TryParse(parts[1], out mood);

        string prompt = parts[2];

        // In case response contains |, re-join everything after index 2
        string response = string.Join("|", parts.Skip(3));

        return new Entry(date, prompt, response, mood);
    }
}
