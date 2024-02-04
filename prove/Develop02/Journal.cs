class Journal
{
    private List<JournalEntry> entries = new List<JournalEntry>();

    public void addEntry(string prompt, string response, string date)
    {
        entries.Add(new JournalEntry(prompt, response, date));
    }

    public void displayEntries()
    {
        Console.WriteLine("Journal Entries:");
        foreach (var entry in entries)
            Console.WriteLine($"Date: {entry.Date}\nPrompt: {entry.Prompt}Response: {entry.Response}\n");
    }

    public void saveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
            foreach (var entry in entries)
                writer.WriteLine($"{entry.Date},{entry.Prompt},{entry.Response}");

        Console.WriteLine($"Journal was saved to {fileName}.");
    }

    public void loadFromFile(string fileName)
    {
        entries.Clear();
        try
        {
            using (StreamReader reader = new StreamReader(fileName))
                while (!reader.EndOfStream)
                {
                    string[] line = reader.ReadLine().Split(',');
                    if (line.Length == 3)
                        entries.Add(new JournalEntry(line[1], line[2], line[0]));
                }
            Console.WriteLine($"Journal was loaded from {fileName}.");
        }
        catch (FileNotFoundException) { Console.WriteLine($"File is not found: {fileName}."); }
        catch (Exception ex) { Console.WriteLine($"An error has occurred: {ex.Message}"); }
    }
}