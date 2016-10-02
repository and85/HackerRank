//Given an array of  integers, can you find the sum of its elements?

//Input Format

//The first line contains an integer, , denoting the size of the array.
//The second line contains space-separated integers representing the array's elements.

//Output Format

//Print the sum of the array's elements as a single integer.
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{

    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);

        int sum = 0;
        for (int i = 0; i < n; i++)
            sum += arr[i];

        Console.WriteLine(sum);
    }
}