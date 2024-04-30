using System;
using GroupProject_22APR2024;

namespace GroupProject_22APR2024;

class MealPlanner
{
    public static void EnterMeals()
    {
       List<MealEntry> mealEntries = new List<MealEntry>();
       Console.WriteLine("Please enter your seven meal options for the week");

       for (int entry = 0; entry < 7; entry++)
       {
        Console.WriteLine($"What is meal option {entry+1}?");

        //MealEntries.Add(meal Console.ReadLine());

        string Meal = Console.ReadLine();

        MealEntry newItem = new MealEntry(Meal);
        mealEntries.Add(newItem);

        Console.WriteLine("");

        Console.WriteLine("Added. the current menu entries are:");
        foreach (var item in mealEntries)
        {
            Console.WriteLine(item.Meal);
        }
        Console.WriteLine("");
       }
    }
    public static void MealUpdate()
    {
    
    }
    public static void MealChoice()
    {
    
    
        Console.WriteLine($"OK, let's choose one of the remaining {EnterMeals.mealEntries.Count} items");
        Random rnd = new Random();
        int cm = rnd(List.MealEntries.Count);
        Console.WriteLine($"Tonight's meal will be {cm}");
        Console.WriteLine("");
    }
}