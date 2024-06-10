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

    public async Task<string> DeleteUserFromDBAsync(string usernameToDeleteFromUserService)
    {
        
        User? userToDelete = await GetUserFromDBByUsernameAsync(usernameToDeleteFromUserService);

        if (userToDelete == null)
        {
            throw new Exception("Thrown from the db layer, userToDelete was null");
        }
        _context.Users.Remove(userToDelete);
        
        await _context.SaveChangesAsync();

        return usernameToDeleteFromUserService;
    }

    public async Task <bool> DoesThisUserExistOnDBAsync (string usernameToDeleteFromUserService)
    {
        return await _context.Users.AnyAsync(user => user.userName == usernameToDeleteFromUserService);
    }

    public async Task<string> UpdateUserInDBAsync(UsernameUpdateDTO usernamesToSwapFromUserService)
    {
        User? userToUpdate = await _context.Users.SingleOrDefaultAsync(user => user.userName == usernamesToSwapFromUserService.oldUserName);

        if (userToUpdate == null)
        {
            throw new Exception("User to update i not found!");
        }
        else
        {
            userToUpdate.userName = usernamesToSwapFromUserService.newUserName;
        }

        await _context.SaveChangesAsync();

        return usernamesToSwapFromUserService.newUserName;
    }

}