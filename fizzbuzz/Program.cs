/*
For this activity, I want you to print out the number 1-100 (inclusive, as in include the number 100)

If a number is divisible by 3, print "fizz" instead of the number. So

1
2
fizz
4
etc

If a number is divisible by 5, print buzz

3
4
buzz
etc

If a number is divisible by both, print fizzbuzzdotnet 

13
14
fizzbuzz
16
etc
*/

using System;

namespace fizzbuzz;

public class Program
{
    public static void Main()
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