
using GameTracker.Controllers;
using GameTracker.Models;
using GameTracker.Documentation;

namespace GameTracker.Presentation;

public class MainMenu
{
    public static User existingUser = new();

    public static void StartMenu()
    {
        string userChoice = "";
        bool validInput = true;

//clear the console of any of the "yellow messages" that appear on run
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("***************************");
        Console.WriteLine("* Welcome to GameTracker! *");
        Console.WriteLine("***************************");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("   .-------.    ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("______\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("  /   o   /|   ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("/\\     \\\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(" /_______/o|  ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("/o \\  o  \\\n");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(" | o     | | ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("/   o\\_____\\\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(" |   o   |o/ ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("\\o   /o   o/\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(" |     o |/   ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("\\ o/  o  /\n");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(" '-------'     ");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("\\/o___o/\n");
        Console.ResetColor();
        Console.WriteLine("");
        Console.WriteLine("Choose an option below to get started!");
        Console.WriteLine("");
        Console.WriteLine("1. Intructions for use");
        Console.WriteLine("2. New user");
        Console.WriteLine("3. Returning user");
        Console.WriteLine("4. Exit program");

        do
        {
            try
            {
                //used a string for userChoice instead of an int because I had planned to add an "easter egg" that was a word, but never did get to it. 
                userChoice = Console.ReadLine().Trim().ToLower();
                validInput = true;

                switch (userChoice)
                {
                    case "1":
                        GameTrackerManual.UsageInstructions();//currently only item in "Documentataion layer"
                        validInput = false;
                        Console.WriteLine("Choose an option to continue:");
                        Console.WriteLine("2. New User 3. Returning User 4. Exit Program");
                        break;
                    case "2":
                        UserCreationMenu();// currently another method in main menu.cs; may see if breaking onto a new sheet is better
                        GameMenu.GameFunctionMenu(existingUser);
                        break;
                    case "3":
                        UserLoginMenu();// currently another method in main menu.cs; may see if breaking onto a new sheet is better
                        GameMenu.GameFunctionMenu(existingUser);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Please enter a valid choice!");
                        validInput = false;
                        break;
                }

            }
            catch (Exception ex)
            {
                validInput = false;
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Please enter a valid choice!");
            }

        } while (!validInput);
    }
    public static void UserCreationMenu()
    {
        bool validInput = true;
        string userInput = "";

        do
        {
            Console.WriteLine("What is your name?");

            userInput = Console.ReadLine() ?? "";//ensures hitting enter with no entered chars returns as an empty string

            userInput = userInput.Trim();

            if (String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Who do you think you are, Clint Eastwood? You need a name. Try again.");
                validInput = false;
            }
            else if (UserController.UserExists(userInput))
            {
                Console.WriteLine("Someone with that name is already using the app. Choose another name.");
                validInput = false;
            }
            else
            {
                existingUser = UserController.CreateUser(userInput);//call to the controller layer after input validation
                Console.WriteLine("You've been added!");
                validInput = true;

            }

        } while (!validInput);
    }
    public static void UserLoginMenu()
    {
        bool validInput = true;
        string userInput = "";

        do
        {
            Console.WriteLine("What is your name?");

            userInput = Console.ReadLine() ?? ""; //ensures hitting enter with no entered chars returns as an empty string
            userInput = userInput.Trim();

            if (String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Surely you have a name. Try again.");
                validInput = false;
            }
            else if (!UserController.UserExists(userInput))
            {
                Console.WriteLine($"Sorry, {userInput}'s not here. Try another name.");
                validInput = false;
            }
            else
            {
                existingUser = UserController.ReturnUser(userInput);//call to the controller layer after input validation
                Console.WriteLine("You're logged in!");
                Console.WriteLine($"Username: {existingUser.userName}");
                Console.WriteLine($"User Id: {existingUser.userId}");
                validInput = true;
                Console.Clear();
            }
        } while (!validInput);
    }
}