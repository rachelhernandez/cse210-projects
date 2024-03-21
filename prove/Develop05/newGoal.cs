public abstract class Goal : MakeSaveable
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isitCompleted = false;

    public bool IsItCompleted()
    {
        return _isitCompleted;
    }

    public abstract void CreateGoal();

    public virtual string GetDisplay();
    {
        completed = _isCompleted ==true ? "[x]" :"[ ]";
        return $"";
    }
}