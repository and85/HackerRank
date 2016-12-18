using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// https://www.hackerrank.com/challenges/delete-duplicate-value-nodes-from-a-sorted-linked-list
namespace DeleteDuplicateVlue
{
    class Program
    {
        static void Main(string[] args)
        {
            var n1 = new Node();
            var n2 = new Node();
            var n3 = new Node();
            var n4 = new Node();
            var n5 = new Node();
            var n6 = new Node();
            var n7 = new Node();
            n1.next = n2;
            n2.next = n3;
            n3.next = n4;
            n4.next = n5;
            n5.next = n6;
            n6.next = n7;
            n1.data = 1;
            n2.data = 1;
            n3.data = 1;
            n4.data = 1;
            n5.data = 1;
            n6.data = 1;
            n7.data = 1;

            RemoveDuplicates(n1);
        }

        public static Node RemoveDuplicates(Node head)
        {
            Node current = head;

            Node next_next;

            if (head == null)
                return head;

            while (current.next != null)
            {

                if (current.data == current.next.data)
                {
                    next_next = current.next.next;
                    current.next = null;
                    current.next = next_next;
                }
                else
                    current = current.next;
            }

            return head;
        }

        public class Node
        {
            public int data;
            public Node next;
        }
    }
}
