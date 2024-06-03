using GameTracker.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GameTracker.API.Data;

public class UserStorageEFRepo : IUserStorageEFRepo
{

    private readonly GameTrackerContext _context;
    public UserStorageEFRepo(GameTrackerContext contextFromBuilder)
    {
        _context = contextFromBuilder;
    }
    public async Task<User?> CreateUserInDBAsync(User newUserSentFromUserService)
    {
        _context.Users.Add(newUserSentFromUserService);

        await _context.SaveChangesAsync();

        return newUserSentFromUserService;
    }
    public async Task<User?> GetUserFromDBByUsernameAsync (string usernameToFindFromUserService)
    {
        User? foundUser = await _context.Users.SingleOrDefaultAsync(user => user.userName == usernameToFindFromUserService);

        return foundUser;
    }
}