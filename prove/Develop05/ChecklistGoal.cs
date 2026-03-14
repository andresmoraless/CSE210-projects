public class ChecklistGoal : Goal
{
    private int _goalBonusPoints;
    private int _timesCompleted;
    private int _targetCompletedAmount;

    public ChecklistGoal(string name, string description, int value, int target, int bonus)
        : base(name, description, value)
    {
        _targetCompletedAmount = target;
        _goalBonusPoints = bonus;
        _timesCompleted = 0;
    }

    public override int RecordEvent()
    {
        _timesCompleted++;

        if (_timesCompleted == _targetCompletedAmount)
        {
            return _goalScoreValue + _goalBonusPoints;
        }

        return _goalScoreValue;
    }

    public override bool IsComplete()
    {
        return _timesCompleted >= _targetCompletedAmount;
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal,{_goalName},{_goalDescription},{_goalScoreValue},{_timesCompleted},{_targetCompletedAmount},{_goalBonusPoints}";
    }
}