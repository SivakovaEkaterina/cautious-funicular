using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace кафе
{
    internal class Vvod
    {
        public string[] Hi()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine("=============================");
            Console.WriteLine("  Логин:                     ");
            Console.WriteLine("  Пароль:                    ");
            Console.WriteLine("  Подтвердить.");
            Console.WriteLine("=============================");
            Console.SetCursorPosition(10, 1);
            Strelka st = new Strelka();
            string password = "";
            string login = "";
            while (true)
            {
                int vib = st.Strel(1, 3);
                if (vib == 1)
                {
                    Console.SetCursorPosition(0, 1);
                    Console.Write("  ");
                    Console.SetCursorPosition(9, 1);
                    Console.WriteLine("                ");
                    Console.SetCursorPosition(9, 1);
                    login = Console.ReadLine();
                }
                
                if (vib == 2)
                {
                    int b = 10;
                    Console.SetCursorPosition(0, 2);
                    Console.Write("  ");
                    Console.SetCursorPosition(b, 2);
                    Console.WriteLine("                ");
                    Console.SetCursorPosition(b, 2);
                    ConsoleKeyInfo k;
                    do
                    {
                        k = Console.ReadKey(true);
                        if (k.Key == ConsoleKey.Enter)
                        {
                            Console.SetCursorPosition(0, 2);
                            break;
                        }
                        if (k.Key == ConsoleKey.Backspace)
                        {
                            Console.SetCursorPosition(b-1, 2);
                            Console.WriteLine(" ");
                            int s = password.Length - 1;
                            password = password.Remove(s);
                            b--;
                            if (b<10)
                            {
                                b++;
                            }
                            Console.SetCursorPosition(b, 2);

                        }
                        else
                        {
                            string s = k.KeyChar.ToString();
                            password = password + s;
                            Console.Write("*");
                            b++;
                        }
                        
                    } while (true);
                }
                if (vib == 3)
                {
                    Console.SetCursorPosition(0, 3);
                    Console.Write("  ");
                    break;
                }
                
            }
            string[] inf = new string[] { login, password };
            return inf;
        }
    }
}
