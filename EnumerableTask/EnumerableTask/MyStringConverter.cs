using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerableTask
{
    internal class MyStringConverter : IEnumerable<string>
    {
        private string[] _subbs;
        private ClassIEnumerator _orderedWords;

        public MyStringConverter(string text)
        {
            _subbs = text.Trim().Split(' ');
            _orderedWords = new ClassIEnumerator(_subbs);
            _orderedWords.GetOrderedWords();
        }

        public IEnumerable<string> GetOrderedWowrds()
        {
            foreach (var word in _orderedWords)
                yield return (string)word;
        }

        public IEnumerator<string> GetEnumerator()
        {
            return new MyEnumerator(_subbs);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
