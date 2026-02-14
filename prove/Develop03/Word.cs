class Word
{
    private string _text;
    private bool _isVisible;

    public Word(string text)
    {
        _text = text;
        _isVisible = true;
    }

    public void Hide()
    {
        _isVisible = false;
    }

    public bool IsVisible()
    {
        return _isVisible;
    }

    public string Display()
    {
        if (_isVisible)
        {
            return _text;
        }

        return new string('_', _text.Length);
    }
}
