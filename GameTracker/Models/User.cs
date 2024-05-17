namespace GameTracker.Models;

public class User 
{
    public Guid userId {get; set;}
    public string userName {get; set;}
    public User() 
    {
        
    }
    public User(string _userName)
    {
        userId = Guid.NewGuid();
        userName = _userName;
    }
}
