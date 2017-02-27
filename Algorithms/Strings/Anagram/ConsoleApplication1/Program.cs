using System;

// https://www.hackerrank.com/challenges/anagram
namespace ConsoleApplication1
{
    class Program
    {
        private const int asciiSize = 255;

        static void Main(string[] args)
        {
            int t = int.Parse(Console.ReadLine());
            for (int i = 0; i < t; i++)
            {
                var input = Console.ReadLine();
                int result = GetNumberOfChanges(input);
                Console.WriteLine(result);
            }
        }

        static int GetNumberOfChanges(string input)
        {
            int mid1 = (int)Math.Ceiling(input.Length / 2.0);
            int mid2 = (int)Math.Floor(input.Length / 2.0);

            // It is not possible for two strings of unequal length to be anagram for each other
            if (mid1 != mid2)
                return -1;

            var s1 = new char[mid1];
            var s2 = new char[mid2];

            input.CopyTo(0, s1, 0, mid1);
            input.CopyTo(mid1, s2, 0, mid2);

            var ba1 = GetOccurrence(s1);
            var ba2 = GetOccurrence(s2);

            int result = 0;
            for (int i = 0; i < asciiSize; i++)
                result += Math.Abs(ba1[i] - ba2[i]);

            result /= 2;

            return result;
        }

        private static int[] GetOccurrence(char[] s)
        {
            var ba = new int[asciiSize];
            foreach (char c in s)
            {
                ba[c]++;
            }

            return ba;
        }
    }
}
