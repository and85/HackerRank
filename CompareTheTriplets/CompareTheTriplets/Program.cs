using System;
class Solution
{
    static void GetScores(int[] AliceScores, int[] BobScores, out int AliceResult, out int BobResult)
    {
        AliceResult = 0;
        BobResult = 0;

        for (int i = 0; i < AliceScores.Length; i++)
        {
            if (AliceScores[i] > BobScores[i])
                AliceResult++;

            if (AliceScores[i] < BobScores[i])
                BobResult++;
        }
    }

    //https://www.hackerrank.com/challenges/compare-the-triplets
    static void Main(String[] args)
    {
        string[] tokens_a0 = Console.ReadLine().Split(' ');
        int a0 = Convert.ToInt32(tokens_a0[0]);
        int a1 = Convert.ToInt32(tokens_a0[1]);
        int a2 = Convert.ToInt32(tokens_a0[2]);
        string[] tokens_b0 = Console.ReadLine().Split(' ');
        int b0 = Convert.ToInt32(tokens_b0[0]);
        int b1 = Convert.ToInt32(tokens_b0[1]);
        int b2 = Convert.ToInt32(tokens_b0[2]);

        var AliceScores = new int[] { a0, a1, a2 };
        var BobScores = new int[] { b0, b1, b2 };
        int AliceResult;
        int BobResult;

        GetScores(AliceScores, BobScores, out AliceResult, out BobResult);
        Console.WriteLine(@"{0} {1}", AliceResult, BobResult);
    }
}
