using System;
using System.Collections.Generic;

class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();
        _random = new Random();

        string[] parts = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < parts.Length; i++)
        {
            _words.Add(new Word(parts[i]));
        }
    }

    public void HideRandomWords(int count)
    {
        List<int> visibleIndexes = new List<int>();

        for (int i = 0; i < _words.Count; i++)
        {
            if (_words[i].IsVisible())
            {
                visibleIndexes.Add(i);
            }
        }

        int wordsToHide = count;
        if (visibleIndexes.Count < wordsToHide)
        {
            wordsToHide = visibleIndexes.Count;
        }

        for (int i = 0; i < wordsToHide; i++)
        {
            int pick = _random.Next(visibleIndexes.Count);
            int indexToHide = visibleIndexes[pick];

            _words[indexToHide].Hide();

            // remove so we don't hide the same word twice in one round
            visibleIndexes.RemoveAt(pick);
        }
    }

    public bool AllWordsHidden()
    {
        for (int i = 0; i < _words.Count; i++)
        {
            if (_words[i].IsVisible())
            {
                return false;
            }
        }
        return true;
    }

    public void Display()
    {
        Console.WriteLine(_reference.Display());
        Console.WriteLine();

        for (int i = 0; i < _words.Count; i++)
        {
            Console.Write(_words[i].Display());

            if (i < _words.Count - 1)
            {
                Console.Write(" ");
            }
        }

        Console.WriteLine();
    }
}
