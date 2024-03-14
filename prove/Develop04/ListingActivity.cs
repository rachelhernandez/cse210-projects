using System;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string> {
        "Think of a time where you helped someone. How did this make you feel?",
        "When are some occassions you have seen the lord's hand in your life?",
        "Who are you thankful for this week",
        "What is something you could improve on for next week?",
        "What are some actions you did that you are proud of this week?"
    };

    public ListingActivity()
    {
        SetName("Listing Activity");
        SetDescription("For this activity, you will be able to reflect on the good parts of your life by having you list as many thoughts you can within a set area.");
    }

    public string GeneratePrompt()
    {
        Random random = new Random();
        int index = random.Next(0, _prompts.Count);
        return _prompts[index];
    }
    public void PromptListing()
    {   
        string prompt = GeneratePrompt();
        Console.WriteLine();
        Console.WriteLine("Please list your thoughts for the following prompt: ");
        Console.WriteLine($"{prompt}");
        Console.Write("Your activity will start in: ");
        GenerateCountdownTimer(5);
        Console.WriteLine();
                
        DateTime futureTime = GetFutureTime(GetDuration());
        DateTime currentTime = GetCurrentTime();

        while (currentTime <= futureTime)
        {
            Console.Write(">");
            Console.ReadLine();
            currentTime = DateTime.Now;
        }
    }
}