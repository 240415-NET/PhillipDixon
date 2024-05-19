namespace GameTracker.Models;

public class GamesDTO
{
    public List<Game>? Games {get; set;}

    public GamesDTO()
    {
        this.Games = new List<Game>();
    }

    public GamesDTO(List<Game>Games)
    {
        this.Games = Games;
    }
}