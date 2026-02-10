using System;

public class Entry
{
    private string _date;
    private string _promptText;
    private string _responseText;
    private int _mood;

    public Entry()
    {
    }

    public Entry(string date, string promptText, string responseText, int mood)
    {
        _date = date;
        _promptText = promptText;
        _responseText = responseText;
        _mood = mood;
    }

    public string GetDate()
    {
        return _date;
    }

    public string GetPromptText()
    {
        return _promptText;
    }

    public string GetResponseText()
    {
        return _responseText;
    }

    public int GetMood()
    {
        return _mood;
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date} - Mood: {_mood}/5 - Prompt: {_promptText}");
        Console.WriteLine(_responseText);
        Console.WriteLine();
    }


    public string ToFileLine()
    {
        return $"{_date}|{_mood}|{_promptText}|{_responseText}";
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

        string response = string.Join("|", parts, 3, parts.Length - 3);

        return new Entry(date, prompt, response, mood);
    }
}

