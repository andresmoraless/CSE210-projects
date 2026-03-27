public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int value)
        : base(name, description, value)
    {
    }

    public override int RecordEvent()
    {
        return _goalScoreValue;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal,{_goalName},{_goalDescription},{_goalScoreValue}";
    }
}