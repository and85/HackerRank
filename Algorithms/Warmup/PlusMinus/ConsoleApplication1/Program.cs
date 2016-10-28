using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static void PrintFractions(int[] arr, int n)
    {
        int positiveCount = 0, negativeCount = 0, zeroCount = 0;
        foreach (int element in arr)
        {
            if (element > 0)
                positiveCount++;
            else if (element < 0)
                negativeCount++;
            else
                zeroCount++;
        }

        decimal positiveFraction    = (decimal)positiveCount / n;
        decimal negativeFraction    = (decimal)negativeCount / n;
        decimal zeroFraction        = (decimal)zeroCount / n;

        Console.WriteLine("{0:N6}", positiveFraction);
        Console.WriteLine("{0:N6}", negativeFraction);
        Console.WriteLine("{0:N6}", zeroFraction);
    }

    // https://www.hackerrank.com/challenges/plus-minus
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);

        PrintFractions(arr, n);
    }
}
