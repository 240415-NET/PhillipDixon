using GameTracker.Models;
using System.Data.SqlClient;

namespace GameTracker.Data;

public class SqlUserStorage : IUserStorageRepo
{
    public static string connectionString = File.ReadAllText(@"C:\Users\U0K0JI\Training\SQLConnection.txt");

    public User FindUser(string usernameToFind)
    {
        throw new NotImplementedException();
    }

    public void StoreUser(User user)
    {
        using SqlConnection connection = new SqlConnection(connectionString);

        connection.Open();

        string commandText = @"INSERT INTO dbo.Users(userId, userName)
                            VALUES (@userId, @userName);";

        using SqlCommand sqlCommand= new SqlCommand (commandText, connection);

        sqlCommand.Parameters.AddWithValue("@userId", user.userId);
        sqlCommand.Parameters.AddWithValue("@userName", user.userName);

        sqlCommand.ExecuteNonQuery();

        connection.Close();
    }
}