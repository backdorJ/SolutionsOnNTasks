using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListSelf
{
    public class Elem<T>
    {
        public T Info { get; set; }
        public Elem<T> Next { get; set; }
    
        public Elem(T Info)
        {
            this.Info = Info;
        }
    }

    public class MyLinkedlist<T>
    {
        private Elem<T> first;
        private int val = 0;

        public int Count
        {
            get
            {
                int k = 0;
                var el = first;
                while (el != null)
                {
                    k++;
                    el = el.Next;
                }
                return k;

            }
        }

        public void AddFirst(T info)
        {
            var el = new Elem<T>(info);
            el.Next = first;
            first = el;
        }

        public void AddLast(T Info)
        {
            if(first == null)
            {
                AddFirst(Info);
                return;
            }
            var curr = first;
            while(curr.Next != null)
            {
                curr = curr.Next;
            }

            curr.Next = new Elem<T>(Info);
        }

        public void DeleteFirst()
        {
            if (first == null)
                return;
            first = first.Next;
        }

        public void DeleteLast()
        {
            if (first == null)
                return;
            if (first.Next == null)
            {
                DeleteFirst();
                return;
            }
            var el = first;
            while (el.Next.Next != null)
                el = el.Next;
            el.Next = null;
        }

        public void AddElementAfter(T info, int k)
        {
            var el = first;
            while(el != null)
            {
                if(val == k)
                {
                    var n = el.Next;
                    el.Next = new Elem<T>(info);
                    el.Next.Next = n;
                 }
                val++;
                el = el.Next;
            }
        }

        public void DeleteK(int k)
        {
            var el = first;
            int val = 0;
            Elem<T> prevEL = null;
            while (el != null)
            {
                if (val == k)
                {
                    var n = el.Next;
                    prevEL.Next = n;
                    el = prevEL;

                }

                prevEL = el;
                el = el.Next;
                val++;
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            var el = first;
            while(el != null)
            {
                sb.Append(el?.Info?.ToString() + " ");
                el = el?.Next;
            }

            return sb.ToString();
        }
    }
}
