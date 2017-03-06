using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PalindromeIndex
{
    // https://www.hackerrank.com/challenges/palindrome-index
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                int result = GetUndex(input);
                Console.WriteLine(result);
            }
#if DEBUG
            Console.WriteLine();
            Console.ReadLine();
#endif
        }

        private static int GetUndex(string input)
        {
            if (IsPalindrom(input))
                return -1;

            for (int i = 0; i < input.Length / 2; i++)
            {
                int j = input.Length - i - 1;
                if (input[i] != input[j])
                {
                    string candidateOne = RemoveAt(input, i);

                    if (IsPalindrom(candidateOne))
                        return i;

                    string candidateTwo = RemoveAt(input, j);

                    if (IsPalindrom(candidateTwo))
                        return j;
                }
            }

            return -1;
        }

        private static bool IsPalindrom(string input)
        {
            for (int i = 0; i < input.Length / 2; i++)
            {
                if (input[i] != input[input.Length - i - 1])
                {
                    return false;
                }
            }

            return true;
        }

        private static string RemoveAt(string s, int index)
        {
            string p1 = s.Substring(0, index);
            string p2 = s.Substring(index + 1, s.Length - index - 1);
            string result = p1 + p2;

            return result;
        }
    }
}
