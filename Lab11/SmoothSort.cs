using System;
using System.Collections.Generic;

namespace Lab11
{
    public class SmoothSort
    {
        List<Node> roots = new();
    
        public void sort(int[] arr)
        {
            Console.WriteLine("Creating trees");
            for (int i = 0; i < arr.Length; i++)
            {
                AddRoot(arr[i]);
            }
            
            Console.WriteLine("\nDeleting trees\n");
            for (int i = arr.Length-1; i >= 0; i--)
                arr[i] = RemoveLastRoot();
        }

        private void AddRoot(int data)
        {
            Console.Write("add  "+ data);
            if (AdjacentRangs())
            {
                Node left = roots[^2];
                Node right = roots[^1];
                roots.Remove(roots[^2]);
                roots.Remove(roots[^1]);
                int rang = Math.Max(left.rang, right.rang) + 1;
                roots.Add(new Node(data, rang, left, right));
                Console.WriteLine("("+rang+")\t|" +RootsToString());
                if(!RootsAreOrdered())
                    SortRootsData();
                Console.WriteLine("sorted after adding  "+ data +"("+rang+")  |  " + RootsToString());
                
                return;
            }

            if (roots.Count == 0 || roots[^1].rang != 1)
            {
                roots.Add(new Node(data, 1));
                Console.WriteLine("("+1+")\t|" +RootsToString());
                if(!RootsAreOrdered())
                    SortRootsData();
                Console.WriteLine("sorted after adding  "+ data +"("+1+")  |  " + RootsToString());
                return;
            }

            roots.Add(new Node(data, 0));
            Console.WriteLine("("+0+")  |  " +RootsToString());
            if(!RootsAreOrdered())
                SortRootsData();
            Console.WriteLine("sorted after adding  "+ data  +"("+0+")\t|" + RootsToString());

        }

        private bool AdjacentRangs()
        {
            if (roots.Count <= 1)
                return false;
            return Math.Abs(roots[^1].rang - roots[^2].rang) == 1;
        }

        private bool RootsAreOrdered()
        {
            if (roots.Count <= 1)
                return true;
            for (int i = roots.Count - 1; i > 0; i--){
                if (roots[i - 1].data > roots[i].data)
                    return false;
            }
            return true;
        }

        private string RootsToString()
        {
            string res = "";
            foreach (Node item in roots)
            {
                res += item.data+ " ("+item.rang+")\t";
            }

            return res;
        }

        private int RemoveLastRoot()
        {
            Node removing = roots[^1];

            roots.Remove(removing);
            if(removing.left != null)
                roots.Add(removing.left);
            if(removing.right != null)
                roots.Add(removing.right);
            if(!RootsAreOrdered())
                SortRootsData();
            
            return removing.data;
        }

        private void SortRootsData()
        {
            if (roots.Count <= 1)
                return;
            for (int i = IndexOfNotOrdered(); !RootsAreOrdered(); i = IndexOfNotOrdered())
            {
                for (int j = i; roots[j].data < roots[i - 1].data; j--)
                {
                    roots[j].SwapData(roots[j - 1]);
                }
                    
            }

        }

        private int IndexOfNotOrdered()
        {
            for (int i = roots.Count-1; i > 0; i--)
            {
                if (roots[i].data < roots[i - 1].data)
                    return i;
            }

            return -1;
        }

        public class Node
        {
            private int _data;

            public int data
            {
                get => _data;
                set
                {
                    _data = value;
                    if (!HasTopValue())
                        SwapData(GetBiggerChild());
                }
            }

            public int rang { get; set; }
            public Node left { get; set; }
            public Node right { get; set; }

            public Node(int data, int rang)
            {
                this.data = data;
                this.rang = rang;
            }

            public Node(int data, int rang, Node left, Node right)
            {
                
                this.left = left;
                this.right = right;
                this.data = data;
                this.rang = rang;
            }

            private bool HasTopValue()
            {
                return HasChild() ? GetBiggerChild().data < data : true;
            }

            public bool HasChild()
            {
                return left != null || right != null;
            }

            private  Node? GetBiggerChild()
            {
                if (left != null && right != null)
                    return left.data > right.data ? left : right;
                if (left != null)
                    return  left;
                if (right != null)
                    return right;
                return null;

            }

            public void SwapData(Node node)
            {
                if (node == null)
                    throw new ArgumentNullException(null, "Passing null Node into Node.SwapData method");
                /*int temp = node.data;
                node.data = _data;
                _data = temp;*/
                (node.data, _data) = (_data, node.data);
            }
            
        }
    }
}