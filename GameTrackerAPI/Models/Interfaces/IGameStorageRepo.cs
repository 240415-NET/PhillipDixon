namespace GameTracker.API.Models;


public interface IGameStorageRepo
{
    public void StoreGame(Game newGame);
    public void RemoveGame(Game game);
    public void ModifyGame(Game game);
    public List<Game> GetGames(Guid userID);
}