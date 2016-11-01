using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    // https://www.hackerrank.com/challenges/cut-the-sticks
    static void Main(String[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string arrayString = Console.ReadLine();
        string[] arr_temp = arrayString.Split(' ');
        int[] arr = Array.ConvertAll(arr_temp, Int32.Parse);

        Array.Sort(arr);
        int counter = 0;
        for (int i = 0; i < arr.Length;)
        {
            int uniqueCount = arr.Count(x => arr[i] == x);
            Console.WriteLine(arr.Length - counter);

            i += uniqueCount;
            counter += uniqueCount;
        }
    }
}
