using System;

namespace GroupProject_22APR2024;

class FizzBuzz
{
public static void DoFizzBuzz()
    {
         for (int i = 1; i <= 100; i++) //start at 1, loop to 100
            {
                if (i % 3 == 0 && i % 5 == 0) //for the #'s evenly divisible by 3 and 5
                {
                    Console.WriteLine("FizzBuzz");
                }
                else if (i % 3 == 0) //for the #'s evenly divisible by 3 only
                {
                    Console.WriteLine("Fizz");
                }
                else if (i % 5 == 0) //for the #'s evenly divisible by 5 only
                {       
                    Console.WriteLine("Buzz");
                }
                else
                {
                    Console.WriteLine(i); //for all other #'s
                }
            }
    }
}