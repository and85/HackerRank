using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    //https://www.hackerrank.com/challenges/balanced-brackets
    static void Main(String[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine());
        for (int a0 = 0; a0 < t; a0++)
        {
            string s = Console.ReadLine();

            if (IsBalanced(s))
                Console.WriteLine("YES");
            else
                Console.WriteLine("NO");
        }
    }

    static bool IsBalanced(string s)
    {
        var openingBrackes = new List<string>() { "(", "{", "[" };
        var closingBrackes = new List<string>() { ")", "}", "]" };

        var openingStack = new Stack<string>();

        var curSymbol = string.Empty;
        var openingIndex = 0;
        var closingIndex = 0;

        for (int i = 0; i < s.Length; i++)
        {
            curSymbol = s[i].ToString();

            if (openingBrackes.Contains(curSymbol))
                openingStack.Push(curSymbol);

            if (closingBrackes.Contains(curSymbol))
            {
                if (openingStack.Count == 0)
                    return false;

                openingIndex = openingBrackes.IndexOf(openingStack.Pop());
                closingIndex = closingBrackes.IndexOf(curSymbol);

                if (openingIndex != closingIndex)
                    return false;
            }

        }

        if (openingStack.Count > 0)
            return false;

        return true;
    }
}
