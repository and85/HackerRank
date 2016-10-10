using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static int GetNumberOfAlteredLetters(string input)
    {
        int result = 0;
        
        for (int i = 0; i < input.Length; i = i + 3)
        {
            if (input[i] != 'S')
                result++;
            if (input[i + 1] != 'O')
                result++;
            if (input[i + 2] != 'S')
                result++;
        }

        return result;
    }

    //https://www.hackerrank.com/challenges/mars-exploration?h_r=next-challenge&h_v=zen
    static void Main(String[] args)
    {
        string S = Console.ReadLine();
        Console.WriteLine(GetNumberOfAlteredLetters(S));
    }
}
