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
                        DeleteGameMenu(user);
                        break;
                    case "4":
                        ModifyGameMenu(user);
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
                //GameFunctionMenu(user);
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
        Game myReturnedGame;
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
                            myReturnedGame = ViewMyGames(userID, 1);
                            if (myReturnedGame.gameId != Guid.Empty) { ViewSpecifiedGameDetails(userID, myReturnedGame); }
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
    public static Game ViewMyGames(Guid userID, int abbreviatedList = 0, string messageToUser = "Which Game would you like to view?")
    {
        List<Game> allMyGames = GameController.GetGames(userID);
        if (allMyGames.Count < 1)
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
                        return new Game();
                    }
                    else if (userChoice <= allMyGames.Count() && userChoice > 0)
                    {
                        return allMyGames[userChoice - 1];
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
        return new Game();
    }
    public static void ViewSpecifiedGameDetails(Guid userID, Game Game)
    {
        List<Game> allMyGames = GameController.GetGames(userID);
        Console.Clear();
        Console.WriteLine(Game);
        Console.ReadKey();
    }
    public static void DeleteGameMenu(User user)
    {
        List<Game> allUsersGames = GameController.GetGames(user.userId);
        List<Game> modifyGameList = new();
        Game removeGame = ViewMyGames(user.userId, 1, "Please select the game you'd like to remove");
        GameController.RemoveGame(removeGame);
        //Game? gameToBeDeleted = allUsersGames.FirstOrDefault(x => x.gameId.Equals(gameId));

    }
        public static void ModifyGameMenu(User user)
    {
        //List<Game> allUsersGames = GameController.GetGames(user.userId);

        Game gameToBeModified = ViewMyGames(user.userId, 1, "Please select the game you'd like to modify");
        //Game? gameToBeModified = allUsersGames.FirstOrDefault(x => x.gameId.Equals(modifyGameId));
        ModifyIndividualGameDisplay(gameToBeModified, user);
    }
    public static void ModifyIndividualGameDisplay(Game gameToBeModified, User user)
    {
        bool keepModifying = true;
        bool isValid = false;

        Game modifiedGame = new Game();
        modifiedGame.gameId = gameToBeModified.gameId;
        modifiedGame.gameName = gameToBeModified.gameName;
        modifiedGame.originalCost = gameToBeModified.originalCost;
        modifiedGame.purchaseDate = gameToBeModified.purchaseDate;
        do
        {
            Console.WriteLine("Please select which value you'd like to modify:");
            Console.WriteLine($"1. Game Name: {modifiedGame.gameName}");
            Console.WriteLine($"2. Original Cost: {modifiedGame.originalCost}");
            Console.WriteLine($"3. Purchase Date: {modifiedGame.purchaseDate}");
            Console.WriteLine("0. Finished modifying");
            try
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        {
                            Console.WriteLine("Please enter the new value: ");
                            string modifiedValue = Console.ReadLine() ?? "";
                            modifiedGame.gameName = modifiedValue;
                            isValid = true;
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Please enter the new number with no currency sign");
                            double modifiedValue = double.Parse(Console.ReadLine() ?? "");
                            modifiedGame.originalCost = modifiedValue;
                            isValid = true;
                            break;
                        }
                    case "3":
                        {
                            Console.WriteLine($"Please enter the new value with proper formatting -- i.e. 12/25/2001");
                            DateTime modifiedValue = DateTime.Parse(Console.ReadLine().Trim());
                            modifiedGame.purchaseDate = modifiedValue;
                            isValid = true;
                            break;
                        }
                    case "0":
                        {
                            keepModifying = false;
                            isValid = true;
                            break;
                        }
                    default:
                        {
                            isValid = false;
                            break;
                        }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("You've entered an invalid value. Please verify you'd entered the correct format.\n");
            }
        }
        while (keepModifying || !isValid);

        GameController.ModifyGame(modifiedGame);
    }
}