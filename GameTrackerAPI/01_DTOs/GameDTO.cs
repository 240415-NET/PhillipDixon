using GameTracker.API.Models;

namespace GameTracker.API.DTOs;

public class GameDTO
{
    public Guid userId { get; set; }
    public Guid itemId { get; set; }
    public string gameName { get; set; }
    public double originalCost { get; set; }
    public DateTime purchaseDate { get; set; }

    public GameDTO() { }

    public GameDTO(Game game)
    {
        userId = game.user.userId;
        itemId = game.gameId;
        gameName = game.gameName;
        originalCost = game.originalCost;
        purchaseDate = game.purchaseDate;

    }
}