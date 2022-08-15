using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeProject
{
    public class BinaryTrees
    {
        private Node root;

        public BinaryTrees()
        {
            root = null;
        }

        public void CreateTree()
        {
            root = new Node('T');
            root.LChild = new Node('A');
            root.RChild = new Node('X');
            root.LChild.LChild = new Node('S');
            root.LChild.RChild = new Node('E');
        }
        
        public void Display()
        {
            Display(root, 0);
            Console.WriteLine();
        }

        public void Display(Node p, int level)
        {
            int i;
            if (p == null)
            {
                return;
            }
            Display(p.RChild, level + 1);
            Console.WriteLine();

            for (i = 0; i < level; i++)
            {
                Console.Write(" ");
            }

            Console.Write(p.Info);
            Display(p.LChild, level + 1);
        }

        public void Preorder()
        {
            Preorder(root);
            Console.WriteLine();
        }

        private void Preorder(Node p)
        {
            if (p == null)
            {
                return;
            }

            Console.WriteLine(p.Info + " ");
            Preorder(p.LChild);
            Preorder(p.RChild);
        }

        public void Inorder()
        {
            Inorder(root);
            Console.WriteLine();
        }

        private void Inorder(Node p)
        {
            if (p == null)
                return;
            Inorder(p.LChild);
            Console.WriteLine(p.Info + " ");
            Inorder(p.RChild);
        }

        public void Postorder()
        {
            Postorder(root);
            Console.WriteLine();
        }

        public void Postorder(Node p)
        {
            if(p == null)
                return;
            Postorder(p.LChild);
            Postorder(p.RChild);
            Console.WriteLine(p.Info + "");
        }

        public void LevelOrder()
        {
            if (root == null) return;
            var queue = new Queue<Node>();
            queue.Enqueue(root);

            while (queue.Count != 0)
            {
                Node p = queue.Dequeue();
                Console.WriteLine(p.Info);
                if(p.LChild != null)
                    queue.Enqueue(p.LChild);
                if (p.RChild != null)
                {
                    queue.Enqueue(p.RChild);
                }

                Console.WriteLine();
            }
        }

        public int Height()
        {
            return Height(root);
        }

        private int Height(Node p)
        {
            if (p == null) return 0;

            int hL = Height(p.LChild);
            int hR = Height(p.RChild);

            if (hL > hR)
            {
                return 1 + hL;
            }
            else
            {
                return 1 + hR;
            }
        }

        //Traversals 2
        public IList<int> InorderTraversal(Node root)
        {
            IList<int> res = new List<int>();
            Stack<Node> stack = new();

            while (root != null && stack.Count > 0)
            {
                while (root != null)
                {
                    stack.Push(root);
                    root = this.root.LChild;
                }

                root = stack.Pop();
                res.Add(root.Info);
                root = this.root.RChild;
            }
            return res;
        }
    }
}
