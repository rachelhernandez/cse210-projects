public class SimpleGoal : Goal
{
    public SimpleGoal(string description, int points) : base(description, points)
    {
    }

    public override void Display()
    {
        string completionStatus = IsCompleted ? "[X]" : "[ ]";
        Console.WriteLine(completionStatus + " " + Description);
    }

    public override void RecordEvent()
    {
        if (!IsCompleted)
        {
            Console.WriteLine("Goal completed: " + Description);
            Console.WriteLine("Points earned: " + Points);
            IsCompleted = true;
        }
        else
        {
            Console.WriteLine("Goal already completed. No additional points earned.");
        }
    }
}