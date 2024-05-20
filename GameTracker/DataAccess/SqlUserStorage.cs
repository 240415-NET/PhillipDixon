using GameTracker.Models;
using System.Data.SqlClient;

namespace GameTracker.Data;

public class SqlUserStorage : IUserStorageRepo
{
    public static string connectionString = File.ReadAllText(@"C:\Users\U0K0JI\Training\SQLConnection.txt");

    public User FindUser(string usernameToFind)
    {
        User foundUser = new User();
        using SqlConnection connection = new SqlConnection(connectionString);

        try
        {
            
            connection.Open();

            string commandText = @"SELECT userId, userName FROM dbo.Users
                            WHERE userName = @userNameToFind;";

            using SqlCommand sqlCommand= new SqlCommand (commandText, connection);
            sqlCommand.Parameters.AddWithValue("@userNameToFind", usernameToFind);

            using SqlDataReader reader = sqlCommand.ExecuteReader();
            while(reader.Read())
            {
                foundUser.userId = reader.GetGuid(0);
                foundUser.userName = reader.GetString(1);
            }

            connection.Close();

            if(String.IsNullOrEmpty(foundUser.userName))
            {
                return null;
            }

            return foundUser;
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