using GameTracker.Models;
using System.Data.SqlClient;

namespace GameTracker.Data;

public class SqlGameStorage : IGameStorageRepo
{
    public static string connectionString = File.ReadAllText(@"C:\Users\U0K0JI\Training\SQLConnection.txt");

    public List<Game> GetGames(Guid userID)
    {
        List<Game> myReturnList = new();

        using SqlConnection connection = new SqlConnection(connectionString);

        try
        {
        connection.Open();

        string commandText = @"SELECT userId, gameId, gameName, originalCost, purchaseDate FROM dbo.Games
                            WHERE userID = @userID;";

            using SqlCommand sqlCommand= new SqlCommand (commandText, connection);
            sqlCommand.Parameters.AddWithValue("@userId", userID);

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while(reader.Read())
            {
                Game returnedGame = new();

                returnedGame.userId = reader.GetGuid(0);
                returnedGame.gameId = reader.GetGuid(1);
                returnedGame.gameName = reader.GetString(2);
                returnedGame.originalCost = reader.GetDouble(3);
                returnedGame.purchaseDate = reader.GetDateTime(4);

                myReturnList.Add(returnedGame);
            }

            connection.Close();

            return myReturnList;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();   
        }
        return null;            
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
        sqlCommand.Parameters.AddWithValue("@gameName", newGame.gameName);
        sqlCommand.Parameters.AddWithValue("@originalCost", newGame.originalCost);
        sqlCommand.Parameters.AddWithValue("@purchaseDate", newGame.purchaseDate);
        sqlCommand.ExecuteNonQuery();

        connection.Close();
    }
    public void RemoveGame(Game removeGame)
    {
        using SqlConnection connection = new SqlConnection(connectionString);

        try
        {
            connection.Open();

            string query = @"DELETE FROM dbo.Games WHERE gameId = @removeGameId";

            using SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@removeGameId", removeGame.gameId);
                command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }
    }
    public void ModifyGame(Game modifiedGame)
    {
        using SqlConnection connection = new SqlConnection(connectionString);

        try
        {
            connection.Open();

            string updateQuery = @"UPDATE dbo.Games SET gameName = @newgameName, originalCost = @neworiginalCost, purchaseDate = @newpurchaseDate WHERE gameId = @passedgameId;";

            using SqlCommand command = new SqlCommand(updateQuery, connection);
            command.Parameters.AddWithValue("@newgameName", modifiedGame.gameName);
            command.Parameters.AddWithValue("@neworiginalCost", modifiedGame.originalCost);
            command.Parameters.AddWithValue("@newpurchaseDate", modifiedGame.purchaseDate);
            command.Parameters.AddWithValue("@passedgameId", modifiedGame.gameId);
            command.ExecuteNonQuery();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            connection.Close();
        }
    } 
}