using GameTracker.Models;
using GameTracker.Data;
using GameTracker.Presentation;
using System.Diagnostics.Contracts;


namespace GameTracker.Controllers;


public class GameController
{

    private static IGameStorageRepo _GameData = new JsonGameStorage();

    public static void CreateGame(User user, string gameName, double originalCost, DateTime purchaseDate)
    {
        Game newGame = new Game(user.userId, gameName, originalCost, purchaseDate);
        _GameData.StoreGame(newGame);
    }
    public static List<Game> GetGames(Guid userID)
    {
        return _GameData.GetGames(userID, 1);
    }

    /* ********************************Remove Game code. Currently a WIP. ***************************************************
        public static void RemoveItem(Guid _gameId, User _user)
        {
            //retrieve full list from JSON
            GamesDTO returnedDTO = DTOStorage.DeserializeAllGames();

             if(returnedDTO != null)
            {
                var subsetGames = from theGame in returnedDTO.Games
                                    where theGame.gameId == _gameId
                                    select theGame;
                List<Game> deleteGame = subsetGames.ToList();
                if(deleteGame.Count > 0)
                {
                    returnedDTO.Games.Remove(deleteGame[0]);
                    Console.WriteLine($"{deleteGame[0].AbbrToString()}  has been removed. Press any key to continue.");
                }
                DTOStorage.SerializeAllGames(returnedDTO);
            }else
            {
                Console.WriteLine("No games found");
            }

            Console.ReadLine();
            GameMenu.GameFunctionMenu(_user);
        }
    */

    /******************Remove Game code start. Currently WIP**********************************
    public static class ModifyGames
    {
        public static void ModifyIndividualGame(Game gameToBeModified, string newGameName, List<Game> gamesToBeModified)
        {
            gameToBeModified.gameName = newGameName;
            gamesToBeModified.Add(gameToBeModified);
        }

        public static void ModifyGamesFromList(List<Game> gamesToBeModified)
        {
            IGameStorageRepo gameStorage = new JsonGameStorage();
            foreach (Game game in gamesToBeModified)
            {
                GameController.RemoveGame(game.userId, game.gameId)
            Console.WriteLine($"{game.gameId} was removed!");

                gameStorage.StoreGame(game);
                Console.WriteLine($"{game.gameId} was re-added with {game.gameName}");
            }
        }
    }
    //***************Modify Game code end*****************/
}