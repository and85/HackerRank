using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static bool IsFunny(string input)
    {
        if (input.Length == 1)
            return true;

        var reversedArray = new char[input.Length];
        reversedArray = input.ToCharArray();
        Array.Reverse(reversedArray);

        for (int i = 1; i < input.Length; i++ )
        {
            if (Math.Abs(input[i] - input[i - 1]) != 
                Math.Abs(reversedArray[i] - reversedArray[i - 1]))
                return false;
        }

        return true;
    }
    
    //https://www.hackerrank.com/challenges/funny-string
    static void Main(String[] args)
    {
        int n = int.Parse(Console.ReadLine());

        var input = new List<string>();
        for (int i = 0; i < n; i++)
        {
            input.Add(Console.ReadLine());
        }

        foreach (string item in input)
        {
            if (IsFunny(item))
                Console.WriteLine("Funny");
            else
                Console.WriteLine("Not Funny");
        }
    }
}