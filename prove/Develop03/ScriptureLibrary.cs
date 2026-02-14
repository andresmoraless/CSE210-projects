using System;
using System.Collections.Generic;

class ScriptureLibrary
{
    private List<Scripture> _scriptures;
    private Random _random;

    public ScriptureLibrary()
    {
        _scriptures = new List<Scripture>();
        _random = new Random();

        LoadScriptures();
    }

    private void LoadScriptures()
    {
        Reference r1 = new Reference("John", 3, 16);
        string t1 = "For God so loved the world, that he gave his only begotten Son, " +
                    "that whosoever believeth in him should not perish, but have everlasting life.";

        Reference r2 = new Reference("Proverbs", 3, 5, 6);
        string t2 = "Trust in the Lord with all thine heart and lean not unto thine own understanding. " +
                    "In all thy ways acknowledge him and he shall direct thy paths.";

        Reference r3 = new Reference("Psalm", 23, 1);
        string t3 = "The Lord is my shepherd I shall not want.";

        _scriptures.Add(new Scripture(r1, t1));
        _scriptures.Add(new Scripture(r2, t2));
        _scriptures.Add(new Scripture(r3, t3));
    }

    public Scripture GetRandomScripture()
    {
        int index = _random.Next(_scriptures.Count);
        return _scriptures[index];
    }
}
