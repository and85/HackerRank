using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
class Solution
{
    static void Main(String[] args)
    {
        string[] tokens_n = Console.ReadLine().Split(' ');
        int n = Convert.ToInt32(tokens_n[0]);
        int m = Convert.ToInt32(tokens_n[1]);
        string[] c_temp = Console.ReadLine().Split(' ');
        int[] c = Array.ConvertAll(c_temp, Int32.Parse);

        int distance = MaxDistance(n, m, c);
        Console.WriteLine(distance);
    }

    static int MaxDistance(int n, int m, int[] stations)
    {
        Array.Sort(stations);
        var stationsHashSet = new HashSet<int>();
        foreach (var station in stations)
        {
            stationsHashSet.Add(station);
        }

        int minStation = stations.Min();
        int maxStation = stations.Max();
        int leftCityDistance = minStation;
        int rightCityDistance = n - 1 - maxStation;

        int maxDistance = Math.Max(leftCityDistance, rightCityDistance);

        int prevStation = 0;
        int nextStation = 0;
        for (int city = minStation; city < maxStation; city++)
        {
            if (stationsHashSet.Contains(city))
            {
                prevStation = city;
                nextStation = stations.Where(s => s > city).Min();
                continue;
            }

            int left = city - prevStation;
            int right = nextStation - city;

            int closestStation = Math.Min(left, right);
            if (closestStation > maxDistance)
                maxDistance = closestStation;
        }

        return maxDistance;
    }
}
