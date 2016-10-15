using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    // https://www.hackerrank.com/challenges/tutorial-intro
    static void Main(String[] args)
    {
        int v = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int[] inputArray = Console.ReadLine()
            .Split(' ')
            .Select(h => int.Parse(h))
            .ToArray();

        //int index = Array.BinarySearch(inputArray, v);
        int index = MyBinarySearch(inputArray, n, v);
        Console.WriteLine(index);
    }

    static int MyBinarySearch(int[] array, int n, int key)
    {
        int min = 0;
        int max = n - 1;

        while (min <= max)
        {
            int mid = (min + max) / 2;
            if (key == array[mid])
            {
                return mid;
            }
            else if (key < array[mid])
            {
                max = mid - 1;
            }
            else
            {
                min = mid + 1;
            }
        }

        return -1;
    }
}