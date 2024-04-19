using System;

namespace MethodExceptionDemo;

class Program
{
    static void Main(string[] args)
    {
            int firstNum = 0;
            int secondNum =0;
            bool caught = false;
            int sum = 0;

        //we call a method by referencing its name.
        //arguments for that method are separated by a comma
        //these argments can be fields (or even other methods)

        do
        {
            try //the code to make sure doesn't crash
            {
                Console.WriteLine("Please enter a number: ");
                int firstNum = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Please enter a number: ");
                int secondNum = Convert.ToInt32(Console.ReadLine());

                sum AddTwoNumbers(firstNum, secondNum);
            }
            catch (Exception myException) //catching potential exception, do something if/when we do
            {
                Console.WriteLine($"{myException.Message}");
                Console.WriteLine("Please make sure to enter and integer value!");

                caught = true;
            }
            finally //this is optional, this code will execute regardless of an exception running or not
            {
                if(caught)
                {
                    Console.WriteLine("Program ran despite exception");
                }
            else
                {
                Console.WriteLine("Program ran without exception!");
                }
            }

        int sum = Program.AddTwoNumbers(firstNum, secondNum);
    
        //This is an example of string interpolation using $
        //we can call methods w/i the curly braces
        Console.WriteLine($"The sum of {firstNum} and {secondNum} is:" + sum);
    }
//(access modifier) (return type) (name of method) ((what method is expecting you to give it))
//access modifiers
//static
//return types
//void-
//int-
static int AddTwoNumbers(int num1, int num2)
    {
        int sum = num1 + num2;

        return sum;
    }
}