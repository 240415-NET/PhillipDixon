namespace GameTracker.API.Models;

public class User 
{
    public Guid userId {get; set;}
    public string userName {get; set;}
    public List<Game> games {get; set;} = new();

    public User() {}
    public User(string _userName)
    {
        userId = Guid.NewGuid();
        userName = _userName;
    }
}