using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    // https://www.hackerrank.com/contests/w25/challenges/append-and-delete
    static void Main(String[] args)
    {
        string s = Console.ReadLine();
        string t = Console.ReadLine();
        int k = Convert.ToInt32(Console.ReadLine());

        if (IsPossible(s, t, k))
            Console.WriteLine("Yes");
        else
            Console.WriteLine("No");

#if DEBUG
        Console.ReadLine();
        Console.WriteLine("END");
#endif
    }

    static bool IsPossible(string s, string t, int k)
    {
        if (t.Length - s.Length > k)
            return false;

        if (t.Length + s.Length <= k)
            return true;

        int matchedLength = CommonSubstringLength(s, t);
        int sNotMatchedLength = s.Length - matchedLength;
        int tNotMatchedLength = t.Length - matchedLength;

        if (sNotMatchedLength + tNotMatchedLength > k)
            return false;

        int symbolsToBeAdded = k - sNotMatchedLength;

        if ((IsEven(symbolsToBeAdded) && IsEven(tNotMatchedLength))
            || (!IsEven(symbolsToBeAdded) && !IsEven(tNotMatchedLength)))
            return true;

        return false;
    }

    static int CommonSubstringLength(string s, string t)
    {
        int matchedLenght = 0;

        for (int i = 0; i < s.Length; i++)
        {
            if (t.Length <= i || s[i] != t[i])
                break;

            matchedLenght++;
        }

        return matchedLenght;
    }

    static bool IsEven(int x)
    {
        return x % 2 == 0;
    }
}
