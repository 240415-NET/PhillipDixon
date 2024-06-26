


using System.ComponentModel;
using Project1.Controllers;

namespace Project1.Presentation;

public class Menu
{
   
   //This method displays the initial menu when the user runs the program
    public static void StartMenu() 
    {
        int userChoice = 0;
        bool validInput = true;

        Console.WriteLine("Welcome to GameTracker!");
        Console.WriteLine("1. RTFM (Read the First-timer's Manual ;-P)");
        Console.WriteLine("2. Add a New Player");
        Console.WriteLine("3. Returning user");
        Console.WriteLine("4. Exit program");
        
        //Setting up the try-catch to handle user input with
        //do-while to let them try again
        do
        {
            try
            {
                userChoice = Convert.ToInt32(Console.ReadLine());
                validInput = true;

                switch (userChoice)
                {
                    case 1:// Go to instructions for use
                        //Instructions method
                        break;
                    case 2: // Creating a new user profile
                        UserCreationMenu();
                        break;
                    case 3:
                        UserLoginMenu();
                        break;

                    case 4: //User chooses to exit the program
                        return; //This return exits this method, and returns us to where it was called.
                    
                    case 5: //add an Easter Egg (TBC)
                        //Add the Easter Egg
                        break;
                    default: // If the user enters an integer that is not 1, 2, 3, or 4
                        Console.WriteLine("Please enter a valid choice! (are you trying to find an Easter Egg?)");
                        validInput = false;
                        break;
                }

            }
            catch (Exception ex) 
            {   
                validInput = false;
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Please enter a valid choice! (from the catch)");
            }

        } while (!validInput);

        
    }

    //This method handles the prompts for creating a new user profile
    public static void UserCreationMenu() 
    {
        //We want to ask for a user name

        //We want to make sure the user did not just hit enter and provide a null or empty string

        //We want to call the Controller's UserExists() method to see if a given username is already taken

        //If it is taken, we prompt the user to try again with a new username. 

        //Pass the username to the controller

        /*
            Lets sketch out the logic here

            We are going to need a boolean "flag" 

            do-while loop checking against our flag
                {
                    check if the given input is null or empty
                        if-else to check if our input is null or empty
                    
                    assuming our input is valid according to our business rules (since we set 
                    the requirement that you cannot have a blank username)

                    we then want to check if a given username exists using the UserExists method 
                    in the UserController
                        if the name isn't taken, great
                        if the name IS taken, then prompt the user to try again
                } 
            We stay in the do-while until the input passes both checks.
        */

        //Declaring our flag boolean outside of our loop, setting it to true
        bool validInput = true;
        string userInput = "";

        do
        {   
            //Prompting the user for a username
            Console.WriteLine("Please enter a username: ");

            //The ?? is called the null-coalescing operator
            //If the input comes back null, then we manually set it to an empty string - to avoid 
            //the possibility of this userInput string ever being null. 
            userInput = Console.ReadLine() ?? "";

            //Here we are going to trim the string, to remove any leading or trailing spaces
            userInput = userInput.Trim();

            //If else to check both of our conditions - empty string and existing username
            if(String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Username cannot be blank, please try again.");
                validInput = false;
            }else if(UserController.UserExists(userInput))
            {
                Console.WriteLine("Username already exists, please choose another.");
                validInput = false;
            }else{ //If neither check trips we simply call CreateUser from the UserController!
                UserController.CreateUser(userInput);
                Console.WriteLine("Profile created!");
                validInput = true;
            }

        } while (!validInput); //Continue running the above block UNTIL input is valid

    }


public static void UserLoginMenu() 
    {
 
        //Declaring our flag boolean outside of our loop, setting it to true
        bool validInput = true;
        string userInput = "";

        do
        {   
            //Prompting the user for a username
            Console.WriteLine("Please enter a username: ");

            //The ?? is called the null-coalescing operator
            //If the input comes back null, then we manually set it to an empty string - to avoid 
            //the possibility of this userInput string ever being null. 
            userInput = Console.ReadLine() ?? "";

            //Here we are going to trim the string, to remove any leading or trailing spaces
            userInput = userInput.Trim();

            //If else to check both of our conditions - empty string and existing username
            if(String.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Username cannot be blank, please try again.");
                validInput = false;
            }else if(!UserController.UserExists(userInput)) //if User doesn't exist
            {
                Console.WriteLine("Username doesn't exist, please choose another.");
                validInput = false;
            }else{ //If neither check trips we simply call CreateUser from the UserController!
                User existingUser = UserController.ReturnUser(userInput);
                Console.WriteLine("You're logged in!");
                Console.WriteLine($"Username: {existingUser.userName}");
                Console.WriteLine($"User Id: {existingUser.userId}");
                validInput = true;
                //ItemMenu.ItemFunctionMenu(existingUser); //new line for calling item functionality menu
            }

        } while (!validInput); //Continue running the above block UNTIL input is valid

    }


    
    
}