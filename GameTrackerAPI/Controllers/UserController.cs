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
    
    [HttpPost]
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

    [HttpGet]
    public async Task<ActionResult<User>> GetUserByUsername(string usernameToFind)
    {
        try
        {
            return await _userService.GetUserByUsernameAsync(usernameToFind);
        }
        catch(Exception e)
        {
            return NotFound(e.Message);
        }
    }



}
