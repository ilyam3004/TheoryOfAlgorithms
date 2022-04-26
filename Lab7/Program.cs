using System;
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
            tree.Add(8);
            tree.Add(16);
            tree.Add(48);
            tree.Add(2);
            tree.Add(4);
            tree.Add(10);
            while(true)
            {
                Console.WriteLine("------------------------");
                Console.WriteLine("Enter count of pirates:");
                int pirates = int.Parse(Console.ReadLine());
                Console.WriteLine(tree.Add(pirates));
                Console.WriteLine("Pirates ship was destroyed!");
            }
        }
    }
}
