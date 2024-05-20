using GameTracker.Models;
using System.Data.SqlClient;

namespace GameTracker.Data;

public class SqlGameStorage : IGameStorageRepo
{
    public static string connectionString = File.ReadAllText(@"C:\Users\U0K0JI\Training\SQLConnection.txt");

    public List<Game> GetGames(Guid userID, int listType)
    {
        throw new NotImplementedException();
    }

    public void StoreGame(Game newGame)
    {
        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        string commandText = @"INSERT INTO dbo.Games(userId, gameId, gameName, originalCost, purchaseDate)
                            VALUES (@userId, @gameId, @gameName, @originalCost, @purchaseDate);";

        using SqlCommand sqlCommand= new SqlCommand (commandText, connection);

        sqlCommand.Parameters.AddWithValue("@userId", newGame.userId);
        sqlCommand.Parameters.AddWithValue("@gameId", newGame.gameId);
        sqlCommand.Parameters.AddWithValue("@userName", newGame.gameName);
        sqlCommand.Parameters.AddWithValue("@originalCost", newGame.originalCost);
        sqlCommand.Parameters.AddWithValue("@purchaseDate", newGame.purchaseDate);

        sqlCommand.ExecuteNonQuery();

        connection.Close();
    }
}