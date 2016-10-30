using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
class Solution
{
    // https://www.hackerrank.com/challenges/two-strings
    static void Main(String[] args)
    {
        int p = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < p; i++)
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();

            if (IsSubstring(a, b))
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }

    static bool IsSubstring(string a, string b)
    {
        var bitArray = new BitArray(26);

        foreach (char c in a)
        {
            bitArray.Set(c - 97, true);
        }

        foreach (char c in b)
        {
            if (bitArray.Get(c - 97))
                return true;
        }

        return false;
    }
}