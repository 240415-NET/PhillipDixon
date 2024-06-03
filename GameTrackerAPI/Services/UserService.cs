using GameTracker.API.Models;
using GameTracker.API.Data;

namespace GameTracker.API.Services;

public class UserService : IUserService
{
    private readonly IUserStorageEFRepo _userStorage;

    public UserService(IUserStorageEFRepo efRepoFromBuilder)
    {
        _userStorage = efRepoFromBuilder;
    }

    public async Task<User> CreateNewUserAsync(User newUserFromController)
    {
        if (UserExists(newUserFromController.userName) == true)
        {
            throw new Exception("User already Exists.");
        }

        if (string.IsNullOrEmpty(newUserFromController.userName) == true)
        {
            throw new Exception("Username cannot be blank!");
        }

        await _userStorage.CreateUserInDBAsync(newUserFromController);

        return newUserFromController;
    }

    public async Task<User> GetUserByUsernameAsync(string usernameToFindFromController)
    {
        if (string.IsNullOrEmpty(usernameToFindFromController))
        {
            throw new Exception("You have a name; your username cannot be blank!");
        }

        try
        {
            User? foundUser = await _userStorage.GetUserFromDBByUsernameAsync(usernameToFindFromController);

            if(foundUser == null)
            {
                throw new Exception("User wasn't found in the database.");
            }
            return foundUser;

        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public bool UserExists(string userName)
    {
        return false;
    }


}