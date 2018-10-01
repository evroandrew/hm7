using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeTask7_a
{
    class Program
    {
        static int check1()
        {
            for (; ; )
            {
                Console.Write(" = __\b\b");
                string str = Console.ReadLine();
                int d1 = 0;
                if ((!Int32.TryParse(str, out d1)) | (d1 < 0))
                {
                    Console.WriteLine("Try again...");
                }
                else
                    return d1;
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter dimension of Matrix");
            int x = check1();
            int y = check1();
            Matrix matrix1 = new Matrix(x, y);
            Console.WriteLine("Enter dimension of Matrix");
            x = check1();
            y = check1();
            Matrix matrix2 = new Matrix(x, y);
            ConsoleKeyInfo gb;
            do
            {
                Console.Clear();
                Console.WriteLine("Enter 1 to show matrix ");
                Console.WriteLine("Enter 2 to random fill");
                Console.WriteLine("Enter 3 to manual fill");
                Console.WriteLine("Enter 4 to show expressions");
                Console.WriteLine("Enter 0 to exit");
                gb = Console.ReadKey();
                Console.Clear();
                if (gb.Key == ConsoleKey.NumPad1)
                { matrix1.Show(); matrix2.Show(); }
                if (gb.Key == ConsoleKey.NumPad2)
                { matrix1.Fill_rng(); matrix2.Fill_rng(); }
                if (gb.Key == ConsoleKey.NumPad3)
                { matrix1.Fill(); matrix2.Fill(); }
                if (gb.Key == ConsoleKey.NumPad4)
                {
                    Console.WriteLine("matrix1 + matrix2\n"+(matrix1 + matrix2));
                    Console.WriteLine("matrix1 - matrix2\n" + (matrix1 - matrix2));
                    Console.WriteLine("matrix1 *2\n" + (matrix1 * 2));
                    Console.WriteLine("matrix1 * matrix2\n"+(matrix1 * matrix2));
                    Console.WriteLine("matrix1 /2\n" + (matrix1 / 2));
                    Console.WriteLine($"det = {matrix1.det():0.#}");
                }
                Console.ReadKey();
            } while (gb.Key != ConsoleKey.NumPad0);
            Console.ReadKey();
        }
    }
}
