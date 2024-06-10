using Microsoft.AspNetCore.Mvc;
using GameTracker.API.Models;
using GameTracker.API.Services;

namespace GameTracker.API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userServiceFromBuilder)
    {
        _userService = userServiceFromBuilder;
    }

    [HttpPost("Users/{username}")]
    public async Task<ActionResult<User>> PostNewUser(string username)
    {
        try
        {
            User newUser = new User(username);

            await _userService.CreateNewUserAsync(newUser);

            return Ok(newUser);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("/Users/{usernameToFindFromFrontEnd}")]
    public async Task<ActionResult<User>> GetUserByUsername(string usernameToFindFromFrontEnd)
    {
        try
        {
            return await _userService.GetUserByUsernameAsync(usernameToFindFromFrontEnd);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    [HttpDelete("Users/{usernameToDeleteFromFrontEnd}")]
    public async Task<ActionResult> DeleteUserByUsernameAsync(string usernameToDeleteFromFrontEnd)
    {
        try
        {
            await _userService.DeleteUserByUsernameAsync(usernameToDeleteFromFrontEnd);
            return Ok($"{usernameToDeleteFromFrontEnd} was deleted from the database!");
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    [HttpPatch("Users")]
    public async Task<ActionResult> UpdateUserByUsername(UsernameUpdateDTO usernamesToSwap)
    {
        try
        {
            await _userService.UpdateUserByUsernameAsync(usernamesToSwap);

            return Ok($"{usernamesToSwap.oldUserName}'s");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
