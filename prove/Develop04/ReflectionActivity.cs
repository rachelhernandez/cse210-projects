using System;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string> {        
        "Can you remember a moment when you supported someone?",
        "When was a time you overcame a challenge?",
        "How has following the Lord helped you through difficult tasks?",
        "Think of an expirence where you had to forgive someone. How did this help you too?",
        "When was a time where you did something generous for someone else. How did this make you feel?",
    };
    private List<string> _questions = new List<string> {
        "What was the most meaningful part of this expirence? ",
        "How has this expirence helped you?",
        "What lessons have you learned from this expirence that you can use outside of it?",
        "How did you feel once you completed this activity?"
        "What was the biggest thing you learned through doing this?",
    };
    public ReflectingActivity()
    {
        SetName("Reflecting Activity");
        SetDescription("For this activity, you will be able to reflect on times where you have been able to overcome challenge or have shown strength and courage. You will then be able to use these reflections and learn how you can gain powerful lessons from them, some which may help you in other aspects of your life.");
    }

    public string GenerateQuestion()
    {
        Random random = new Random();
        int index = random.Next(0, _questions.Count);
        return _questions[index];
    }
    public string GeneratePrompt()
    {
        Random random = new Random();
        int index = random.Next(0, _prompts.Count);
        return _prompts[index];
    }
    public void PromptReflecting()
    {   
        string prompt = GeneratePrompt();
        Console.WriteLine();
        Console.WriteLine("Reflect on the following questions or prompts.");
        Console.WriteLine();
        Console.WriteLine($"{prompt}");
        Console.WriteLine();
        Console.WriteLine("Once you have your answer, press enter to contiune");
        Console.ReadLine();
        Console.Clear();
        
        DateTime futureTime = GetFutureTime(GetDuration());
        DateTime currentTime = GetCurrentTime();

        while (currentTime <= futureTime)
        {
            string question = GenerateQuestion();
            Console.Write(question + " ");
            GenerateSpinner(15);
            Console.WriteLine();
            currentTime = DateTime.Now;
        }
    }
}