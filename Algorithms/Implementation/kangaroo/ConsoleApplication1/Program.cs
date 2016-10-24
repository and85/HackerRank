using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    // https://www.hackerrank.com/challenges/kangaroo
    static void Main(String[] args)
    {
        string[] tokens_x1 = Console.ReadLine().Split(' ');
        int x1 = Convert.ToInt32(tokens_x1[0]);
        int v1 = Convert.ToInt32(tokens_x1[1]);
        int x2 = Convert.ToInt32(tokens_x1[2]);
        int v2 = Convert.ToInt32(tokens_x1[3]);

        if (CanMeet(x1, v1, x2, v2))
            Console.WriteLine("YES");
        else
            Console.WriteLine("NO");
    }

    static bool CanMeet(int x1, int v1, int x2, int v2)
    {
        if (x2 > x1 && v2 >= v1)
            return false;

        decimal t = (decimal)(x2 - x1) / (v1 - v2);
        return t % 1 == 0;
    }
}
