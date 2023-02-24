using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Polinom
{
    internal class ZhegalkinPolinom
    {
        private Action<String> _action = (message) => { Console.WriteLine(message); };
        private List<Konj> _konjs = new List<Konj>();

        public ZhegalkinPolinom()
        {

        }

        public ZhegalkinPolinom(string s)
        {
            var polinom = s.Split('+');
            Konj item;
            foreach (var it in polinom)
            {
                item = new Konj();
                for (int i = 0; i < it.Length; i++)
                {
                    if (int.TryParse(it[i].ToString(), out int x))
                        item.Add(x);
                }
                _konjs.Add(item);
            }
        }
        public void Insert(Konj k)
        {
            var count = 0;
            int j = 0;
            for (int i = 0; i < _konjs.Count; i++)
            {
                if (_konjs[i].All(x => x == k[j++]))
                {
                    count++;
                    j = 0;
                }
                else
                    j = 0;
            }

            if (count > 0)
                _action("Часть конънкции уже присутсвует в полиноме, вы не можете " +
                    "добавить ее!");
            else
                _konjs.Add(k);
        }
        public ZhegalkinPolinom Sum(ZhegalkinPolinom p)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < _konjs.Count; i++)
                sb.Append(_konjs[i] + "+");
            for (int i = 0; i < p._konjs.Count; i++)
                sb.Append(p._konjs[i] + "+");

            string[] cont = sb.ToString().Split('+').Distinct().ToArray();
            return new ZhegalkinPolinom(cont.ToString() ?? "null");
        }
        public void SortByLength()
        {
            for (int i = 0; i < _konjs.Count; i++)
            {
                for (int j = i + 1; j < _konjs.Count; j++)
                {
                    if (_konjs[i].Count > _konjs[j].Count)
                        (_konjs[i], _konjs[j]) = (_konjs[j], _konjs[i]);
                }
            }
        }
        public ZhegalkinPolinom PolinomWith(int i)
        {
            var sb = new StringBuilder();
            for (int j = 0; j < _konjs.Count; j++)
            {
                if (!_konjs[j].Contains(i))
                {
                    _konjs[j].Add(i);
                }
            }

            return new ZhegalkinPolinom(ToString());
        }


        public override string ToString()
        {
            var sb = new StringBuilder();   
            for (int i = 0; i < _konjs.Count; i++)
                sb.Append($"{_konjs[i]}+");
            sb = sb.Remove(sb.Length - 1,1);
            return sb.ToString();
        }
    }
}
