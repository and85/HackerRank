using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    // https://www.hackerrank.com/challenges/staircase
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string line = string.Empty.PadLeft(n - i - 1, ' ') + string.Empty.PadLeft(i + 1, '#');
            Console.WriteLine(line);
        }
    }
}
