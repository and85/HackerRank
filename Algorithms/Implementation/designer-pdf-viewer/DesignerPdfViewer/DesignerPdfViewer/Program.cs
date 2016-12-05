using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    // https://www.hackerrank.com/challenges/designer-pdf-viewer
    static void Main(String[] args)
    {
        string[] h_temp = Console.ReadLine().Split(' ');
        int[] h = Array.ConvertAll(h_temp, Int32.Parse);
        string word = Console.ReadLine();

        int result = GetRectangle(h, word);
        Console.WriteLine(result);
    }

    private static int GetRectangle(int[] h, string word)
    {
        int maxHeight = int.MinValue;
        foreach (char symbol in word)
        {
            int position = symbol - 'a';
            if (h[position] > maxHeight)
                maxHeight = h[position];
        }

        return maxHeight * word.Length;
    }
}
