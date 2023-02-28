using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerableTask
{
    internal class MyEnumerator : IEnumerator<string>
    {
        private string[] _subbs;
        private int _position = -1;

        public MyEnumerator(string[] subbs)
        {
            this._subbs = subbs;
        }

        public string Current => _subbs[_position];

        object IEnumerator.Current => throw new NotImplementedException();

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _subbs.Length;
        }

        public void Reset()
        {
            _position = -1;
        }
    }
}
