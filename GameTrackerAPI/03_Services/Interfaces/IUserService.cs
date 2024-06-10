using GameTracker.API.Models;

namespace GameTracker.API.Services;

public interface IUserService
{
    public Task<User> CreateNewUserAsync(User newUserSentFromController);

    public Task<User> GetUserByUsernameAsync(string usernameToFindFromController);

    public Task<string> DeleteUserByUsernameAsync(string usernameToDeleteFromController);
    public Task<string> UpdateUserByUsernameAsync(UsernameUpdateDTO usernameToSwapFromController);

    public Task<bool> UserExistsAsync(string usernameToFindFromController);
}