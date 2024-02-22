using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        Reference scriptureReference = new Reference("John 3:16");
        List<Word> scriptureText = new List<Word>
        {
            new Word("For"),
            new Word("God"),
            new Word("so"),
            new Word("loved"),
            new Word("the"),
            new Word("world"),
            new Word("that"),
            new Word("he"),
            new Word("gave"),
            new Word("his"),
            new Word("one"),
            new Word("and"),
            new Word("only"),
            new Word("Son,"),
            new Word("that"),
            new Word("whoever"),
            new Word("believes"),
            new Word("in"),
            new Word("him"),
            new Word("shall"),
            new Word("not"),
            new Word("perish"),
            new Word("but"),
            new Word("have"),
            new Word("eternal"),
            new Word("life.")
        };

        Scripture scripture = new Scripture(scriptureReference, scriptureText);
        scripture.Display();
        Console.WriteLine("do you want to try to memorize this scripture? (yes/no)");
        string choice = Console.ReadLine();

        if (choice == "yes")
        {
        while (scripture.HideRandomWord())
        {
            scripture.Display();
            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                return;
            }
        }
        


        scripture.Display();
        Console.WriteLine("All the words are now hidden. Please press Enter to exit.");
        Console.ReadLine();
        }
        else 
        {
            Console.WriteLine("you have exited the Program.");
        }
    }
}