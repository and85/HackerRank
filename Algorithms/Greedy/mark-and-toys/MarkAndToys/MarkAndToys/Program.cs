using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkAndToys
{
    // https://www.hackerrank.com/challenges/mark-and-toys
    class Program
    {
        static void Main(string[] args)
        {
            string firstLine = Console.ReadLine();
            string secondLine = Console.ReadLine();

            var numbers = firstLine.Split(' ');
            int n = int.Parse(numbers[0]);
            int k = int.Parse(numbers[1]);

            int[] prices = secondLine.Split(' ').Select(x => int.Parse(x)).ToArray();
            Array.Sort(prices);

            int moneySpent = 0;
            int toysNumber = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                moneySpent += prices[i];

                if (moneySpent > k)
                    break;

                toysNumber++;
            }

            Console.WriteLine(toysNumber);
        }
    }
}
