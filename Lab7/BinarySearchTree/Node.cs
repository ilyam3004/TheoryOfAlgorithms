namespace Lab7.BinarySearchTree
{
    public class Node
    {
        public Node right;
        public Node left;
        public Node parent { get; set; }
        public int data;
        public Node(int data)
        {
            this.data = data;
        }
    }
}