public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int value)
        : base(name, description, value)
    {
        _isComplete = false;
    }

    public SimpleGoal(string name, string description, int value, bool isComplete)
        : base(name, description, value)
    {
        _isComplete = isComplete;
    }

    public override int RecordEvent()
    {
        if (!_isComplete)
        {
            _isComplete = true;
            return _goalScoreValue;
        }

        return 0;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal,{_goalName},{_goalDescription},{_goalScoreValue},{_isComplete}";
    }
}