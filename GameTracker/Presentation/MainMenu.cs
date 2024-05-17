using System.Net;
using GameTracker.Controllers;
using GameTracker.Models;
using GameTracker.Documentation;

namespace GameTracker.Presentation;

public class MainMenu
{
    public static User existingUser = new();

    public static void StartMenu()
    {
        int userChoice = 0;
        bool validInput = true;

        Console.WriteLine("Welcome to Gametracker!");
        Console.WriteLine("1. Intructions for use");
        Console.WriteLine("2. New user");
        Console.WriteLine("3. Returning user");
        Console.WriteLine("4. Exit program");

        do
        {
            try
            {
                userChoice = Convert.ToInt32(Console.ReadLine());
                validInput = true;

                switch (userChoice)
                {
                    case 1:
                        GameTrackerManual.UsageInstructions();
                        break;
                    case 2:
                        UserCreationMenu();
                        GameMenu.GameFunctionMenu(existingUser);
                        break;
                    case 3:
                        UserLoginMenu();
                        GameMenu.GameFunctionMenu(existingUser);
                        break;
                    case 4:
                        return;
                    /**********add an "Easter Egg" if I have time...************
                    case "Meeple":
                    ⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⣀⣀⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀           Console.WriteLine("            ⢠⣾⣿⣿⣿⣿⣷⡄");⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀           Console.WriteLine(            ⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀")';⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀                 Console.WriteLine(       ⢀⣠⣴⣾⣿⣿⣿⣿⣿⣿⣿⣿⣷⣦⣄⡀⠀⠀");⠀⠀⠀⠀⠀
⠀⠀⠀⠀                    Console.WriteLine(   ⣠⣴⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⣦⣄⠀⠀");⠀
⠀⠀                    Console.WriteLine(   ⢠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡄⠀⠀");
⠀⠀                    Console.WriteLine(⠘⠻⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠟⠃⠀⠀");
⠀⠀⠀⠀⠀⠀                     Console.WriteLine(⠉⣽⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣯⠉⠀⠀⠀⠀");⠀⠀
                        ⠀⠀⠀Console.WriteLine(⢠⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡄⠀⠀⠀⠀");⠀
                        ⠀⠀Console.WriteLine(⣴⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣦⠀⠀⠀");⠀
                        Console.WriteLine(⢀⣾⣿⣿⣿⣿⣿⣿⣿⣿⣿⠏⠀⠀⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⣷⡀⠀");⠀
                        Console.WriteLine(⢸⣿⣿⣿⣿⣿⣿⣿⣿⣿⠏⠀⠀⠀⠀⠹⣿⣿⣿⣿⣿⣿⣿⣿⣿⡇⠀");⠀
                        Console.WriteLine(⠈⠉⠉⠉⠉⠉⠉⠉⠉⠉⠀⠀⠀⠀⠀⠀⠉⠉⠉⠉⠉⠉⠉⠉⠉⠁");

                    Console.WriteLine("Congratulations, you found the hidden Meeple! Hit any key to return to the menu.");
                    return.
                    */
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
            Console.WriteLine("Please enter a username: ");

            userInput = Console.ReadLine() ?? "";

            userInput = userInput.Trim();

            if (String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Username cannot be blank, please try again.");
                validInput = false;
            }
            else if (UserController.UserExists(userInput))
            {
                Console.WriteLine("Username already exists, please choose another.");
                validInput = false;
            }
            else
            {
                existingUser = UserController.CreateUser(userInput);
                Console.WriteLine("Profile created!");
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
            Console.WriteLine("Please enter a username: ");

            userInput = Console.ReadLine() ?? "";

            userInput = userInput.Trim();

            if (String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Username cannot be blank, please try again.");
                validInput = false;
            }
            else if (!UserController.UserExists(userInput))
            {
                Console.WriteLine("Username doesn't exist, please choose another.");
                validInput = false;
            }
            else
            {
                existingUser = UserController.ReturnUser(userInput);
                Console.WriteLine("You're logged in!");
                Console.WriteLine($"Username: {existingUser.userName}");
                Console.WriteLine($"User Id: {existingUser.userId}");
                validInput = true;
            }
        } while (!validInput);
    }
}