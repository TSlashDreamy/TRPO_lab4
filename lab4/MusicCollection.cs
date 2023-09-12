namespace lab4;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class MusicCollection
{
    private List<MusicComposition> compositions;

    public MusicCollection()
    {
        compositions = new List<MusicComposition>();
    }

    public void AddComposition(MusicComposition composition)
    {
        compositions.Add(composition);
    }

    public void DisplayCompositions()
    {
        foreach (var composition in compositions)
        {
            Console.WriteLine(composition);
        }
    }

    public void SortByGenreAndDuration()
    {
        compositions.Sort();
    }

    public List<MusicComposition> GetCompositionsByArtist(string artist)
    {
        return compositions.Where(c => c.Artist == artist).ToList();
    }

    public void SaveToFile(string fileName)
    {
        using (StreamWriter writer = new StreamWriter(fileName))
        {
            foreach (var composition in compositions)
            {
                writer.WriteLine($"{composition.Title},{composition.Artist},{composition.Album},{composition.Genre},{composition.Duration}");
            }
        }
    }

    public void LoadFromFile(string fileName)
    {
        compositions.Clear();
        using (StreamReader reader = new StreamReader(fileName))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var parts = line.Split(',');
                if (parts.Length == 5)
                {
                    string title = parts[0];
                    string artist = parts[1];
                    string album = parts[2];
                    string genre = parts[3];
                    TimeSpan duration;
                    if (TimeSpan.TryParse(parts[4], out duration))
                    {
                        compositions.Add(new MusicComposition(title, artist, album, genre, duration));
                    }
                }
            }
        }
    }
}
