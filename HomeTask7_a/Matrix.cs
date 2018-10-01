using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask7_a
{
    class Matrix
    {
        private static Random rng = new Random();
        int size_x { get; set; }
        int size_y { get; set; }
        double[,] arr;
        public Matrix(int x, int y)
        {
            size_x = x;
            size_y = y;
            arr = new double[x, y];
        }
        private double check1()
        {
            for (; ; )
            {
                Console.Write(" : __\b\b");
                string str = Console.ReadLine();
                double a1 = 0;
                if (!Double.TryParse(str, out a1))
                {
                    Console.WriteLine("Try again...");
                }
                else
                    return a1;
            }
        }
        public void Fill()
        {
            for (int i = 0; i < size_x; i++)
            {
                for (int j = 0; j < size_y; j++)
                {
                    Console.Write($"arr[{i}, {j}]\t");
                    arr[i, j] = check1();
                }
            }
        }
        public void Fill_rng()
        {
            for (int i = 0; i < size_x; i++)
            {
                for (int j = 0; j < size_y; j++)
                {
                    arr[i, j] = rng.Next(-100, 100) / 10.0;
                }
            }
        }
        public void Show()
        {
            for (int i = 0; i < size_y; i++)
            {
                for (int j = 0; j < size_x; j++)
                {
                    Console.Write($"{arr[j, i]:0.#}\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < size_y; i++)
            {
                for (int j = 0; j < size_x; j++)
                {

                    s += $"{arr[j, i]:0.#}\t";
                }
                s += "\n";
            }
            return s;
        }
        public double det()
        {
            Matrix C = this;
            if (C.size_x == C.size_y)
            {
                for (int ik = 0; ik < size_x - 1; ik++)
                    for (int j = ik + 1; j < size_x; j++)
                    {
                        double acd = -C.arr[ik, j] / C.arr[ik, ik];
                        for (int i = 0; i < C.size_y; i++)
                        {
                            C.arr[i, j] += acd * C.arr[i, ik];
                        }
                    }
                double det = 1;
                for (int i = 0; i < size_x; i++)
                {
                    det *= C.arr[i, i];
                }
                return det;
            }
            Console.WriteLine("The dimension of the matrix doesn't coincide");
            return 0;
        }
        public static Matrix operator -(Matrix a, Matrix b)
        {
            if (a == null)
                return -b;
            if (b == null)
                return a;
            if ((a.size_x == b.size_x) & (a.size_y == b.size_y))
            {
                Matrix c = new Matrix(a.size_x, a.size_y);
                for (int i = 0; i < a.size_x; i++)
                {
                    for (int j = 0; j < a.size_y; j++)
                    {
                        c.arr[i, j] = a.arr[i, j] - b.arr[i, j];
                    }
                }
                return c;
            }
            else
            {
                Console.WriteLine("The dimension of the matrices doesn't coincide");
                return null;
            }
        }
        public static Matrix operator +(Matrix a, Matrix b)
        {
            if (a == null)
                return b;
            if (b == null)
                return a;
            if ((a.size_x == b.size_x) & (a.size_y == b.size_y))
            {
                Matrix c = new Matrix(a.size_x, a.size_y);
                for (int i = 0; i < a.size_x; i++)
                {
                    for (int j = 0; j < a.size_y; j++)
                    {
                        c.arr[i, j] = a.arr[i, j] + b.arr[i, j];
                    }
                }
                return c;
            }
            else
            {
                Console.WriteLine("The dimension of the matrices doesn't coincide");
                return null;
            }
        }
        public static Matrix operator -(Matrix a)
        {
            for (int i = 0; i < a.size_x; i++)
            {
                for (int j = 0; j < a.size_y; j++)
                {
                    a.arr[i, j] *= -1;
                }
            }
            return a;
        }
        public static Matrix operator *(Matrix a, double b)
        {
            if (a == null)
                return a;
            Matrix c = new Matrix(a.size_x, a.size_y);
            for (int i = 0; i < a.size_x; i++)
            {
                for (int j = 0; j < a.size_y; j++)
                {
                    c.arr[i, j] = a.arr[i, j] * b;
                }
            }
            return c;
        }
        public static Matrix operator *(int b, Matrix a)
        {
            if (a == null)
                return a;
            Matrix c = new Matrix(a.size_x, a.size_y);
            for (int i = 0; i < a.size_x; i++)
            {
                for (int j = 0; j < a.size_y; j++)
                {
                    c.arr[i, j] = a.arr[i, j] * b;
                }
            }
            return c;
        }
        public static Matrix operator *(Matrix b, Matrix a)
        {
            if ((a == null) | (b == null))
                return null;
            if (a.size_x == b.size_y)
            {
                Matrix c = new Matrix(a.size_y, b.size_x);
                for (int i = 0; i < a.size_x; i++)
                {
                    for (int j = 0; j < b.size_y; j++)
                    {
                        c.arr[i, j] = 0;
                        for (int inner = 0; inner < a.size_y; inner++)
                            c.arr[i, j] += (a.arr[i, inner] * b.arr[inner, j]);
                    }
                }
                return c;
            }
            Console.WriteLine("The dimension of the matrices doesn't coincide");
            return null;
        }
        public static Matrix operator /(Matrix a, double b)
        {
            if (a == null)
                return a;
            Matrix c = new Matrix(a.size_x, a.size_y);
            for (int i = 0; i < a.size_x; i++)
            {
                for (int j = 0; j < a.size_y; j++)
                {
                    c.arr[i, j] = a.arr[i, j] / b;
                }
            }
            return c;
        }
    }
}