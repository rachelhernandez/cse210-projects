class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("Which option would you like to do: ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Exit");

            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    writeNewEntry(journal);
                    break;
                case "2":
                    journal.displayEntries();
                    break;
                case "3":
                    Console.Write("Please enter the filename: ");
                    string saveFileName = Console.ReadLine();
                    journal.saveToFile(saveFileName);
                    break;
                case "4":
                    Console.Write("Enter the filename you'd like to load: ");
                    string loadFileName = Console.ReadLine();
                    journal.loadFromFile(loadFileName);
                    break;
                case "5":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("This is an invalid option. Please choose again.");
                    break;
            }
        }
    }

    static void writeNewEntry(Journal journal)
    {
        List<string> prompts = new List<string>
        {
            "What made you smile today?",
            "What are you most thankful for today?",
            "Do you have any regrets from today? If not, what was the most memorable part of your day?",
            "Was there anything that strengthened your testimony today?",
            "What lessons have I learned today that I can carry with me for later days?"
        };

        Random random = new Random();
        int randomIndex = random.Next(prompts.Count);
        string randomPrompt = prompts[randomIndex];

        Console.WriteLine($"Prompt: {randomPrompt}");
        Console.Write("Your response was: ");
        string response = Console.ReadLine();

        string currentDate = DateTime.Now.ToString("M/d/yyyy");

        journal.addEntry(randomPrompt, response, currentDate);
        Console.WriteLine("Entry was saved successfully!");
    }
}
