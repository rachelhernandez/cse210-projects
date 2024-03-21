public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string description, int points, int targetCount, int bonusPoints) : base(description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override void Display()
    {
        string completionStatus = IsCompleted ? "[X]" : "[ ]";
        Console.WriteLine(completionStatus + " " + Description + " (Completed " + _currentCount + "/" + _targetCount + " times)");
    }

    public override void RecordEvent()
    {
        if (!IsCompleted)
        {
            Console.WriteLine("Goal recorded: " + Description);
            _currentCount++;

            if (_currentCount < _targetCount)
            {
                Console.WriteLine("Points earned: " + Points);
            }
            else if (_currentCount == _targetCount)
            {
                Console.WriteLine("Congratulations! Goal completed: " + Description);
                Console.WriteLine("Bonus points earned: " + _bonusPoints);
                IsCompleted = true;
                Points += _bonusPoints;
            }
        }
        else
        {
            Console.WriteLine("Goal already completed. No additional points earned.");
        }
    }
}