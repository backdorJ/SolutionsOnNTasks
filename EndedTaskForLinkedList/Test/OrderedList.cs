using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class OrderedList<T> where T : 
        IComparable
    {
        ListNode<T>? head;

        public void Add(T item)
        {
            if(head == null)
            {
                head = new ListNode<T>(item);
                return;
            }
            else
            {
                var curr = head;
                while(curr != null)
                {

                }
            }
        }
    }
}
