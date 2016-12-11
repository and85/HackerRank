using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Solution
{
    // https://www.hackerrank.com/challenges/gridland-metro
    static void Main(String[] args)
    {
        string firstLine = Console.ReadLine();
        int n = int.Parse(firstLine.Split(' ')[0]);
        int m = int.Parse(firstLine.Split(' ')[1]);
        int k = int.Parse(firstLine.Split(' ')[2]);

        var rows = new Dictionary<int, Row>();
        for (int i = 0; i < k; i++)
        {
            string trackLine = Console.ReadLine();
            int r = int.Parse(trackLine.Split(' ')[0]);
            int c1 = int.Parse(trackLine.Split(' ')[1]);
            int c2 = int.Parse(trackLine.Split(' ')[2]);

            if (!rows.ContainsKey(r))
            {
                rows.Add(r, new Row(c1, c2));
            }
            else
            {
                rows[r].AddTrack(c1, c2);
            }
        }

        long trackLenght = 0;
        foreach(var row in rows)
        {
            
            var stack = MergeTracks(row.Value.Tracks);
            while (stack.Count != 0)
            {
                Track track = stack.Pop();
                trackLenght += (track.End - track.Start + 1);
            }
        }

        long numberOfLampposts = (long)m * n - trackLenght;
        Console.WriteLine(numberOfLampposts);

#if DEBUG
        Console.WriteLine("END");
        Console.ReadLine();
#endif
    }

    public static Stack<Track> MergeTracks(List<Track> tracks)
    {
        var stack = new Stack<Track>();
        foreach (var track in tracks.OrderBy(x => x.Start))
        {
            if (stack.Count == 0)
            {
                stack.Push(track);
                // first entrance, nothing to compare with
                continue;
            }

            Track top = stack.Peek();

            // this is a completely new track
            if (top.End < track.Start)
            {
                stack.Push(track);
            }
            // expand a current track if needed
            else if (top.End < track.End)
            {
                top.End = track.End;
                stack.Pop();
                stack.Push(top);
            }
        }

        return stack;
    }

    public class Row
    {
        public Row()
        {
            Tracks = new List<Track>();
        }

        public List<Track> Tracks { get; set; }

        public Row(int start, int end): this()
        {
            AddTrack(start, end);
        }

        public void AddTrack(int start, int end)
        {
            Tracks.Add(new Track(start, end));
        }
    }

    public class Track
    {
        public Track(int start, int end)
        {
            Start = start;
            End = end;
        }

        public int Start { get; set; }
        public int End { get; set; }
    }
}