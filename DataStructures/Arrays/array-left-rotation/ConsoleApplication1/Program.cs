using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    // https://www.hackerrank.com/challenges/array-left-rotation
    static void Main(String[] args)
    {
        string[] firstLine = Console.ReadLine()
            .Split(' ');
        int n = int.Parse(firstLine[0]);
        int d = int.Parse(firstLine[1]);

        int[] arr = new int[n];
        arr = Console.ReadLine()
            .Split(' ')
            .Select(x => int.Parse(x))
            .ToArray();

        Rotate(n, d, arr);

        string result = string.Join(" ", arr);
        Console.WriteLine(result);
    }

    static void Rotate(int n, int d, int[] arr)
    {
        Array.Reverse(arr, 0, d);
        Array.Reverse(arr, d, n - d);
        Array.Reverse(arr, 0, n);
    }
}