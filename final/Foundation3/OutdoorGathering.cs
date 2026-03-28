using System;

public class OutdoorGathering : Event
{
    private string _weather;

    public OutdoorGathering(string title, string description, string date, string time, Address address, string weather)
        : base(title, description, date, time, address)
    {
        _weather = weather;
    }

    public string GetWeather()
    {
        return _weather;
    }

    public void SetWeather(string weather)
    {
        _weather = weather;
    }

    public override string GetFullDetails()
    {
        return $"Event Type: Outdoor Gathering\n{GetStandardDetails()}\nWeather Forecast: {_weather}";
    }
    public override string GetReminderMessage()
    {
        return $"Reminder: Outdoor Gathering \"{GetTitle()}\" is on {GetDate()} at {GetTime()}. Weather forecast: {_weather}.";
    }
}