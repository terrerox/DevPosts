namespace SOLID.SRP.Solution;

public class Character
{
    public string Name { get; set; }

    public Character(string name)
    {
        Name = name;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Character: {Name}");
    }
}

public class Episode
{
    public string Title { get; set; }

    public Episode(string title)
    {
        Title = title;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Episode: {Title}");
    }
}

public class Anime
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int NumberOfEpisodes { get { return Episodes.Count; } }
    public string Studio { get; set; }
    public string Director { get; set; }
    public List<Character> MainCharacters { get; private set; }
    public List<Episode> Episodes { get; private set; }

    public Anime(string title, string genre, string studio, string director)
    {
        Title = title;
        Genre = genre;
        Studio = studio;
        Director = director;
        MainCharacters = new List<Character>();
        Episodes = new List<Episode>();
    }

    public void AddCharacter(Character character)
    {
        MainCharacters.Add(character);
    }

    public void AddEpisode(Episode episode)
    {
        Episodes.Add(episode);
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {Title}");
        Console.WriteLine($"Genre: {Genre}");
        Console.WriteLine($"Studio: {Studio}");
        Console.WriteLine($"Director: {Director}");
        Console.WriteLine($"Number of Episodes: {NumberOfEpisodes}");
        Console.WriteLine("Main Characters:");
        foreach (var character in MainCharacters)
        {
            character.DisplayInfo();
        }
        Console.WriteLine("Episodes:");
        foreach (var episode in Episodes)
        {
            episode.DisplayInfo();
        }
    }
}
