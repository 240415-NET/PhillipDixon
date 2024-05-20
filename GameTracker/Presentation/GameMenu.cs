using GameTracker.Controllers;
using GameTracker.Models;
using System.Linq;

namespace GameTracker.Presentation;

public class GameMenu
{

    public static void GameFunctionMenu(User user)
    {
        string userInput;
        bool validInput = false;

        try
        {
            do
            {
                Console.Clear();
                Console.Write("Please select from the following Options:\n1. View List of Games\n2. New Game\n3. Remove Game\n4. Modify Game\n5. Exit Game Tracker\n");

                userInput = Console.ReadLine().Trim().ToLower();
                switch (userInput)
                {
                    case "1":
                        ViewGameMenu(user.userId);
                        break;
                    case "2":
                        NewEntry(user);
                        break;
                    case "3":
                        //***Below line is for the WIP Remove functionality***
                        GameController.RemoveGame(ViewMyGames(user.userId, 1, "Which game would you like to remove"), user, true);
                        break;
                    case "4":
                        //*************************New Modify code WIP************************
                        ModifyGameMenu(user);
                        //*/
                        //Console.WriteLine("Phillip hasn't implemented this yet. Guess you should have entered that info correctly...");
                        //Console.WriteLine("Choose a different option");
                        break;
                    case "5":
                        Console.WriteLine("Thanks for using the GameTracker app! Bye!");
                        return;
                    default:
                        Console.WriteLine("Please key valid option(which is a single digit from 1-5)");
                        break;
                }
            }
            while (validInput == false);
        }

        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    public static void NewEntry(User user)
    {
        bool entrySuccess = false;
        do
        {
            try
            {
                string gameName;
                double originalCost;
                DateTime purchaseDate;

                Console.WriteLine("Enter the name of the game");
                gameName = Console.ReadLine().Trim();
                Console.WriteLine("What was the original cost for your Game? Please enter just the number with no currency sign");
                originalCost = double.Parse(Console.ReadLine().Trim());
                Console.WriteLine("What was the original purchase date of the Game? Please enter with proper formatting -- i.e. 12/25/2001");
                purchaseDate = DateTime.Parse(Console.ReadLine().Trim());
                entrySuccess = true;
                GameController.CreateGame(user, gameName, originalCost, purchaseDate);
                Console.WriteLine("Game added!");
                GameFunctionMenu(user);
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("Please key in a valid input!");
            }
        }
        while (entrySuccess == false);
    }

    public static void ViewGameMenu(Guid userID)
    {
        Guid myReturnedGuid;
        bool exitViewMenu = false;
        do
        {
            Console.Clear();
            Console.WriteLine("Choose an option");
            Console.WriteLine("1. View my Games");
            Console.WriteLine("2. Back to Main Menu");
            string userInput = (Console.ReadLine() ?? "").Trim();
            if (String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("You must provide a number here");
                Console.ReadKey();
                exitViewMenu = false;
            }
            else
            {
                try
                {
                    int userChoice = Convert.ToInt32(userInput);
                    switch (userChoice)
                    {
                        case 1:
                            myReturnedGuid = ViewMyGames(userID, 1);
                            if (myReturnedGuid != Guid.Empty) { ViewSpecifiedGameDetails(userID, myReturnedGuid); }
                            break;
                        case 2:
                            exitViewMenu = true;
                            //Need to figure out how to return to User Menu; may have coded myself into a corner
                            break;
                        default:
                            Console.WriteLine("You're not providing a valid input. Try again.");
                            Console.ReadKey();
                            exitViewMenu = false;
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace.ToString());
                    Console.ReadKey();
                }
            }
        } while (!exitViewMenu);
    }
    public static Guid ViewMyGames(Guid userID, int abbreviatedList = 0, string messageToUser = "Which Game would you like to view?")
    {
        List<Game> allMyGames = GameController.GetGames(userID);
        if (allMyGames.Count() < 1)
        {
            Console.WriteLine("You have not added any games to your list...");
            Console.ReadKey();
        }
        else
        {
            bool exitView = false;
            do
            {
                Console.Clear();
                int loopCount = 1;
                foreach (Game Game in allMyGames)
                {
                    if (abbreviatedList == 0)
                    {
                        Console.WriteLine(Game);
                    }
                    else
                    {
                        Console.WriteLine($"{loopCount}: {Game.AbbrToString()}");
                    }
                    loopCount++;
                }
                Console.WriteLine($"{loopCount}: Exit");
                Console.WriteLine(messageToUser);
                string userInput = (Console.ReadLine() ?? "").Trim();
                try
                {
                    int userChoice = Convert.ToInt32(userInput);
                    if (userChoice == loopCount)
                    {
                        return Guid.Empty;
                    }
                    else if (userChoice <= allMyGames.Count() && userChoice > 0)
                    {
                        return allMyGames[userChoice - 1].gameId;
                    }
                    else
                    {
                        Console.WriteLine("I didn't understand. Pick a number from the list");
                        exitView = false;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Try picking a NUMBER from the provided list.");
                    exitView = false;
                }
            } while (!exitView);
        }
        return Guid.Empty;
    }
    public static void ViewSpecifiedGameDetails(Guid userID, Guid GameID)
    {
        List<Game> allMyGames = GameController.GetGames(userID);
        Console.Clear();
        var SpecificGame = allMyGames.Where(x => x.gameId.Equals(GameID));
        foreach (var thing in SpecificGame)
        {
            Console.WriteLine(thing);
        }
        Console.ReadKey();
    }
    //************************Modify Game code WIP*********************************************
    public static void ModifyGameMenu(User user)
    {
        bool keepGoing = false;
        List<Game> allUsersGames = GameController.GetGames(user.userId);
        List<Game> modifyGameList = new();

        do
        {
            Guid gameId = ViewMyGames(user.userId, 1, "Please select the game you'd like to modify");
            if (gameId == Guid.Empty)
            {
                keepGoing = false;
            }
            else
            {
                Game? gameToBeModified = allUsersGames.FirstOrDefault(x => x.gameId.Equals(gameId));
                ModifyIndividualGameDisplay(gameToBeModified, modifyGameList, user);
                GameController.ModifyGames.ModifyGamesFromList(modifyGameList, user);
                Console.WriteLine("Please press enter to continue modifying, or 0 to exit.");
                string keepModifying = Console.ReadLine() ?? "";
                keepGoing = keepModifying == "";
            }
        }
        while (keepGoing);
    }

    public static List<Game> ModifyIndividualGameDisplay(Game gameToBeModified, List<Game> modifyGameList, User user)
    {
        Console.WriteLine($"Current Game Name: {gameToBeModified.gameName}");
        Console.WriteLine("Please enter the new game name: ");
        string modifiedGameName = Console.ReadLine() ?? "";

        GameController.ModifyGames.ModifyIndividualGame(gameToBeModified, modifiedGameName, modifyGameList);

        return modifyGameList;
    }
    //******************End Modify Game Code WIP**********************************/
}