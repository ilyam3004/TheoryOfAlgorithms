using System;
using Lab7.BinarySearchTree;

namespace Lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            BalancedBinaryTree balancedTree = new();
            balancedTree.Add(10);
            balancedTree.Add(8);
            balancedTree.Add(6);
            balancedTree.Add(4);
            balancedTree.Add(14);
            Console.WriteLine("Signal path: " + balancedTree.Find(4));
        }
    }
}
