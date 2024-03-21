public abstract class Goal
{
    private string _description;
    protected int _points;
    protected bool _isCompleted;

    public Goal(string description, int points)
    {
        _description = description;
        _points = points;
        _isCompleted = false;
    }

    public string Description { get { return _description; } }
    public int Points { get { return _points; } protected set { _points = value; } }
    public bool IsCompleted { get { return _isCompleted; } set { _isCompleted = value; } }

    public abstract void Display();
    public abstract void RecordEvent();
}
