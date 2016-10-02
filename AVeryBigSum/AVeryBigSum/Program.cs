using System;
class Solution
{
    static long GetSum(int[] arr, int n)
    {
        long resultSum = 0;

        for (int i = 0; i < n; i++)
            resultSum += arr[i];

        return resultSum;
    }

    // https://www.hackerrank.com/challenges/a-very-big-sum
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] arr_temp = Console.ReadLine().Split(' ');
        int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);

        Console.WriteLine(GetSum(arr, n));
    }
}