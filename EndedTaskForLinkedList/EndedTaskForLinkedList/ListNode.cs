using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndedTaskForLinkedList
{
    internal class ListNode<T>
    {
        public T val;
        public ListNode<T>? next;
        public ListNode(T val)
        {
            this.val = val;
        }
    }
}
