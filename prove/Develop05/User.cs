public class User
{
    private List<Goal> _goals;
    private int _score;
    private SaveLoadManager _saveLoadManager;

    public User(string saveFileName)
    {
        _goals = new List<Goal>();
        _score = 0;
        _saveLoadManager = new SaveLoadManager(saveFileName);
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            Goal goal = _goals[goalIndex];
            goal.RecordEvent();

            if (goal.IsCompleted)
            {
                _score += goal.Points;
            }
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    public void DisplayGoals()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.Write((i + 1) + ". ");
            _goals[i].Display();
        }
    }

    public void DisplayScore()
    {
        Console.WriteLine("Current Score: " + _score);
    }

    public void SaveGoalsAndScore()
    {
        _saveLoadManager.SaveGoalsAndScore(_goals, _score);
    }

    public void LoadGoalsAndScore()
    {
        Tuple<List<Goal>, int> data = _saveLoadManager.LoadGoalsAndScore();
        _goals = data.Item1;
        _score = data.Item2;
    }
}