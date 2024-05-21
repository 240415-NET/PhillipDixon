namespace GameTracker.Models;


public interface IGameStorageRepo
{
    public void StoreGame(Game newGame);

    public List<Game> GetGames(Guid userID);

    public void RemoveGame(Game game);

    public void ModifyGame(Game game);
}