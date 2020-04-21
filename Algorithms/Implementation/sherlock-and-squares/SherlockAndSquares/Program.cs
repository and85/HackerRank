using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SherlockAndSquares
{
    // https://www.hackerrank.com/challenges/sherlock-and-squares
    class Program
    {
        static void Main(string[] args)
        {
            //int t = int.Parse(Console.ReadLine());

            int t = 100;

            var perfectSquares = new HashSet<int>();

            string[] lines = File.ReadAllLines(@"D:\Projects\!GIT\HackerRank\Algorithms\Implementation\sherlock-and-squares\SherlockAndSquares\TestCases\input2.txt");
            

            for (int i = 0; i < t; i++)
            {
                int counter = 0;
                //string s = Console.ReadLine();
                string s = lines[i];

                int[] ab = s.Split(' ').Select(int.Parse).ToArray();
                int a = ab[0];
                int b = ab[1];

                for (int j = a; j <= b; j++)
                {
                    if (perfectSquares.Contains(j))
                    {
                        counter++;
                    }
                    else if (IsPerfectSquare(j))
                    {
                        perfectSquares.Add(j);
                        counter++;
                    }
                }
                Console.WriteLine(counter);
            }
                
#if DEBUG
            Console.WriteLine("END");
            Console.ReadLine();
#endif
        }

        private static bool IsPerfectSquare(double input)
        {
            var sqrt = Math.Sqrt(input);
            return Math.Abs(Math.Ceiling(sqrt) - Math.Floor(sqrt)) < Double.Epsilon;
        }
    }
}
