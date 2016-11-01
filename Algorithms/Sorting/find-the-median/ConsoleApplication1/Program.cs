using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    // https://www.hackerrank.com/challenges/find-the-median
    // no need to change it to selection sort because selection sort gives us O(n2) anyway
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] arr = new int[n];
        String elements = Console.ReadLine();
        String[] split_elements = elements.Split(' ');
        for (int i = 0; i < n; i++)
        {
            arr[i] = Convert.ToInt32(split_elements[i]);
        }

        int median = FindMedian(arr, n);
        Console.WriteLine(median);
    }

    static int FindMedian(int[] arr, int n)
    {
        Array.Sort(arr);
        int medianIndex;
        int median;

        // since n is odd we will never need to find an average between two elements
        medianIndex = n / 2;
        median = arr[medianIndex];
        

        return median;
    }
}