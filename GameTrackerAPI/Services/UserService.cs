using GameTracker.API.Models;


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

        await _userStorage.CreateNewUserAsync(newUserFromController);

        return newUserFromController;
    }

    public bool UserExists(string userName)
    {
        return false;
    }
}