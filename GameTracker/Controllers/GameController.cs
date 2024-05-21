using System;
using System.Data.SqlClient;
using GameTracker.Models;
using GameTracker.Data;

namespace GameTracker.Controllers;

public class GameController
{
    private static string connectionString = File.ReadAllText(@"C:\Users\U0K0JI\Training\SQLConnection.txt");

    private static IGameStorageRepo _GameData = new SqlGameStorage();

    public static void CreateGame(User user, string gameName, double originalCost, DateTime purchaseDate)
    {
        Game newGame = new Game(user.userId, gameName, originalCost, purchaseDate);
        _GameData.StoreGame(newGame);
    }
    public static List<Game> GetGames(Guid userID)
    {
        return _GameData.GetGames(userID);
    }
    public static void RemoveGame(Game removeGame)
    {
        _GameData.RemoveGame(removeGame);
    }
    public static void ModifyGame(Game modifiedGame)
    {
        _GameData.ModifyGame(modifiedGame);
    }
}