namespace SOLID.SRP.Problem;

public class Anime
{
    public string Title { get; set; }
    public string Genre { get; set; }
    public int NumberOfEpisodes { get; private set; }
    public string Studio { get; set; }
    public string Director { get; set; }
    public List<string> MainCharacters { get; private set; }
    public List<string> Episodes { get; private set; }

    public Anime(string title, string genre, string studio, string director)
    {
        Title = title;
        Genre = genre;
        Studio = studio;
        Director = director;
        MainCharacters = new List<string>();
        Episodes = new List<string>();
        NumberOfEpisodes = 0;
    }

    public void AddCharacter(string character)
    {
        MainCharacters.Add(character);
    }

    public void AddEpisode(string episode)
    {
        Episodes.Add(episode);
        NumberOfEpisodes++;
    }
}