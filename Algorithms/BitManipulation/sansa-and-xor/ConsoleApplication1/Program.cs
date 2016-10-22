using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    // https://www.hackerrank.com/challenges/sansa-and-xor
    static void Main(String[] args)
    {
        int t = int.Parse(Console.ReadLine());

        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            arr = Console.ReadLine()
                .Split(' ')
                .Select(x => int.Parse(x))
                .ToArray();

            int result = GetXorOfSubsets(arr, n);
            Console.WriteLine(result);
        }
    }

    static int GetXorOfSubsets(int[] arr, int n)
    {
        int result = 0;

        if (n % 2 == 0)
            return 0;

        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
                result ^= arr[i];
        }

        return result;
    }
}