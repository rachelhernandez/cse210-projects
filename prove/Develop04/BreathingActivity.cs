using System;
public class BreathingActivity : Activity
{  
    public BreathingActivity()
    {
        SetName("Breathing Activity");
        SetDescription("While completing this activiy, you willl be able to relax your mind and focus on your thoughts. Please follow the instructions given.");
    }
    public void PromptBreathing()
    {
        DateTime futureTime = GetFutureTime(GetDuration());
        DateTime currentTime = GetCurrentTime();
        
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("First, breathe in");
        GenerateCountdownTimer(2);
        Console.WriteLine();
        Console.Write("Second, breathe out");
        GenerateCountdownTimer(3);

        while (currentTime <= futureTime)
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.Write("Breathe in");
            GenerateCountdownTimer(4);
            Console.WriteLine();
            Console.Write("Breathe out");
            GenerateCountdownTimer(6);
            currentTime = DateTime.Now;
        }
    }
}