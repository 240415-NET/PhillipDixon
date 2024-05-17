using GameTracker.Models;
using System.Text.Json;

namespace GameTracker.Data;

public class JsonGameStorage : IGameStorageRepo
{

    public static string filePath = "Games.json";

    //If I find myself re-using the same string or object etc, I can go ahead
    //and make it a member of my class. This way I can reuse this same data without
    //having to continuously re-initialize it.
    //The underscore is a common convention to denote variables that are common
    //to the entire class


    //Changed my methods to be instance methods instead of class methods

    public void StoreGame(Game newGame)
    {
        List<Game?> existingGamesList = DTOStorage.DeserializeGame();

        existingGamesList.Add(newGame);

        DTOStorage.SerializeGame(existingGamesList);
    }
    public List<Game> GetGames(Guid userID, int listType)
    {
        List<Game> myReturnList = new();
        GamesDTO allMyStuff = JsonSerializer.Deserialize<GamesDTO>(File.ReadAllText(filePath));
        {
            var userGames = allMyStuff.Games.Where(x => x.userId.Equals(userID));
            foreach (var Game in userGames)
            {
                myReturnList.Add(Game);
            }
        }
        return myReturnList;
    }
}

