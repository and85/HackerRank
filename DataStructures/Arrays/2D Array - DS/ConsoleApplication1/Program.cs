using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    // https://www.hackerrank.com/challenges/2d-array
    static void Main(String[] args)
    {
        int[][] arr = new int[6][];
        for (int arr_i = 0; arr_i < 6; arr_i++)
        {
            string[] arr_temp = Console.ReadLine().Split(' ');
            arr[arr_i] = Array.ConvertAll(arr_temp, Int32.Parse);
        }

        int sum = FindMaxSum(arr);
        Console.WriteLine(sum);
    }

    static int FindMaxSum(int[][] arr)
    {
        int maxSum = int.MinValue;
        int n = 6;

        int sum = maxSum;
        for (int i = 1; i < n - 1; i++)
        for (int j = 1; j < n - 1; j++)
        {
                sum = arr[i - 1][j - 1] + arr[i - 1][j] + arr[i - 1][j + 1]
                    + arr[i][j] 
                    + arr[i + 1][j - 1] + arr[i + 1][j] + arr[i + 1][j + 1];

                if (sum > maxSum)
                    maxSum = sum;
        }

        return maxSum;
    }
}
