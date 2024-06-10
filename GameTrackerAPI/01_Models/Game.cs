using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using GameTracker.API.DTOs;
using Microsoft.AspNetCore.Http.Features;


namespace GameTracker.API.Models;

public class Game
{
    public User user { get; set; } = new();
    [Key]
    public Guid gameId { get; set; }
    public string gameName { get; set; }
    public double originalCost { get; set; }
    public DateTime purchaseDate { get; set; }

    //Constructors 
    public Game() { }

    public Game(GameDTO game, User owner)
    {
        user = owner;
        gameId = Guid.NewGuid();
        gameName = game.gameName;
        originalCost = game.originalCost;
        purchaseDate = game.purchaseDate;
    }
    public Game(string _gameName, double _originalCost, DateTime _purchaseDate)
    {
        gameId = Guid.NewGuid();
        gameName = _gameName;
        originalCost = _originalCost;
        purchaseDate = _purchaseDate;
    }

    public override string ToString()
    {
        return $"Game Name: {gameName}\nOriginal Cost: {originalCost}\nPurchase Date: {purchaseDate}";
    }
    public string AbbrToString()
    {
        return String.Format("gameName: {0,-25}   Purchase Date: {1,10:d}   Original Cost: {2,-12:C2}", gameName, purchaseDate, originalCost);
    }
}