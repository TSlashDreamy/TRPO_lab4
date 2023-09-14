namespace lab4;

[Serializable]
class MusicComposition : IComparable<MusicComposition>
{

    private string title = "";
    private string artist = "";
    private string album = "";
    private string genre = "";
    private TimeSpan duration;

    public string Title
    {
        get { return title; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Title cannot be empty or whitespace.");
            }
            title = value;
        }
    }

    public string Artist
    {
        get { return artist; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Artist cannot be empty or whitespace.");
            }
            artist = value;
        }
    }

    public string Album
    {
        get { return album; }
        set { album = value; }
    }

    public string Genre
    {
        get { return genre; }
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Genre cannot be empty or whitespace.");
            }
            genre = value;
        }
    }

    public TimeSpan Duration
    {
        get { return duration; }
        set
        {
            if (value.TotalSeconds <= 0)
            {
                throw new ArgumentException("Duration must be a positive value.");
            }
            duration = value;
        }
    }

    public MusicComposition()
    {
        Title = "Unknown track";
        Artist = "Unknown artist";
        Album = "Unknown album";
        Genre = "Unknown genre";
        Duration = new TimeSpan(0, 0, 0);
    }

    public MusicComposition(string title, string artist, string album, string genre, TimeSpan duration)
    {
        Title = title;
        Artist = artist;
        Album = album;
        Genre = genre;
        Duration = duration;
    }

    public int CompareTo(MusicComposition other)
    {
        // Сортування спершу за жанром, а потім за тривалістю
        int genreComparison = string.Compare(Genre, other.Genre, StringComparison.Ordinal);
        if (genreComparison == 0)
        {
            return Duration.CompareTo(other.Duration);
        }
        return genreComparison;
    }

    public override string ToString()
    {
        return $"{Title} by {Artist}, Genre: {Genre}, Duration: {Duration}";
    }
}

