using System;
using System.Data;
using System.Transactions;

namespace Lab7.BinarySearchTree
{
    public class BinaryTree
    {
        private Node root;
        public string path { get; set; }

        public string Add(int data)
        {
            path = "";
            return AddNode(ref root, new Node(data), null);;
        }
        private string AddNode(ref Node currentNode, Node node, Node parent)
        {
            if (currentNode == null)
            {
                currentNode = node;
                currentNode.parent = parent;
                return path;
            }
            if(currentNode.data != node.data)
                path += $" {currentNode.data} ->";
            if(currentNode.data == node.data)
                return path;
            if (currentNode.data > node.data) 
                AddNode(ref currentNode.left, node, currentNode);
            if (currentNode.data < node.data)
                AddNode(ref currentNode.right, node, currentNode);
            return path + " " + node.data;
        }
        public bool Find(int data)
        {
            if (FindNode(root, data) == null)
                return false;
            return true;
        }
        private Node FindNode(Node currentNode, int data)
        {
            if (currentNode != null)
            {
                if (data == currentNode.data)
                {
                    return currentNode;
                }

                if (data < currentNode.data)
                {
                    return FindNode(currentNode.left, data);
                }
                else
                {
                    return FindNode(currentNode.right, data);
                }
            }
            return null;
        }
        public void ShowAll() => Showtree(root);
        public void Showtree(Node node)
        {
            if(node.left != null)
                Showtree(node.left);
            Console.WriteLine(node.data);
            if (node.right != null)
                Showtree(node.right);
        }
    }
}