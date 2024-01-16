using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade in the class? ");
        string valueFromUser = Console.ReadLine();
        int grade = int.Parse(valueFromUser);

        string letter = "";

        if (grade >= 90)
        {
            letter = "A";
        }
        else if (grade >= 80)
        {
            letter = "B";
        }
        else if (grade >= 70)
        {
            letter = "C";
        }
        else if (grade >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }
    
        Console.WriteLine($"Your grade is: {letter}");

        if (grade >= 70)
        {
            Console.WriteLine("Congrats! You passed the class.");
        }
        else 
        {
            Console.WriteLine("Sorry, you did not pass the class. Don't give up; you got it next time!");
        }
    }
}