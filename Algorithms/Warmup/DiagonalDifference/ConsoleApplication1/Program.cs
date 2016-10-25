using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    // https://www.hackerrank.com/challenges/diagonal-difference
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[][] a = new int[n][];
        for (int a_i = 0; a_i < n; a_i++)
        {
            string[] a_temp = Console.ReadLine().Split(' ');
            a[a_i] = Array.ConvertAll(a_temp, Int32.Parse);
        }

        int sum1 = 0;
        int sum2 = 0;
        for (int i = 0; i < n; i++)
        {
            sum1 += a[i][i];
            sum2 += a[n - i - 1][i];
        }

        int result = Math.Abs(sum1 - sum2);
        Console.WriteLine(result);
    }
}
