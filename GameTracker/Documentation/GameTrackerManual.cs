
namespace GameTracker.Documentation;

class GameTrackerManual
{
    public static void UsageInstructions()
    {
        Console.WriteLine("Welcome to GameTraker!\n");
        Console.WriteLine("This app will allow users to track their owned games, when they were purchased, and their cost.");
        Console.WriteLine("If you have never logged into the app before, Choose option 2. New User from the Main Menu.");
        Console.WriteLine("If you have logged in before, Choose option 3 and enter your user name.");
        Console.WriteLine("You will be taken to the Game Menu once you have created a new user or logged in as an existing user.\n");
        Console.WriteLine("On the Game Menu, you can choose to view your exisiting game list, add a new game, or modify the name of an existing one.");
        Console.WriteLine("For a new game, you will enter the game's name, its price, and the date of purchase");
        Console.WriteLine("Modify game will allow you to update the game's stored data.\n\n");
        Console.WriteLine("Choose an option to continue:");
        Console.WriteLine("2. New User 3. Returning User 4. Exit Program");
        Console.Read();
    }
}