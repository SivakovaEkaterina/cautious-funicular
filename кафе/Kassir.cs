using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace кафе
{
    internal class Kassir
    {
        public Strelka str = new Strelka();
        public ConsoleKeyInfo key;
        public void Privetstvie(int id)
        {
            int itog = 0;
            while (true)
            {
                string put = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string file = put + "\\Кафешка" + "\\Склад.json";
                if (!File.Exists(file))
                {
                    Console.WriteLine("Склад пустой! Зайдите туда и добавьте данные");
                }
                Tekst(id);
                Console.SetCursorPosition(94, 15);
                Console.Write("Итог: " + itog);
                List<Sklad> skl = Deser_and_Seril.DeCer<List<Sklad>>("Склад.json");
                Pokupka pokup = new Pokupka();

                int b = 3;
                foreach (var pleer in skl)
                {
                    Console.SetCursorPosition(2, b);
                    Console.WriteLine(pleer.ID);
                    Console.SetCursorPosition(10, b);
                    Console.WriteLine(pleer.Name);
                    Console.SetCursorPosition(40, b);
                    Console.WriteLine(pleer.Sena);
                    Console.SetCursorPosition(50, b);
                    Console.WriteLine(pleer.Koli);
                    Console.SetCursorPosition(65, b);
                    Console.WriteLine("0");


                    b++;
                }
                Console.SetCursorPosition(0, 2);
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.F1)
                {
                    itog = Byer(id);
                    
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    break;
                }
            }
        }
        public int Byer(int id)
        {
            Pokupka pokup = new Pokupka();
            List<Pokupka> pop = new List<Pokupka>();
            List<Sklad> rab = Deser_and_Seril.DeCer<List<Sklad>>("Склад.json");
            Console.SetCursorPosition(94, 15);
            Console.Write("Итог: 0      ");
            foreach (var item in rab)
            {
                pokup.ID = item.ID;
                pokup.Name = item.Name;
                pokup.Sena = item.Sena;
                pokup.Koli = item.Koli;
                pokup.Vibr = 0;
                pop.Add(pokup);
            }
            int z = 3 + rab.Count;
            int mscht = 0;
            int itog = 0;
            while (true)
            {

                int d = str.Strel(3, z);
                if (d == 0)
                {
                    break;
                }
                mscht = rab[d - 3].Koli;
                pop[d - 3].Vibr = 0;
                while (true)
                {
                    Console.SetCursorPosition(0, d);
                    Console.WriteLine("  ");
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.OemPlus)
                    {
                        int t = pop[d - 3].Vibr;
                        t++;
                        Console.SetCursorPosition(65, d);
                        Console.WriteLine("   ");
                        Console.SetCursorPosition(65, d);
                        if (t > mscht)
                        {
                            t = mscht;
                        }
                        Console.WriteLine(t);
                        pop[d - 3].Vibr = t;
                    }
                    if (key.Key == ConsoleKey.OemMinus)
                    {
                        int t = pop[d - 3].Vibr;
                        t--;
                        Console.SetCursorPosition(65, d);
                        Console.WriteLine("   ");
                        Console.SetCursorPosition(65, d);
                        if (t < 0)
                        {
                            t = 0;
                        }
                        Console.WriteLine(t);
                        pop[d - 3].Vibr = t;
                    }
                    if (key.Key == ConsoleKey.Enter)
                    {
                        pop[d - 3].Sena = pop[d - 3].Vibr * rab[d - 3].Sena;
                        pop[d - 3].Koli = rab[d - 3].Koli - pop[d - 3].Vibr;
                        break;
                    }
                    
                }
                itog = itog + pop[d - 3].Sena;
                rab[d - 3].Koli = pop[d - 3].Koli;
                
            }

            Deser_and_Seril.Cerialaz(rab, "Склад.json");
            List<Dengi> dengi = Deser_and_Seril.DeCer<List<Dengi>>("Бухгалтерский учёт.json");
            Dengi dop = new Dengi();
            dop.ID = dengi.Count + 1;
            dop.SumDen = itog;
            if (itog >0)
            {
                dop.PluMin = 1;
            }
            else
            {
                dop.PluMin = 0;
            }
            dop.Name = "Продажа товара";
            Console.SetCursorPosition(0, z+1);
            Console.Write("Введите дату: ");
            dop.Date = Console.ReadLine();
            dengi.Add(dop);
            Deser_and_Seril.Cerialaz(dengi, "Бухгалтерский учёт.json");

            return itog;
        }
        private void Tekst(int id)
        {
            Console.Clear();
            int b = 0;
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("========================================================================================================================");
            List<Sotrudniki> rab = Deser_and_Seril.DeCer<List<Sotrudniki>>("Данные сотрудников.json");
            int d = 0;
            foreach (var pleer in rab)
            {
                if (pleer.Work == "Kassa" && pleer.Name != null && pleer.ID == id)
                {
                    Console.SetCursorPosition(50, 0);
                    Console.WriteLine("----- " + pleer.Name + " -----");
                    d++;
                }
            }
            if (d == 0)
            {
                Console.SetCursorPosition(50, 0);
                Console.WriteLine("----Кассир------");
            }

            while (b != 29)
            {
                Console.SetCursorPosition(85, b);
                Console.WriteLine("||");
                b++;
            }
            Console.SetCursorPosition(93, 7);
            Console.WriteLine("F1 - новая покупка");

            Console.SetCursorPosition(2, 2);
            Console.WriteLine("ID");
            Console.SetCursorPosition(10, 2);
            Console.WriteLine("Название товара");
            Console.SetCursorPosition(40, 2);
            Console.WriteLine("Цена");
            Console.SetCursorPosition(50, 2);
            Console.WriteLine("Колличество");
            Console.SetCursorPosition(65, 2);
            Console.WriteLine("Выбранно");
        }

    }
}
