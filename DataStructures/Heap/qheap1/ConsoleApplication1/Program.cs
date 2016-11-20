using System;
using System.Collections.Generic;
using System.IO;
class Solution
{
    // https://www.hackerrank.com/challenges/qheap1
    static void Main(String[] args)
    {
        int q = int.Parse(Console.ReadLine());
        var heap = new MinHeap<int>();

        for (int i = 0; i < q; i++)
        {
            string[] input = Console.ReadLine().Split();
            switch (input[0])
            {
                case "1":
                    heap.Add(int.Parse(input[1]));
                    break;
                case "2":
                    heap.Remove(int.Parse(input[1]));
                    break;
                case "3":
                    Console.WriteLine(heap.GetMin());
                    break;
            }


        }
    }

    class MinHeap<T> where T : IComparable
    {
        private List<T> data = new List<T>();

        public void Add(T o)
        {
            data.Add(o);

            int i = data.Count - 1;
            while (i > 0)
            {
                // find parent
                int j = (i + 1) / 2 - 1;

                // do we need to swap?
                T v = data[j];
                if (v.CompareTo(data[i]) < 0 || v.CompareTo(data[i]) == 0)
                {
                    break;
                }

                // Swap the elements  
                T tmp = data[i];
                data[i] = data[j];
                data[j] = tmp;

                i = j;
            }
        }

        public void Remove(T o)
        {
            if (data.Count < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            int index = 0;
            for (int i = 0; i < data.Count; i++)
            {
                if (data[i].CompareTo(o) == 0)
                {
                    index = i;
                    break;
                }
            }

            data[index] = data[data.Count - 1];
            data.RemoveAt(data.Count - 1);

            this.MinHeapify(index);
        }

        public T GetMin()
        {
            return data[0];
        }

        private void MinHeapify(int i)
        {
            int smallest;
            int l = 2 * (i + 1) - 1;
            int r = 2 * (i + 1) - 1 + 1;

            if (l < data.Count && (data[l].CompareTo(data[i]) < 0))
            {
                smallest = l;
            }
            else
            {
                smallest = i;
            }

            if (r < data.Count && (data[r].CompareTo(data[smallest]) < 0))
            {
                smallest = r;
            }

            if (smallest != i)
            {
                // Swap
                T tmp = data[i];
                data[i] = data[smallest];
                data[smallest] = tmp;

                MinHeapify(smallest);
            }
        }
    }
}