using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace кафе
{
    internal class Strelka
    {
        public int Strel(int a, int z)
        {
            int p = a;
            ConsoleKeyInfo k;
            int b = 3;
            int c = 1;
            Console.SetCursorPosition(0, a);
            Console.WriteLine("->");
            int f = 10;
            while (c != 0)
            {
                k = Console.ReadKey();
                if (k.Key == ConsoleKey.DownArrow)
                {
                    b = p;
                    p++;
                }
                if (k.Key == ConsoleKey.UpArrow)
                {
                    b = p;
                    p--;
                }
                if (k.Key == ConsoleKey.Enter)
                {
                    c = 0;
                }
                if (k.Key == ConsoleKey.Escape || k.Key == ConsoleKey.S)
                {
                    c = 0;
                    f = 0;
                }
                if (p == -1)
                {
                    p = 0;
                }
                if (p < a)
                {
                    p = a;
                    b = p + 1;
                }
                if (p > z)
                {
                    p = z;
                    b = p - 1;
                }
                Console.SetCursorPosition(0, p);
                Console.WriteLine("->");
                Console.SetCursorPosition(0, b);
                Console.WriteLine("  ");
            }
            if (f == 0)
            {
                p = f;
            }
            return p;
        }
    }
}
