using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    static void Main(String[] args)
    {
        int n = int.Parse(Console.ReadLine());

        var testCases = new string[n];
        for (int i = 0; i < n; i++)
        {
            testCases[i] = Console.ReadLine();
        }

        foreach (string test in testCases)
        {
            Console.WriteLine(GetNumberOfDeletions(test));
        }

#if DEBUG
        Console.WriteLine("END");
        Console.ReadLine();
#endif
    }

    static int GetNumberOfDeletions(string input)
    {
        int counter = 0;

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i - 1] == input[i])
                counter++;
        }

        return counter;
    }
}