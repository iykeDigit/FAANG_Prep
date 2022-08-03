using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    public class LinkedList
    {
        public class Node
        {
            public int Data;
            public Node NextElement;

            public Node()
            {
                NextElement = null;
            }
        };

        public Node Head;

        public LinkedList()
        {
            Head = null;
        }

        
        public int MaximumPages(LinkedList list)
        {
            var fast = list.Head;
            var slow = list.Head;
            var max = int.MinValue;
            var first = list.Head;

            while (fast != null && fast.NextElement != null)
            {
                slow = slow.NextElement;
                fast = fast.NextElement.NextElement;
            }

            //reverse from the middle
            Node prev = null;

            while (slow != null)
            {
                Node currentNode = slow.NextElement;
                slow.NextElement = prev;
                prev = slow;
                slow = currentNode;
            }

           while (first != null && prev != null)
            {
                max = Math.Max(max, first.Data + prev.Data);
                first = first.NextElement;
                prev = prev.NextElement;
            }

            return max;

        }

        //public int MaximumPages(LinkedList list)
        //{
        //    var max = int.MinValue;
        //    var head = list.Head;

        //    if (head == null) return 0;
        //    if (head.NextElement == null) return head.Data;

        //    Node slow = head;
        //    Node fast = head;

        //    while (fast != null && fast.NextElement != null)
        //    {
        //        slow = slow.NextElement;
        //        fast = fast.NextElement.NextElement;
        //    }

        //    Node first = head;

        //    //Reverse here
        //    Node prev = null;
        //    while (slow != null)
        //    {
        //        Node nextNode = slow.NextElement;
        //        slow.NextElement = prev;
        //        prev = slow;
        //        slow = nextNode;
        //    }

        //    while (first != null && prev != null)
        //    {
        //        max = Math.Max(max, first.Data + prev.Data);
        //        first = first.NextElement;
        //        prev = prev.NextElement;
        //    }

        //    return max;
        //}
        public int MaximumPagess(LinkedList list)
        {
            var max = int.MinValue;
            List<int> nums = new();
            

            while (list.Head != null)
            {
                nums.Add(list.Head.Data);
                list.Head = list.Head.NextElement;
            }

            var first = 0;
            var last = nums.Count - 1;

            while (first < last)
            {
                max = Math.Max(max, nums[first] + nums[last]);
                first++;
                last--;
            }

            return max;
        }
        public int NumComponents(LinkedList list, int[] g)
        {
            var count = 0;
            var connected = false;
            var h = new HashSet<int>(g);
            var head = list.Head;

            while (head != null)
            {
                if (h.Add(head.Data))
                {
                    connected = false;
                }

                else if (!connected)
                {
                    count++;
                    connected = true;
                }

                head = head.NextElement;
            }


            return count;
        }
        public Node ReverseLinkedList(LinkedList list)
        {
            Node previous = null;
            

            while (list.Head != null)
            {
                Node newNode = list.Head.NextElement;
                list.Head.NextElement = previous;
                previous = list.Head;
                list.Head = newNode;
            }

            list.Head = previous;
            return list.Head;
        }
        public bool DeleteAtHead()
        {
            if (Head == null) return false;

            Head = Head.NextElement;
            return true;
        }

        public bool DeleteByValue(int value)
        {
            Node currentNode = Head.NextElement;
            Node previous = new Node();

            if (Head.Data == value)
            {
                currentNode = Head;
            }

            while (currentNode != null)
            {
                if (currentNode.Data == value)
                {
                    previous.NextElement = currentNode.NextElement;
                    currentNode = previous.NextElement;
                    return true;
                }

                previous = currentNode;
                currentNode = currentNode.NextElement;
            }
            return false;
        }
        public bool SearchList(int value)
        {
            Node currentNode = Head;

            if (currentNode == null) return false;

            while (currentNode != null)
            {
                if (currentNode.Data == value)
                {
                    return true;
                }

                currentNode = currentNode.NextElement;
            }

            return false;
        }
        public void InsertAtTail(int value)
        {
            Node newNode = new Node();
            newNode.Data = value;
            Node currentNode = Head;

            if (currentNode == null)
            {
                Head = newNode;
            }

            while (currentNode != null)
            {
                if (currentNode.NextElement == null)
                {
                    currentNode.NextElement = newNode;
                    break;
                }

                currentNode = currentNode.NextElement;
            }
        }

        public void InsertAtHead(int value)
        {
            Node newNode = new Node();
            newNode.Data = value;
            newNode.NextElement = Head;
            Head = newNode;
            Console.WriteLine(value + " Inserted !    ");
        }

        public bool printList()
        {
            if (IsEmpty())
            {
                Console.WriteLine("List is Empty!");
                return false;
            }

            Node temp = Head;
            Console.WriteLine("List : ");

            while (temp != null)
            {
                Console.WriteLine(temp.Data + "->");
                temp = temp.NextElement;
            }

            Console.WriteLine("null ");
            return true;
        }
        public bool IsEmpty()
        {
            if (Head == null)
                return true;
            return false;
        }


    }
}
