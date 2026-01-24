using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }
    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("Your journal is empty.\n");
            return;
        }

        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine(entry.ToFileLine());
            }
        }
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.\n");
            return;
        }

        _entries.Clear();

        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) continue;
            _entries.Add(Entry.FromFileLine(line));
        }
    }
}
