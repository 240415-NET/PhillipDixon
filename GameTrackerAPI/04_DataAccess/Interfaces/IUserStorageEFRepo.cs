using GameTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GameTracker.API.Data;

public interface IUserStorageEFRepo
{
    public Task<User?> CreateUserInDBAsync(User newUserSentFromUserSercice);
    public Task<User> GetUserFromDBByUsernameAsync(string usernameToFindFromCUserService);

    public Task<string> DeleteUserFromDBAsync(string usernameToDeleteFromUserService);
    public Task<string> UpdateUserInDBAsync(UsernameUpdateDTO usernamesToSwapFromUserService);

    public Task<bool> DoesThisUserExistOnDBAsync(string usernameToFindFromUserService);
}