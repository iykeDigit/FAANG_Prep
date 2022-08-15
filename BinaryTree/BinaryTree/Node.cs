using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeProject
{
    public class Node
    {
        public Node LChild;
        public char Info;
        public Node RChild;

        public Node(char ch)
        {
            Info = ch;
            LChild = null;
            RChild = null;
        }
    }
}
