public class SaveLoadManager
{
    private string _saveFileName;

    public SaveLoadManager(string saveFileName)
    {
        _saveFileName = saveFileName;
    }

    public void SaveGoalsAndScore(List<Goal> goals, int score)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(_saveFileName))
            {
                foreach (Goal goal in goals)
                {
                    string goalType = goal.GetType().Name;
                    string description = goal.Description;
                    int points = goal.Points;
                    bool isCompleted = goal.IsCompleted;

                    writer.WriteLine($"{goalType}|||{description}|||{points}|||{isCompleted}");
                }

                writer.WriteLine($"Score,{score}");
            }

            Console.WriteLine("Goals and score saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to save goals and score: " + ex.Message);
        }
    }

    public Tuple<List<Goal>, int> LoadGoalsAndScore()
    {
        List<Goal> goals = new List<Goal>();
        int score = 0;

        try
        {
            using (StreamReader reader = new StreamReader(_saveFileName))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split("|||");

                    if (parts.Length >= 4)
                    {
                        string goalType = parts[0];
                        string description = parts[1];
                        int points = int.Parse(parts[2]);
                        bool isCompleted = bool.Parse(parts[3]);

                        Goal goal = CreateGoalInstance(goalType, description, points, isCompleted);
                        goals.Add(goal);
                    }
                    else if (parts.Length == 2 && parts[0] == "Score")
                    {
                        score = int.Parse(parts[1]);
                    }
                }
            }

            Console.WriteLine("Goals and score loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Failed to load goals and score: " + ex.Message);
        }

        return new Tuple<List<Goal>, int>(goals, score);
    }

    private Goal CreateGoalInstance(string goalType, string description, int points, bool isCompleted)
    {
        switch (goalType)
        {
            case "SimpleGoal":
                return new SimpleGoal(description, points) { IsCompleted = isCompleted };
            case "EternalGoal":
                return new EternalGoal(description, points) { IsCompleted = isCompleted };
            case "ChecklistGoal":
                int targetCount = 0;
                int bonusPoints = 0;

                if (description.EndsWith(")"))
                {
                    int openParenIndex = description.LastIndexOf("(");
                    int closeParenIndex = description.LastIndexOf(")");
                    if (openParenIndex != -1 && closeParenIndex != -1 && closeParenIndex > openParenIndex + 1)
                    {
                        string countStr = description.Substring(openParenIndex + 1, closeParenIndex - openParenIndex - 1);
                        string[] countParts = countStr.Split('/');
                        if (countParts.Length == 2 && int.TryParse(countParts[0], out targetCount) && int.TryParse(countParts[1], out bonusPoints))
                        {
                            description = description.Substring(0, openParenIndex).Trim();
                        }
                    }
                }

                return new ChecklistGoal(description, points, targetCount, bonusPoints) { IsCompleted = isCompleted };
            default:
                throw new ArgumentException("Invalid goal type: " + goalType);
        }
    }
}