using System;

namespace GroupProject_22APR2024;

class Program

{
    public static void Main()
    {
        //variables declared up front
        bool exitProgram = false;
        //string[] mealOptions = new string[7];
        //bool mealsChosen = false;
        do //do-wile loop to list out menu options
        {
            Console.WriteLine("Please Select an Option");
            Console.WriteLine("1. Run 'Hello World!'");
            Console.WriteLine("2. Run 'FizzBuzz'");
            Console.WriteLine("3. Weekly Meal Planner Entry");
            Console.WriteLine("4. Weekly Meal Planner Update");
            Console.WriteLine("5. Weekly Meal Planner Selection");
            Console.WriteLine("6. Exit Program");
            try //code for option selections. Includes code to catch invalid entries.
            {
                int menuSelection = Convert.ToInt32(Console.ReadLine()); //take entry and attempt to convert to an int32
                switch(menuSelection)
                {
                    case 1: 
                        Console.WriteLine("Thanks for choosing a valid option. Running 'Hello World!' which just writes the text Hello World!");
                        HelloWorld.ItsJustHelloWorld();  //calls HelloWorld.cs
                        break;
                    case 2:
                        Console.WriteLine("Thanks for choosing a valid option."); 
                        Console.WriteLine("Running 'FizzBuzz' which writes #'s from 1 to 100");
                        Console.WriteLine("replacing multiples of 3 with 'Fizz', of 5 with 'Buzz', and of both with 'FizzBuzz'");
                        Console.WriteLine("");
                        FizzBuzz.DoFizzBuzz(); //calls Fizzbuzz.cs
                        Console.WriteLine("");
                        break;
                    case 3:
                        Console.WriteLine("Thanks for choosing the Weekly Meal Planner Entry option!");
                        MealPlanner.EnterMeals();
                        break;
                    case 4:
                        Console.WriteLine("Thanks for choosing the Weekly Meal Planner Update option!");
                        Console.WriteLine("Here you can update your meal options");
                        MealPlanner.MealUpdate();
                        break;
                     case 5:
                        Console.WriteLine("Thanks for choosing the Weekly Meal Planner Selection option!");
                        Console.WriteLine("Here you can randomly select one of your entered meal options");
                        MealPlanner.MealChoice();
                        break;
                     case 6:
                        exitProgram = true;
                        break;         
                    default://if any invalid option is selected from the menu
                        Console.WriteLine("That is not a valid option, please try again");
                        break;
                }
            }
            catch (System.Exception oops)
            {
                bool didUserRespondCorrectly = false;
                Console.WriteLine($"{oops.Message}");
                Console.WriteLine("Please enter a valid whole number");
            do
            {
                Console.WriteLine("Do you want to try again? (Y/N)");
                string userResponse = Console.ReadLine();
                if (String.IsNullOrEmpty(userResponse) || (userResponse.ToUpper() != "Y" && userResponse.ToUpper() != "N"))
                {
                    Console.WriteLine("You must provide a Y or N response");
                }
                else if (userResponse.ToUpper() == "N")
                {
                    exitProgram = true;
                    didUserRespondCorrectly = true;
                }
                else
                {
                    Console.Clear();
                    didUserRespondCorrectly = true;
                }
            }while(didUserRespondCorrectly == false);
            }
        } while(exitProgram ==false);
    }
}
