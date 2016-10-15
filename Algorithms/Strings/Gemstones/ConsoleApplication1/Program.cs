using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    //https://www.hackerrank.com/challenges/gem-stones
    static void Main(String[] args)
    {
        int n = int.Parse(Console.ReadLine());
        var input = new string[n];

        for (int i = 0; i < n; i++)
        {
            input[i] = Console.ReadLine();
        }

        Console.WriteLine(GetNumberOfUniqueGems(input));
    }

    static int GetNumberOfUniqueGems(string[] input)
    {
        char[] uniqueCharacters = input[0].Distinct().ToArray();

        for (int i = 1; i < input.Length; i++)
        {
            uniqueCharacters = uniqueCharacters.Intersect(input[i]).ToArray();
        }

        return uniqueCharacters.Length;
    }
}