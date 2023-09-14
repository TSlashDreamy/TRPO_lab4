using lab4;

try
{
    MusicCollection collection = new MusicCollection();
    collection.AddComposition(new MusicComposition("Song 1", "Artist A", "Album X", "Rock", TimeSpan.FromMinutes(4)));
    collection.AddComposition(new MusicComposition("Song 2", "Artist B", "Album Y", "Pop", TimeSpan.FromMinutes(3)));

    collection.SortByGenreAndDuration();
    collection.DisplayCompositions();

    var artistCompositions = collection.GetCompositionsByArtist("Artist A");
    foreach (var composition in artistCompositions)
    {
        Console.WriteLine(composition);
    }

    collection.SaveToFile("music_collection.bin");
    collection.LoadFromFile("music_collection.bin");
    Console.WriteLine("Loaded compositions");

    collection.DisplayCompositions();

}
catch (Exception e)
{
    Console.WriteLine($"You got an error: {e.Message}");
}
