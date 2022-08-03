using System;
using System.Linq;

namespace LinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList list = new LinkedList();

            list.InsertAtHead(2);
            list.InsertAtHead(3);
            list.InsertAtHead(4);
            list.InsertAtHead(1);

            var arr = new int[] {3,4,0,2,1};

            var x = list.MaximumPages(list);
            Console.WriteLine();
           
        }
    }
}
