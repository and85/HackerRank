using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    // https://www.hackerrank.com/contests/w25/challenges/between-two-sets
    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int m = Convert.ToInt32(tokens_n[1]);
        string[] a_temp = Console.ReadLine().Split(' ');
        int[] a = Array.ConvertAll(a_temp, Int32.Parse);
        string[] b_temp = Console.ReadLine().Split(' ');
        int[] b = Array.ConvertAll(b_temp, Int32.Parse);

        //string[] a_temp = "2 4 7".Split(' ');
        //string[] b_temp = "16 32 96".Split(' ');
        //int[] a = Array.ConvertAll(a_temp, Int32.Parse);
        //int[] b = Array.ConvertAll(b_temp, Int32.Parse);

        int number = FactorsNumber(a, b);
        Console.WriteLine(number);
    }

    static int FactorsNumber(int[] a, int [] b)
    {
        var uniqueFactors = new HashSet<int>();

        int minElement = b.Min();

        for (int i = 0; i < b.Length; i++)
        for (int j = 0; j < a.Length; j++)
            {
                decimal factor = (decimal)b[i] / a[j];

                if (IsInteger(factor) && factor <= minElement)
                    uniqueFactors.Add((int)factor);

                if (!IsInteger(factor))
                    return 0;
            }

        return uniqueFactors.Count;
    }

    private static bool IsInteger(decimal factor)
    {
        return (factor % 1) == 0;
    }
}
