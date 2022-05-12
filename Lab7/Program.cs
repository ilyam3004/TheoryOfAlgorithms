using System;
using Lab7.BinarySearchTree;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new();
            tree.Add(10);
            tree.Add(8);
            tree.Add(6);
            tree.Add(2);
            tree.Add(7);
            tree.Add(15);
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Root: {tree.root.data}");
            Console.WriteLine("Signal path: " + tree.Find(7));
            Console.WriteLine("-------------------------");
            BalancedBinaryTree balancedTree = new();
            balancedTree.Add(10);
            balancedTree.Add(8);
            balancedTree.Add(6);
            balancedTree.Add(2);
            balancedTree.Add(7);
            balancedTree.Add(15);
            Console.WriteLine($"Root: {balancedTree.root.data}");
            Console.WriteLine("Signal path: " + balancedTree.Find(7));
            Console.WriteLine("-------------------------");
        }
    }
}
