using Microsoft.AspNetCore.Mvc;
using GameTracker.API.Models;


namespace GameTracker.API.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemController(IItemService itemServicefromBuilder)
    {
        _itemService = itemServicefromBuilder;
    }

    [HttpPost("/Item")]
    public async Task<ActionResult>
}