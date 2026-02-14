using System;

class Program
{
    static void Main()
    {
        // EXCEEDED REQUIREMENTS:
        // I added a ScriptureLibrary class that stores multiple scriptures and randomly selects one each time the program runs.
        // This allows the program to work with a library instead of a single scripture.

        ScriptureLibrary library = new ScriptureLibrary();
        Scripture scripture = library.GetRandomScripture();

        while (true)
        {
            Console.Clear();
            scripture.Display();

            if (scripture.AllWordsHidden())
            {
                break;
            }

            Console.WriteLine();
            Console.Write("Press Enter to hide words or type 'quit' to finish: ");
            string input = Console.ReadLine();

            if (input != null && input.Trim().ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }
}

