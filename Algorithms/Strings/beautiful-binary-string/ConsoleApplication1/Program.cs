using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static int CountSteps(string b, int n)
    {
        int result = 0;
        char[] bc = b.ToCharArray();

        for (int i = 2; i < n; i++)
        {
            if (bc[i - 1] == '1' && bc[i - 2] == '0' && bc[i] == '0')
            {
                bc[i] = '1';
                result++;
            }
        }

        return result;
    }

    // https://www.hackerrank.com/challenges/beautiful-binary-string
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string B = Console.ReadLine();

        Console.WriteLine(CountSteps(B, n));
    }
}
