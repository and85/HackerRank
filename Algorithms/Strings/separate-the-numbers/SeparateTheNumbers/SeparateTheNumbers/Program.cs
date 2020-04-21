using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Solution
{
    // https://www.hackerrank.com/challenges/separate-the-numbers/problem
    public static void Main(String[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < q; a0++)
        {
            string s = Console.ReadLine();

            if (IsBeautiful(s))
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }

    public static bool IsBeautiful(string s)
    {
        int prev = -1;

        for (int i = 0; i< s.Length; i++)
        {
            int digit = int.Parse(s[i].ToString());

            if (digit != 0)
            {
                if (prev != -1)
                {
                    if (digit - prev == 1)
                        prev = digit;
                    else
                        return false;
                }
                else
                    prev = digit;
            }
        }

        return true;
    }
}
