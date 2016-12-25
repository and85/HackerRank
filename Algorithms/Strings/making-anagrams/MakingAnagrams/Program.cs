using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakingAnagrams
{
    // https://www.hackerrank.com/challenges/making-anagrams
    class Program
    {
        static void Main(string[] args)
        {
            string a = Console.ReadLine();
            string b = Console.ReadLine();

            int number = GetNumberOfDeletion(a, b);
            Console.WriteLine(number);
#if DEBUG
            Console.WriteLine("END");
            Console.ReadLine();
#endif
        }

        private static int GetNumberOfDeletion(string a, string b)
        {
            int resultNumber = 0;
            const int AlphabetNumber = 26;

            var aOccur = new int[AlphabetNumber];
            var bOccur = new int[AlphabetNumber];

            GetOccurence(a, aOccur);
            GetOccurence(b, bOccur);

            for (int i = 0; i < AlphabetNumber; i++)
            {
                resultNumber += Math.Abs(aOccur[i] - bOccur[i]);
            }

            return resultNumber;
        }

        private static void GetOccurence(string s, int[] occur)
        {
            const int FirstAscii = 97;
            for (int i = 0; i < s.Length; i++)
            {
                int index = s[i] - FirstAscii;
                occur[index]++;
            }
        }
    }
}
