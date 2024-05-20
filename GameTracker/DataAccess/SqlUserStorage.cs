using GameTracker.Models;

namespace GameTracker.Data;

public class SqlUserStorage : IUserStorageRepo
{
    public static string connectionString = File.ReadAllText(@"C:\Users\U0K0JI\Training\SQLConnection.txt");
}