using System;
using System.IO.Enumeration;
using Lab7.BinarySearchTree;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new();
            tree.Add(15);
            tree.Add(41);
            tree.Add(3);
            Console.WriteLine(tree.Add(22));
            Console.WriteLine(tree.Add(22));
            tree.Add(8);
            tree.Add(16);
        }
    }
}
