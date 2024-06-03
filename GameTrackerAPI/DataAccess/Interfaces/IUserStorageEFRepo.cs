using GameTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GameTracker.API.Data;

public interface IUserStorageEFRepo
{
    public Task<User?> CreateUserInDBAsync(User newUserSentFromUserSercice);
    public Task<User> GetUserFromDBByUsernameAsync(string usernameToFindFromCUserService);
}