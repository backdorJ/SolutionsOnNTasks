using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConsoleApp2
{
    internal class MaxMin
    {
        private List<int> _mins = new List<int>();
        private int[,] matrix;
        private object _lock = new object();
        public MaxMin(int szie)
        {
            matrix = GetMatrix(szie);
        }

        public void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        private int[,] GetMatrix(int size)
        {
            var rnd = new Random();
            var matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = rnd.Next(0, 29);
                }
            }

            return matrix;
        }

        public int GetMax()
        {
            var tasks = new Task<int>[matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                tasks[i] = GetMatInRow(i);
                _mins.Add(tasks[i].Result);
            }


            return _mins.Max();
        }


        private Task<int> GetMatInRow(object index)
        {
            var min = int.MaxValue;
            return Task.Run(() =>
            {
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    if (min > matrix[(int)index, i])
                        min = matrix[(int)index, i];
                }

                return min;
            });
        }
    }
}
