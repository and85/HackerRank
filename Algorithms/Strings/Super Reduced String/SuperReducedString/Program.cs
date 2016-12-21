using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperReducedString
{
    // https://www.hackerrank.com/challenges/reduced-string
    class Program
    {
        static void Main(string[] args)
        {
            string s = Console.ReadLine();
            string r = ReducedString(s);
            Console.WriteLine(r);
#if DEBUG
            Console.WriteLine("END");
            Console.ReadLine();
#endif
        }

        // brute force O(n^2) solution, hackerrank provides O(n) solution based on stack
        public static string ReducedString(string s)
        {
            string r = s;

            if (HasDuplicates(s))
            {
                
                for (int i = 1; i < s.Length; i++)
                {
                    if (s[i] == s[i - 1])
                    {
                        r = RemoveChars(s, i - 1, i);
                        break;
                    }
                }

                r = ReducedString(r);
            }

            return r.Length > 0 ? r : "Empty String";
        }

        public static bool HasDuplicates(string s)
        {
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] == s[i - 1])
                    return true;
            }

            return false;
        }

        public static string RemoveChars(string input, params int[] indexes)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (!indexes.Contains(i))
                    sb.Append(input[i]);
            }
            return sb.ToString();
        }
    }
}
