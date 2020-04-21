using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Solution
{
    // https://www.hackerrank.com/challenges/build-a-string
    static void Main(String[] args)
    {
        //int t = Convert.ToInt32(Console.ReadLine());
        //int n, a, b;
        //string[] parts;

        //string firstLine;
        //string requiredString;
        //for (int i = 0; i < t; i++)
        //{
        //    firstLine = Console.ReadLine();
        //    parts = firstLine.Split(' ');
        //    n = int.Parse(parts[0]);
        //    a = int.Parse(parts[1]);
        //    b = int.Parse(parts[2]);
        //    requiredString = Console.ReadLine();

        //    int minSum = MinSum(n, a, b, requiredString);
        //    Console.WriteLine(minSum);
        //}

        
            int n = 9;
            int a = 4;
            int b = 5;
            string requiredString = "aabaacaba";

            int minSum = MinSum(n, a, b, requiredString);
            Console.WriteLine(minSum);
    }

    static int MinSum(int n, int a, int b, string requiredString)
    {
        int resultSum = 0;
        var builtString = new StringBuilder();
        var substring = new StringBuilder();

        var presentSymbols = new HashSet<string>();

        for (int i = 0; i < requiredString.Length; i++)
        {
            substring.Clear();
            substring.Append(requiredString[i].ToString());

            if (presentSymbols.Contains(substring.ToString()))
            {
                for (int j = i; j < requiredString.Length; j++)
                {
                    if (!builtString.ToString().Contains(substring.ToString()))
                    {
                        i = i + substring.Length;

                        if (a * substring.Length > b)
                            resultSum += b;
                        else
                            resultSum += a * substring.Length;

                        builtString.Append(substring);
                    }

                    builtString.Append(substring);
                }
            }
            else
            {
                presentSymbols.Add(substring.ToString());
                builtString.Append(substring);
                resultSum += a;
            }

            //builtString.Append();
        }

        return 0;
    }
}