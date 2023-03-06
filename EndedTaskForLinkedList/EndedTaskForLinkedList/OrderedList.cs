using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EndedTaskForLinkedList
{
    internal class OrderedList<T> where T :
        IComparable
    {
        ListNode<T>? head;

        // 1  <--> 2 -><-3

        public int Count
        {
            get
            {
                var count = 0;
                var current = head;
                while (current != null)
                    count++;
                return count;
            }
        }

        public void Add(T value)
        {
            var node = new ListNode<T>(value);
            if (head == null)
            {
                head = node;
            }
            else
            {
                if (node.val.CompareTo(head.val) < 0)
                {
                    node.next = head;
                    head = node;
                }
                else
                {
                    ListNode<T> current = head;

                    while (current.next != null && current.next.val.CompareTo(node.val) < 0)
                    {
                        current = current.next;
                    }
                    node.next = current.next;
                    current.next = node;
                }
            }
        }

        private void DeleteFirst()
        {
            head = head?.next; //?? throw new NullReferenceException();
        }

        public void Delete(T value)
        {
            var valFineded = false;
            var curr = head;
            ListNode<T> prev = null!;
            while(curr != null)
            {
                if (value.CompareTo(curr.val) == 0 && prev != null)
                {
                    var n = curr.next;
                    prev.next = n;
                    curr = prev;
                    valFineded = true;
                }
                else if (prev == null && value.CompareTo(curr.val) == 0)
                {
                    DeleteFirst();
                    valFineded = true;
                    break;
                }
                else
                {
                    prev = curr;
                    curr = curr.next;
                }
            }

            if(!valFineded)
                Console.WriteLine("Такого элементы в списке нет!");
            else
                Console.WriteLine("Элемент удален!");
        }

        public void MergeLinkedList(OrderedList<T>? second)
        {
            var curr = head;
            var currSec = second.head;
            if(curr.next.val.CompareTo(currSec.val) > 0)
            {
                ListNode<T> t = curr;
                curr = currSec;
                currSec = t;
            }
            head = curr;
            while(curr.next != null && currSec != null)
            {
                if(curr.next.val.CompareTo(currSec.val) < 0)
                {
                    curr = curr.next;
                }
                else
                {
                    var temp = curr.next;
                    var temp2 = currSec.next;
                    curr.next = currSec;
                    currSec.next = temp;
                    curr = curr.next;
                    currSec = temp2;
                }
            }
            curr.next = currSec;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var current = head;
            while(current != null)
            {
                sb.Append(current.val.ToString() + " -> ");
                current = current.next;
            }
            return sb.ToString();
        }
    }
}
