using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    //https://www.hackerrank.com/challenges/sherlock-and-array
    static void Main(String[] args)
    {
        int t = int.Parse(Console.ReadLine());

        for (int i = 0; i < t; i++)
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = (from s in Console.ReadLine().Split() select Convert.ToInt32(s)).ToArray();

            if (IsElementExist(n, array))
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }

    static bool IsElementExist(int n, int[] array)
    {
        var leftSums = new int[n];
        var rightSums = new int[n];

        int leftSum = 0;
        int rightSum = 0;
        for (int i = 0, j = n - 1; i < n; i++, j--)
        {
            leftSum += array[i];
            leftSums[i] = leftSum;

            rightSum += array[j];
            rightSums[j] = rightSum;
        }

        for (int i = 0; i < n; i++)
        {
            if (leftSums[i] == rightSums[i])
                return true;
        }

        return false;
    }
}