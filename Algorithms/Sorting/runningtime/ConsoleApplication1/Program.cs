using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static void Main(String[] args)
    {
        Console.ReadLine();
        int[] _ar = (from s in Console.ReadLine().Split() select Convert.ToInt32(s)).ToArray();


        int result = insertionSort(_ar);
        Console.WriteLine(result);
    }

    public static int insertionSort(int[] A)
    {
        int result = 0;

        var j = 0;
        for (var i = 1; i < A.Length; i++)
        {
            var value = A[i];
            j = i - 1;
            while (j >= 0 && value < A[j])
            {
                A[j + 1] = A[j];
                j = j - 1;
                result++;

            }
            A[j + 1] = value;

        }

        return result;
    }
}