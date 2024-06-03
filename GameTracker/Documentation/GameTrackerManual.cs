
using System.Runtime.InteropServices;

namespace GameTracker.Documentation;

class GameTrackerManual
{
    public static void UsageInstructions()
    {
        Console.Clear();
        Console.WriteLine("***************************");
        Console.WriteLine("* Welcome to GameTracker! *");
        Console.WriteLine("***************************\n\n");
        Console.WriteLine("This app will allow users to track their owned games, when they were purchased, and their cost.\n");
        Console.WriteLine("If you have never logged into the app before, Choose option 2. New User from the Main Menu.");
        Console.WriteLine("If you have logged in before, Choose option 3 and enter your user name.");
        Console.WriteLine("You will be taken to the Game Menu once you have created a new user or logged in as an existing user.\n");
        Console.WriteLine("On the Game Menu, you can choose to view your exisiting game list, add a new game, or modify the name of an existing one.");
        Console.WriteLine("For a new game, you will enter the game's name, its price, and the date of purchase");
        Console.WriteLine("Modify game will allow you to update the game's stored data.");
        Console.WriteLine("If you want to play a game but can't make up your mind, let GameTracker do it for you with the \"What should I play?\" Option!\n\n");
    }
}