class Reference
{
    private string _book;
    private int _chapter;
    private int _firstVerse;
    private int _lastVerse;

    // Single verse constructor
    public Reference(string book, int chapter, int firstVerse)
    {
        _book = book;
        _chapter = chapter;
        _firstVerse = firstVerse;
        _lastVerse = 0; // 0 means "single verse"
    }

    // Verse range constructor
    public Reference(string book, int chapter, int firstVerse, int lastVerse)
    {
        _book = book;
        _chapter = chapter;
        _firstVerse = firstVerse;
        _lastVerse = lastVerse;
    }

    public string Display()
    {
        if (_lastVerse == 0)
        {
            return _book + " " + _chapter + ":" + _firstVerse;
        }

        return _book + " " + _chapter + ":" + _firstVerse + "-" + _lastVerse;
    }
}
