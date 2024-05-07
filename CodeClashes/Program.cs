using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main()
    {
        string output = "";
        int count = int.Parse(Console.ReadLine());
        string[] inputs = Console.ReadLine().Split(' ');
        string summation = 0;
        char unaryChar = 0;

        for (int i = 0; i < count; i++)
        {
            string unary = inputs[i];

            output += unary;
        
        }

        // Write an answer using Console.WriteLine()
        // To debug: Console.Error.WriteLine("Debug messages...");

        Console.WriteLine(output);
    }
}