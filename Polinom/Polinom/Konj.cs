using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polinom
{
    internal class Konj : IList<int>
    {
        List<int> list;
        int zero;
        public int this[int index]
        { 
            get
            {
                if (index > list.Count || index < 0)
                    throw new IndexOutOfRangeException();
                return list[index];
            }
            set
            {
                if (index > list.Count || index < 0)
                    throw new IndexOutOfRangeException();
                list[index] = value;
            }
        }

        public Konj()
        {
            list = new List<int>();
        }

        public int Count => list.Count;

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(int item)
        {
            if (item == 0)
            { 
                list.Add(1);
                zero = -1;
            }
            else
                list.Add(item);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(int item)
        {
            bool flag = false;
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == item)
                    flag = true;
            }

            return flag;
        }

        public void CopyTo(int[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }
        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < list.Count; i++)
            {
                yield return list[i];
            }
        }

        public int IndexOf(int item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, int item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(int item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if(list.Count == 1 && zero == -1)
                {
                    sb.Append('1');
                    zero = 0;
                }
                else
                    sb.Append($"X{list[i]}");
            }
            return sb.ToString();
        }

    }
}
