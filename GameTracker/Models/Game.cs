namespace GameTracker.Models;

public class Game
{
    public Guid userId {get; set;}
    public Guid gameId {get; set;}
    public string gameName {get; set;}
    public double originalCost {get; set;}
    public DateTime purchaseDate {get; set;}

    //Constructors 
    public Game() { }
    
    public Game(Guid _userId, string _gameName, double _originalCost, DateTime _purchaseDate) 
    {
            userId = _userId;
            gameId = Guid.NewGuid();
            gameName = _gameName;
            originalCost = _originalCost;
            purchaseDate = _purchaseDate;
    }

    public override string ToString()
    {
        return $"Category: {gameName}\nOriginal Cost: {originalCost}\nPurchase Date: {purchaseDate}";
    }
    public string AbbrToString()
    {
        return String.Format("gameName: {0,-25}   Purchase Date: {1,10:d}   Original Cost: {2,-12:C2}",gameName,purchaseDate,originalCost);
    }
}