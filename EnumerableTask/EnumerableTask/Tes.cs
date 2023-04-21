using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerableTask
{
    internal class Tes : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return $"{i}";
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
