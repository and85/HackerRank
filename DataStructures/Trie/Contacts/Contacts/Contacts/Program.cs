using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

class Solution
{
    // https://www.hackerrank.com/challenges/contacts
    static void Main(String[] args)
    {
        int n = int.Parse(Console.ReadLine());

        var trie = new Trie();
        for (int i = 0; i < n; i++)
        {
            string line = Console.ReadLine();
            string command = line.Split(' ')[0];
            string argument = line.Split(' ')[1];

            switch (command)
            { 
                case "add":
                    trie.Insert(argument);
                break;
                case "find":
                    int nodesCount = trie.FindNumberOfNodes(argument, trie);
                    Console.WriteLine(nodesCount);
                break;
            }
        }
    }

    #region Trie implementation
    // taken from https://visualstudiomagazine.com/articles/2015/10/20/text-pattern-search-trie-class-net.aspx
    public class Node
    {
        public char Value { get; set; }
        public List<Node> Children { get; set; }
        public Node Parent { get; set; }
        public int Depth { get; set; }

        public Node(char value, int depth, Node parent)
        {
            Value = value;
            Children = new List<Node>();
            Depth = depth;
            Parent = parent;
        }

        public bool IsLeaf()
        {
            return Children.Count == 0;
        }

        public Node FindChildNode(char c)
        {
            foreach (var child in Children)
                if (child.Value == c)
                    return child;

            return null;
        }

        public void DeleteChildNode(char c)
        {
            for (var i = 0; i < Children.Count; i++)
                if (Children[i].Value == c)
                    Children.RemoveAt(i);
        }
    }
      

    public class Trie
    {
        private readonly Node _root;

        public Trie()
        {
            _root = new Node('^', 0, null);
        }

        public Node Prefix(string s)
        {
            var currentNode = _root;
            var result = currentNode;

            foreach (var c in s)
            {
                currentNode = currentNode.FindChildNode(c);
                if (currentNode == null)
                    break;
                result = currentNode;
            }

            return result;
        }

        public int FindNumberOfNodes(string s, Trie trie)
        {
            foreach (int item in Search(s, trie._root))
            {
                Console.WriteLine(item);
            }

            return 0;
        }

        private List<int> _indexes = new List<int>();

        // http://www.geeksforgeeks.org/pattern-searching-using-trie-suffixes/
        private List<int> Search(string s, Node root)
        {
            return new List<int>();
        }

        //public void InsertRange(List<string> items)
        //{
        //    for (int i = 0; i < items.Count; i++)
        //        Insert(items[i]);
        //}

        public void Insert(string s)
        {
            var commonPrefix = Prefix(s);
            var current = commonPrefix;

            for (var i = current.Depth; i < s.Length; i++)
            {
                var newNode = new Node(s[i], current.Depth + 1, current);
                current.Children.Add(newNode);
                current = newNode;
            }

            current.Children.Add(new Node('$', current.Depth + 1, current));
        }

        //public void Delete(string s)
        //{
        //    if (Search(s))
        //    {
        //        var node = Prefix(s).FindChildNode('$');

        //        while (node.IsLeaf())
        //        {
        //            var parent = node.Parent;
        //            parent.DeleteChildNode(node.Value);
        //            node = parent;
        //        }
        //    }
        //}

    }
    #endregion
}