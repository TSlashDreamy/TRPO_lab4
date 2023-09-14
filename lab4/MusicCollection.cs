namespace lab4;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
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
        using (FileStream fs = new FileStream(fileName, FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, compositions);
        }
    }

    public void LoadFromFile(string fileName)
    {
        using (FileStream fs = new FileStream(fileName, FileMode.Open))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            compositions = (List<MusicComposition>)formatter.Deserialize(fs);
        }
    }
}
