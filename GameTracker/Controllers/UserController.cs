using GameTracker.Models;
using GameTracker.Data;

namespace GameTracker.Controllers;

public class UserController
{
    private static IUserStorageRepo _userData = new JsonUserStorage();
    public static User CreateUser(string userName)
    {
        User newUser = new User(userName);
        _userData.StoreUser(newUser);
        return newUser;
    }
    public static bool UserExists(string userName)
    {
        if(_userData.FindUser(userName) != null)
        {
            return true;
        }
        return false;
    }
    public static User ReturnUser (string userName)
    {
        User existingUser = _userData.FindUser(userName);
        return existingUser;
    }
    
}