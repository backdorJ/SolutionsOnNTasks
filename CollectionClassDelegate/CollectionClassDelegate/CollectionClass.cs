using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace CollectionClassDelegate
{
    internal class CollectionClass<T>
    {
        private new List<T> _collection;
        public CollectionClass(List<T> collection)
        {
            _collection = collection;
        }

        public int Count(Func<T, bool> predicate) 
        {
            var count = 0;
            foreach (var item in _collection)
            {
                if (predicate(item))
                    count++;
            }

            return count;
        }

        public T1 Aggreagete<T1>(Func<T1,T,T1> function)
        {
            var temp = default(T1);
            foreach (var item in _collection) 
                temp = function(temp,item);

            return temp;
        }
    }
}
