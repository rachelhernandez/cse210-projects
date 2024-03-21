public class EternalGoal : Goal
{
    public EternalGoal(string description, int points) : base(description, points)
    {
    }

    public override void Display()
    {
        Console.WriteLine("[ ] " + Description);
    }

    public override void RecordEvent()
    {
        Console.WriteLine("Goal recorded: " + Description);
        Console.WriteLine("Points earned: " + Points);
    }
}
