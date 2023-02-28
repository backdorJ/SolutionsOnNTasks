using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace EnumerableTask
{
    internal class ClassIEnumerator : IEnumerable
    {
        private string[] _subbs;
        //private int _position = -1;

        public ClassIEnumerator(string[] subbs)
        {
            _subbs = subbs;
        }

        public void GetOrderedWords()
        {
            for (int i = 0; i < _subbs.Length; i++)
            {
                for (int j = i + 1; j < _subbs.Length; j++)
                {
                    if (_subbs[i].Length > _subbs[j].Length)
                        (_subbs[i], _subbs[j]) = (_subbs[j], _subbs[i]);
                }
            }
        }

        public IEnumerator GetEnumerator()
        {
            foreach (var sub in _subbs)
            {
                yield return sub;
            }
        }
    }
}
