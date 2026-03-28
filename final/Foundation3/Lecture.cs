using System;

public class Lecture : Event
{
    private string _speaker;
    private int _capacity;

    public Lecture(string title, string description, string date, string time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        _speaker = speaker;
        _capacity = capacity;
    }

    public string GetSpeaker()
    {
        return _speaker;
    }

    public int GetCapacity()
    {
        return _capacity;
    }

    public void SetSpeaker(string speaker)
    {
        _speaker = speaker;
    }

    public void SetCapacity(int capacity)
    {
        _capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"Event Type: Lecture\n{GetStandardDetails()}\nSpeaker: {_speaker}\nCapacity: {_capacity}";
    }
}