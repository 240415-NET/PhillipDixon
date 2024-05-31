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
    public async Task<ActionResult<User>> PostNewUser(User newUserSentFromFrontEnd)
    {
        try
        {
            await _userService.CreateNewUserAsync(newUserSentFromFrontEnd);

            return Ok(newUser);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
