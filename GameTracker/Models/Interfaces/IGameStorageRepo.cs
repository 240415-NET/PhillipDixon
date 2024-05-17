namespace GameTracker.Models;


public interface IGameStorageRepo
{
    public void StoreGame(Game newGame);

    public List<Game> GetGames(Guid userID, int listType);
}