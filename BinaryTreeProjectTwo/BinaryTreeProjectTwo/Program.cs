using System;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTreeProjectTwo
{
    public class Node
    {
        public Node LChild;
        public Node RChild;
        public int val;

        public Node(int ch)
        {
            LChild = null;
            RChild = null;
            val = ch;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Node node = new Node(-10);
            CreateTree(node);
            var m = MaxPathSumB(node);
            Console.WriteLine();

        }

        private static Node root;

        public static void CreateTree(Node x)
        {
            root = x;
            root.LChild = new Node(9);
            root.RChild = new Node(20);
            root.RChild.LChild = new Node(15);
            root.RChild.RChild = new Node(7);
        }

       // iterative
        public static List<int> DFS(Node root)
        {
            if (root == null) return default;
            var stack = new Stack<Node>();
            var res = new List<int>();
            stack.Push(root);

            while (stack.Count != 0)
            {
                Node p = stack.Pop();
                Console.WriteLine(p.val);
                res.Add(p.val);
                if (p.RChild != null)
                {
                    stack.Push(p.RChild);
                }

                if (p.LChild != null)
                {
                    stack.Push(p.LChild);
                }
            }

            return res;
        }

        //public static List<char> BFS(Node root)
        //{
        //    if (root == null) return default;
        //    var queue = new Queue<Node>();
        //    var list = new List<char>();
        //    queue.Enqueue(root);

        //    while (queue.Count != 0)
        //    {
        //        Node p = queue.Dequeue();
        //        list.Add(p.val);
        //        if (p.LChild != null) queue.Enqueue(p.LChild);
        //        if (p.RChild != null) queue.Enqueue(p.RChild);
        //    }

        //    return list;
        //}

        ////Recursive DFS
        //public static List<char> DFSRecur(Node root)
        //{
        //    var list = new List<char>();
        //    DFSHelper(root, list);
        //    return list;
        //}

        //public static void DFSHelper(Node root, List<char> list)
        //{
        //    if (root == null) return;
        //    list.Add(root.val);
        //    DFSHelper(root.LChild, list);
        //    DFSHelper(root.RChild, list);
        //}

        //public static bool TreeIncludes(Node root, char target)
        //{
        //    if (root == null) return false;
        //    var queue = new Queue<Node>();
        //    queue.Enqueue(root);

        //    while (queue.Count != 0)
        //    {
        //        Node p = queue.Dequeue();
        //        if (p.val == target) return true;
        //        if(p.LChild != null) queue.Enqueue(p.LChild);
        //        if(p.RChild != null) queue.Enqueue(p.RChild);
        //    }

        //    return false;

        //}

        public static int TreeSum(Node root)
        {
            if (root == null) return 0;
            var sum = 0;
            var stack = new Stack<Node>();
            stack.Push(root);

            while (stack.Count != 0)
            {
                Node p= stack.Pop();
                sum += p.val;
                if(p.LChild != null) stack.Push(p.LChild);
                if(p.RChild != null) stack.Push(p.RChild);
            }
            return sum;
        }

        public static int TreeSumRecur(Node root)
        {
            if (root == null) return 0;
            return root.val + TreeSum(root.LChild) + TreeSum(root.RChild);
        }

        public static int MinTreeValue(Node root)
        {
            if (root == null) return int.MaxValue;
            var leftMin = MinTreeValue(root.LChild);
            var rightMin = MinTreeValue(root.RChild);
            return Math.Min(root.val, Math.Min(leftMin, rightMin));
        }

        public static int MaxPathSum(Node root)
        {
            if (root == null) return -int.MaxValue;
            if (root.LChild == null && root.RChild == null) return root.val;
            var maxChildPathSum = Math.Max(MaxPathSum(root.LChild), MaxPathSum(root.RChild));
            return root.val + maxChildPathSum;
        }


        public static int MaxPathSumB(Node root)
        {
            var max = int.MinValue;
            var dict = new Dictionary<Node, int>();

            foreach (Node t in PostOrder(root))
            {
                int leftSum = t.LChild == null ? 0 : Math.Max(0, dict[t.LChild]);
                int right = t.RChild == null ? 0 : Math.Max(0, dict[t.RChild]);
                max = Math.Max(max, (leftSum + right + t.val));
                dict.Add(t, Math.Max(leftSum, right) + t.val);
            }

            return max;
        }

        public static List<Node> PostOrder(Node root)
        {
            var stack = new Stack<Node>();
            var output = new Stack<Node>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                Node p = stack.Pop();
                output.Push(p);
                if(p.LChild != null) stack.Push(p.LChild);
                if(p.RChild != null) stack.Push(p.RChild);
            }

            return output.ToArray().ToList();
        }


    }
}
