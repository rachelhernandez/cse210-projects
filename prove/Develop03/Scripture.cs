class Scripture
{
    private Reference _reference;
    private List<Word> _text;
    private List<Word> _hiddenWords;

    public Scripture(Reference reference, List<Word> text)
    {
        _reference = reference;
        _text = text;
        _hiddenWords = new List<Word>();
    }

    public bool HideRandomWord()
    {
        List<Word> visibleWords = new List<Word>();

        foreach (Word word in _text)
        {
            if (!_hiddenWords.Contains(word))
            {
                visibleWords.Add(word);
            }
        }

        if (visibleWords.Count == 0)
        {
            return false;
        }

        Random random = new Random();
        int randomIndex = random.Next(visibleWords.Count);
        _hiddenWords.Add(visibleWords[randomIndex]);
        return true;
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine(_reference.GetReference());

        foreach (Word word in _text)
        {
            if (_hiddenWords.Contains(word))
            {
                Console.Write("_____ ");
            }
            else
            {
                Console.Write(word.GetWord() + " ");
            }
        }

        Console.WriteLine();
    }
}