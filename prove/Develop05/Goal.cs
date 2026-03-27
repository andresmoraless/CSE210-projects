public class Goal
{
    protected string _goalName;
    protected string _goalDescription;
    protected int _goalScoreValue;

    public Goal(string name, string description, int pointsValue)
    {
        _goalName = name;
        _goalDescription = description;
        _goalScoreValue = pointsValue;
    }

    public virtual int RecordEvent()
    {
        return _goalScoreValue;
    }

    public virtual bool IsComplete()
    {
        return false;
    }

    public virtual string GetStatus()
    {
        return IsComplete() ? "[X]" : "[ ]";
    }

    public virtual string GetInfo()
    {
        return $"{GetStatus()} {_goalName} ({_goalDescription})";
    }

    public virtual string GetStringRepresentation()
    {
        return $"{_goalName},{_goalDescription},{_goalScoreValue}";
    }
}