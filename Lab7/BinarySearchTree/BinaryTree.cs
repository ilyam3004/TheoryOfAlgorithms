using System;

namespace Lab7.BinarySearchTree
{
    public class BinaryTree
    {
        public Node root;
        public string path;
        public virtual void Add(int data)
        {
            Node newItem = new Node(data);
            if (root == null)
                root = newItem;
            else
                root = RecursiveInsert(root, newItem);
        }
        public virtual Node RecursiveInsert(Node current, Node n)
        {
            if (current == null)
            {
                current = n;
                return current;
            }
            else if (n.data < current.data)
                current.left = RecursiveInsert(current.left, n);
            else if (n.data > current.data)
                current.right = RecursiveInsert(current.right, n);
            return current;
        }
        public string Find(int key) => FindPath(key, root) + key;
        private string FindPath(int target, Node current)
        {
            if (target < current.data)
            {
                if (target == current.data)
                    return path + current.data;
                else
                {
                    path += $"{current.data} -> ";
                    FindPath(target, current.left);
                }
            }
            else
            {
                if (target == current.data)
                    return path + " -> " + current.data;
                else
                {
                    path += $"{current.data} -> ";
                    FindPath(target, current.right);
                }
            } 
            return path;
        }
    }
}