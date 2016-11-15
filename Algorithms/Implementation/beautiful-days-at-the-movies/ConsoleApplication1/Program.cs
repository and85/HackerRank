using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    // https://www.hackerrank.com/challenges/beautiful-days-at-the-movies
    static void Main(String[] args)
    {
        string input = Console.ReadLine();
        int i = Convert.ToInt32(input.Split(' ')[0]);
        int j = Convert.ToInt32(input.Split(' ')[1]);
        int k = Convert.ToInt32(input.Split(' ')[2]);

        int counter = 0;

        for (int a = i; a <= j; a++)
        {
            double d = (double)(a - Reverse(a)) / k;
            if (IsEval(d))
                counter++;
        }

        Console.WriteLine(counter);

#if DEBUG
        Console.WriteLine("END");
        Console.ReadLine();
#endif
    }

    static int Reverse(int x)
    {
        string original = x.ToString();
        // since x is quite short, it's more efficient to use string but not StringBuilder here
        string reversed = string.Empty;

        for (int i = original.Length - 1; i >= 0; i--)
        {
            reversed += original[i];
        }

        return int.Parse(reversed);
    }

    static bool IsEval(double d)
    {
        return (d % 1) == 0;
    }
}