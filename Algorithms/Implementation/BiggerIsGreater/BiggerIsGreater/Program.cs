using System;
using System.Text;

class Solution
{
    static string SortTail(char[] tail)
    {
        Array.Sort(tail);
        return new string(tail);
    }

    static string Rearrange(string inputString)
    {
        char[] input = inputString.ToCharArray();

        int pivotIndex = FindPivotIndex(input);
        int rightMostSuccessorIndex = FindRightMostSuccessorIndex(input, pivotIndex);

        if (pivotIndex == rightMostSuccessorIndex)
            return "no answer";

        char temp = input[pivotIndex];
        input[pivotIndex] = input[rightMostSuccessorIndex];
        input[rightMostSuccessorIndex] = temp;

        int firstPartLength = pivotIndex + 1;
        char[] firstPart = new char[firstPartLength];
        Array.Copy(input, firstPart, firstPartLength);

        int secondPartLength = input.Length - pivotIndex - 1;
        char[] secondPart = new char[secondPartLength];
        Array.Copy(input, pivotIndex + 1, secondPart, 0, secondPartLength);

        Array.Reverse(secondPart);

        return new string(firstPart) + new string(secondPart);
    }

    // O(n)
    static int FindPivotIndex(char[] input)
    {
        for (int i = input.Length - 2; i > 0; i-- )
        {
            if (input[i + 1] > input[i])
                return i;
        }

        return 0;
    }

    // O(n)
    static int FindRightMostSuccessorIndex(char[] input, int pivot)
    {
        int min = int.MaxValue;
        int minIndex = pivot;

        for (int i = pivot + 1; i < input.Length; i++)
        {
            if (input[i] > input[pivot])
            {
                if (input[i] <= min)
                {
                    min = input[i];
                    minIndex = i;
                }
            }
        }

        return minIndex;
    }

    // https://www.hackerrank.com/challenges/bigger-is-greater
    static void Main(String[] args)
    {

        int t = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < t; i++)
        {
            string line = Console.ReadLine();
            Console.WriteLine(Rearrange(line));
        }
        /*
        return;
        
        string[] lines = 
            System.IO.File.ReadAllLines(@"D:\Projects\!GIT\HackerRank\BiggerIsGreater\BiggerIsGreater\testcase1\input.txt");

        using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"D:\Projects\!GIT\HackerRank\BiggerIsGreater\BiggerIsGreater\testcase1\actual.txt"))
        {
            foreach (string line in lines)
            {
                file.WriteLine(Rearrange(line));

            }
        }
        */
    }
}
