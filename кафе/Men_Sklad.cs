using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace кафе
{
    internal class Men_Sklad : ICRUD
    {
        public Strelka str = new Strelka();
        public ConsoleKeyInfo key;
        public void Privetstvie(int id)
        {
            while (true)
            {
                string put = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string file = put + "\\Кафешка" + "\\Склад.json";
                if (!File.Exists(file))
                {
                    Sklad pust = new Sklad();
                    List<Sklad> sklad = new List<Sklad>();
                    pust.ID = 0;
                    pust.Name = "Пакетик сахара";
                    pust.Sena = 10;
                    pust.Koli = 100;
                    sklad.Add(pust);
                    File.Create(put + "\\Кафешка\\Склад.json").Close();
                    Deser_and_Seril.Cerialaz(sklad, "\\Склад.json");
                }
                Tekst(id);
                List<Sklad> skl = Deser_and_Seril.DeCer<List<Sklad>>("Склад.json");

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
                    if (pleer.Koli > 10)
                    {
                        Console.WriteLine("o");
                    }
                    else if (pleer.Koli > 3)
                    {
                        Console.WriteLine("!");
                    }
                    else
                    {
                        Console.WriteLine("Х");
                    }
                    

                    b++;
                }
                Console.SetCursorPosition(0, 2);
                key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.F1)
                {
                    Create(id);
                }
                if (key.Key == ConsoleKey.F2)
                {
                    Delet(id);
                }
                if (key.Key == ConsoleKey.F3)
                {
                    Read(id);
                }
                if (key.Key == ConsoleKey.F9)
                {
                    Poisk(id);
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    Console.Clear();
                    break;
                }
            }
        }
        public void Create(int id)
        {
            Console.Clear();
            Tekst(id);
            List<Sklad> rab = Deser_and_Seril.DeCer<List<Sklad>>("Склад.json");

            Console.SetCursorPosition(0, 2);
            Console.WriteLine("                                                                               ");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("  ID: ");
            Console.WriteLine("  Название: ");
            Console.WriteLine("  Цена за 1 шт: ");
            Console.WriteLine("  Колличество на складе: ");
            Console.WriteLine("  Завершить.");
            int a = 0, b = 0, c = 0, d = 0;
            Sklad sotrudnik = new Sklad();

            while (true)
            {

                int k = str.Strel(2, 6);
                if (k == 0)
                {
                    break;
                }

                if (k == 2)
                {
                    Console.SetCursorPosition(92, 11);
                    Console.WriteLine("                               ");
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("  ID:              ");
                    Console.SetCursorPosition(6, 2);
                    int r = 0;
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(0, 2);
                            Console.WriteLine("  ID:              ");
                            Console.SetCursorPosition(6, 2);
                            sotrudnik.ID = Convert.ToInt32(Console.ReadLine());
                            r++;
                        }
                        catch
                        {
                            Console.SetCursorPosition(92, 11);
                            Console.WriteLine("Вводите только цифры!");
                            r = 0;
                        }
                        if (r != 0)
                        {
                            break;
                        }
                    }
                    d++;
                    rab = Deser_and_Seril.DeCer<List<Sklad>>("Склад.json");

                    foreach (var pleer in rab)
                    {
                        if (pleer.ID == sotrudnik.ID)
                        {
                            Console.SetCursorPosition(92, 11);
                            Console.WriteLine("Такой ID уже существует!");
                            d--;
                        }
                    }
                }
                if (k == 3)
                {
                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("  Название:                 ");
                    Console.SetCursorPosition(12, 3);
                    sotrudnik.Name = Console.ReadLine();
                    a++;
                }
                if (k == 4)
                {
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine("  Цена за 1 шт:                 ");
                    Console.SetCursorPosition(15, 4);
                    sotrudnik.Sena = Convert.ToInt32(Console.ReadLine());
                    b++;
                }
                if (k == 5)
                {
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("  Колличество на складе:                 ");
                    Console.SetCursorPosition(25, 5);
                    sotrudnik.Koli = Convert.ToInt32(Console.ReadLine());
                    c++;

                }
                if (k == 6)
                {
                    if (a > 0 && b > 0 && c > 0 && d > 0)
                    {

                        rab = Deser_and_Seril.DeCer<List<Sklad>>("Склад.json");
                        rab.Add(sotrudnik);
                        List<Sklad> pler = rab.OrderByDescending(x => x.ID).Reverse().ToList();
                        Deser_and_Seril.Cerialaz(pler, "Склад.json");

                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(0, 7);
                        Console.WriteLine("Вы заполнили не все поля.");
                    }
                }

            }
        }
        public void Delet(int id)
        {
            List<Sklad> rab = Deser_and_Seril.DeCer<List<Sklad>>("Склад.json");
            int z = 3 + rab.Count;
            int d = str.Strel(3, z);
            rab.RemoveAt(d - 3);
            Deser_and_Seril.Cerialaz(rab, "Склад.json");
        }

        public void Read(int id)
        {
            List<Sklad> rab = Deser_and_Seril.DeCer<List<Sklad>>("Склад.json");
            int z = 2 + rab.Count;

            while (true)
            {
                int b = 3;
                int d = str.Strel(3, z);
                if (d == 0)
                {
                    break;
                }
                while (true)
                {
                    Console.Clear();
                    Tekst(id);
                    Console.SetCursorPosition(94, 10);
                    Console.WriteLine("F4 - изменить данные");
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("                                                                               ");
                    Console.SetCursorPosition(0, 2);
                    Console.Write("  ID: ");
                    Console.WriteLine(rab[d - 3].ID);
                    Console.Write("  Название: ");
                    Console.WriteLine(rab[d - 3].Name);
                    Console.Write("  Цена за 1 шт: ");
                    Console.WriteLine(rab[d - 3].Sena);
                    Console.Write("  Колличество на складе: ");
                    Console.WriteLine(rab[d - 3].Koli);
                    Console.WriteLine("  Завершить.");

                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                    if (key.Key == ConsoleKey.F4)
                    {
                        d = d - 3;
                        Update(d, id);
                        break;
                    }
                }

                rab = Deser_and_Seril.DeCer<List<Sklad>>("Склад.json");
                Console.Clear();
                Tekst(id);
                int lo = rab.Count;
                int so = 0;
                b = 3;
                while (lo != 0)
                {
                    Console.SetCursorPosition(2, b);
                    Console.WriteLine(rab[so].ID);
                    Console.SetCursorPosition(10, b);
                    Console.WriteLine(rab[so].Name);
                    Console.SetCursorPosition(40, b);
                    Console.WriteLine(rab[so].Sena);
                    Console.SetCursorPosition(50, b);
                    Console.WriteLine(rab[so].Koli);
                    Console.SetCursorPosition(65, b);
                    if (rab[so].Koli > 10)
                    {
                        Console.WriteLine("o");
                    }
                    else if (rab[so].Koli > 3)
                    {
                        Console.WriteLine("!");
                    }
                    else
                    {
                        Console.WriteLine("Х");
                    }
                    so++;
                    lo--;
                    b++;
                }
            }
        }

        public void Update(int s, int id)
        {
            List<Sklad> rab = Deser_and_Seril.DeCer<List<Sklad>>("Склад.json");
            Sklad rabik = new Sklad();
            int z = 3 + rab.Count;
            Console.Clear();
            Tekst(id);
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("                                                                               ");
            Console.SetCursorPosition(0, 2);
            Console.Write("  ID: ");
            Console.WriteLine(rab[s].ID);
            rabik.ID = rab[s].ID;
            Console.Write("  Название: ");
            Console.WriteLine(rab[s].Name);
            rabik.Name = rab[s].Name;
            Console.Write("  Цена за 1 шт: ");
            Console.WriteLine(rab[s].Sena);
            rabik.Sena = rab[s].Sena;
            Console.Write("  Колличество на складе: ");
            Console.WriteLine(rab[s].Koli);
            rabik.Koli = rab[s].Koli;
            Console.WriteLine("  Вернуться.");
            int f = 0;
            while (true)
            {
                int k = str.Strel(2, 6);
                if (k == 2)
                {
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("  ID:              ");
                    Console.SetCursorPosition(6, 2);
                    int idik = rabik.ID; int r = 0;
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(0, 2);
                            Console.WriteLine("  ID:              ");
                            Console.SetCursorPosition(6, 2);
                            rabik.ID = Convert.ToInt32(Console.ReadLine());
                            r++;
                        }
                        catch
                        {
                            Console.SetCursorPosition(92, 11);
                            Console.WriteLine("Вводите только цифры!");
                            r = 0;
                        }
                        if (r != 0)
                        {
                            Console.SetCursorPosition(92, 11);
                            Console.WriteLine("                       ");
                            break;
                        }
                    }

                    rab = Deser_and_Seril.DeCer<List<Sklad>>("Склад.json");

                    foreach (var pleer in rab)
                    {
                        if (pleer.ID == rabik.ID)
                        {
                            f = 10;

                        }
                    }
                    if (f == 10)
                    {
                        Console.SetCursorPosition(92, 11);
                        Console.WriteLine("Такой ID уже существует!");
                        Console.SetCursorPosition(94, 12);
                        Console.WriteLine("Ваш ID не изменён.");
                        rabik.ID = idik;
                        Console.SetCursorPosition(6, 2);
                        Console.WriteLine(rabik.ID);
                        f = 0;
                    }

                }
                if (k == 3)
                {
                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("  Название:                 ");
                    Console.SetCursorPosition(12, 3);
                    rabik.Name = Console.ReadLine();
                }
                if (k == 4)
                {
                    int r = 0;
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(0, 4);
                            Console.WriteLine("  Цена за 1 шт:              ");
                            Console.SetCursorPosition(16, 4);
                            rabik.Sena = Convert.ToInt32(Console.ReadLine());
                            r++;
                        }
                        catch
                        {
                            Console.SetCursorPosition(92, 11);
                            Console.WriteLine("Вводите только цифры!");
                            r = 0;
                        }
                        if (r != 0)
                        {
                            Console.SetCursorPosition(92, 11);
                            Console.WriteLine("                       ");
                            break;
                        }
                    }
                }
                if (k == 5)
                {
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("  Колличество на складе:                 ");
                    Console.SetCursorPosition(13, 5);
                    int r = 0;
                    while (true)
                    {
                        try
                        {
                            Console.SetCursorPosition(0, 5);
                            Console.WriteLine("  Колличество на складе:              ");
                            Console.SetCursorPosition(25, 5);
                            rabik.Koli = Convert.ToInt32(Console.ReadLine());
                            r++;
                        }
                        catch
                        {
                            Console.SetCursorPosition(92, 11);
                            Console.WriteLine("Вводите только цифры!");
                            r = 0;
                        }
                        if (r != 0)
                        {
                            Console.SetCursorPosition(92, 11);
                            Console.WriteLine("                       ");
                            break;
                        }
                    }
                }
                if (k == 6)
                {
                    rab = Deser_and_Seril.DeCer<List<Sklad>>("Склад.json");
                    rab.RemoveAt(s);
                    rab.Add(rabik);
                    List<Sklad> pler = rab.OrderByDescending(x => x.ID).Reverse().ToList();
                    Deser_and_Seril.Cerialaz(pler, "Склад.json");

                    break;

                }
            }
        }
        public void Poisk(int id)
        {
            List<Sklad> rab = Deser_and_Seril.DeCer<List<Sklad>>("Склад.json");
            Console.Clear();
            Tekst(id);
            while (true)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("                                                                               ");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("  ID: ");
                Console.WriteLine("  Название: ");
                Console.WriteLine("  Цена за 1 шт: ");
                Console.WriteLine("  Колличество на складе: ");
                Console.WriteLine("  Вернуться.");
                int b = str.Strel(2, 6);
                if (b == 0 || b == 6)
                {
                    break;
                }

                if (b == 2)
                {
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("  ID: ");
                    Console.WriteLine("                  \n                             \n                                 \n                                   ");
                    Console.SetCursorPosition(6, 2);
                    int idi = Convert.ToInt32(Console.ReadLine());
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("                                                                    ");
                    int n = 0;
                    int d = 3;
                    Console.SetCursorPosition(2, 2);
                    Console.WriteLine("ID");
                    Console.SetCursorPosition(10, 2);
                    Console.WriteLine("Название товара");
                    Console.SetCursorPosition(40, 2);
                    Console.WriteLine("Цена");
                    Console.SetCursorPosition(50, 2);
                    Console.WriteLine("Колличество");
                    Console.SetCursorPosition(65, 2);
                    Console.WriteLine("Внимание");
                    foreach (var pleer in rab)
                    {
                        if (pleer.ID == idi)
                        {
                            Console.SetCursorPosition(2, d);
                            Console.WriteLine(pleer.ID);
                            Console.SetCursorPosition(10, d);
                            Console.WriteLine(pleer.Name);
                            Console.SetCursorPosition(40, d);
                            Console.WriteLine(pleer.Sena);
                            Console.SetCursorPosition(50, d);
                            Console.WriteLine(pleer.Koli);
                            Console.SetCursorPosition(65, d);
                            if (pleer.Koli > 10)
                            {
                                Console.WriteLine("o");
                            }
                            else if (pleer.Koli > 3)
                            {
                                Console.WriteLine("!");
                            }
                            else
                            {
                                Console.WriteLine("Х");
                            }
                            d++;
                            n++;
                        }

                    }
                    if (n == 0)
                    {
                        Console.SetCursorPosition(6, b);
                        Console.WriteLine("Нет таких элементов =(");
                    }
                }
                if (b == 3)
                {
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("  Название: ");
                    Console.WriteLine("                  \n                             \n                                 \n                                   ");
                    Console.SetCursorPosition(12, 2);
                    string prov = Console.ReadLine();
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("                                                                    ");
                    int n = 0;
                    int d = 3;
                    Console.SetCursorPosition(2, 2);
                    Console.WriteLine("ID");
                    Console.SetCursorPosition(10, 2);
                    Console.WriteLine("Название товара");
                    Console.SetCursorPosition(40, 2);
                    Console.WriteLine("Цена");
                    Console.SetCursorPosition(50, 2);
                    Console.WriteLine("Колличество");
                    Console.SetCursorPosition(65, 2);
                    Console.WriteLine("Внимание");
                    foreach (var pleer in rab)
                    {
                        if (pleer.Name == prov)
                        {
                            Console.SetCursorPosition(2, d);
                            Console.WriteLine(pleer.ID);
                            Console.SetCursorPosition(10, d);
                            Console.WriteLine(pleer.Name);
                            Console.SetCursorPosition(40, d);
                            Console.WriteLine(pleer.Sena);
                            Console.SetCursorPosition(50, d);
                            Console.WriteLine(pleer.Koli);
                            Console.SetCursorPosition(65, d);
                            if (pleer.Koli > 10)
                            {
                                Console.WriteLine("o");
                            }
                            else if (pleer.Koli > 3)
                            {
                                Console.WriteLine("!");
                            }
                            else
                            {
                                Console.WriteLine("Х");
                            }
                            d++;
                            n++;
                        }

                    }
                    if (n == 0)
                    {
                        Console.SetCursorPosition(6, b);
                        Console.WriteLine("Нет таких элементов =(");
                    }
                }
                if (b == 4)
                {
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("  Цена: ");
                    Console.WriteLine("                  \n                             \n                                 \n                                   ");
                    Console.SetCursorPosition(10, 2);
                    int prov = Convert.ToInt32(Console.ReadLine());
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("                                                                    ");
                    int n = 0;
                    Console.SetCursorPosition(2, 2);
                    Console.WriteLine("ID");
                    Console.SetCursorPosition(10, 2);
                    Console.WriteLine("Название товара");
                    Console.SetCursorPosition(40, 2);
                    Console.WriteLine("Цена");
                    Console.SetCursorPosition(50, 2);
                    Console.WriteLine("Колличество");
                    Console.SetCursorPosition(65, 2);
                    Console.WriteLine("Внимание");
                    int d = 3;
                    foreach (var pleer in rab)
                    {
                        if (pleer.Sena == prov)
                        {
                            Console.SetCursorPosition(2, d);
                            Console.WriteLine(pleer.ID);
                            Console.SetCursorPosition(10, d);
                            Console.WriteLine(pleer.Name);
                            Console.SetCursorPosition(40, d);
                            Console.WriteLine(pleer.Sena);
                            Console.SetCursorPosition(50, d);
                            Console.WriteLine(pleer.Koli);
                            Console.SetCursorPosition(65, d);
                            if (pleer.Koli > 10)
                            {
                                Console.WriteLine("o");
                            }
                            else if (pleer.Koli > 3)
                            {
                                Console.WriteLine("!");
                            }
                            else
                            {
                                Console.WriteLine("Х");
                            }
                            d++;
                            n++;
                        }

                    }
                    if (n == 0)
                    {
                        Console.SetCursorPosition(6, b);
                        Console.WriteLine("Нет таких элементов =(");
                    }
                }
                if (b == 5)
                {
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("  Колличество на складе: ");
                    Console.WriteLine("                  \n                             \n                                 \n                                   ");
                    Console.SetCursorPosition(25, 2);
                    int prov = Convert.ToInt32(Console.ReadLine());
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("                                                                    ");
                    int n = 0;
                    Console.SetCursorPosition(2, 2);
                    Console.WriteLine("ID");
                    Console.SetCursorPosition(10, 2);
                    Console.WriteLine("Название товара");
                    Console.SetCursorPosition(40, 2);
                    Console.WriteLine("Цена");
                    Console.SetCursorPosition(50, 2);
                    Console.WriteLine("Колличество");
                    Console.SetCursorPosition(65, 2);
                    Console.WriteLine("Внимание");
                    int d = 3;
                    foreach (var pleer in rab)
                    {
                        if (pleer.Koli == prov)
                        {
                            Console.SetCursorPosition(2, d);
                            Console.WriteLine(pleer.ID);
                            Console.SetCursorPosition(10, d);
                            Console.WriteLine(pleer.Name);
                            Console.SetCursorPosition(40, d);
                            Console.WriteLine(pleer.Sena);
                            Console.SetCursorPosition(50, d);
                            Console.WriteLine(pleer.Koli);
                            Console.SetCursorPosition(65, d);
                            if (pleer.Koli > 10)
                            {
                                Console.WriteLine("o");
                            }
                            else if (pleer.Koli > 3)
                            {
                                Console.WriteLine("!");
                            }
                            else
                            {
                                Console.WriteLine("Х");
                            }
                            d++;
                            n++;
                        }

                    }
                    if (n == 0)
                    {
                        Console.SetCursorPosition(6, b);
                        Console.WriteLine("Нет таких элементов =(");
                    }

                }
                Console.ReadKey(true);
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("                                                                          \n                                                                            \n                                                                            \n                                                                            \n                                                                            \n                                                                            \n                                                                            ");
            }
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
                if (pleer.Work == "Mskld" && pleer.Name != null && pleer.ID == id)
                {
                    Console.SetCursorPosition(50, 0);
                    Console.WriteLine("----- " + pleer.Name + " -----");
                    d++;
                }
            }
            if (d == 0)
            {
                Console.SetCursorPosition(50, 0);
                Console.WriteLine("----Кладовщик------");
            }

            while (b != 29)
            {
                Console.SetCursorPosition(85, b);
                Console.WriteLine("||");
                b++;
            }
            Console.SetCursorPosition(93, 7);
            Console.WriteLine("F1 - новый товар");
            Console.SetCursorPosition(91, 8);
            Console.WriteLine("F2 - удалить товар");
            Console.SetCursorPosition(92, 9);
            Console.WriteLine("F3 - посмотреть товар");
            Console.SetCursorPosition(94, 10);
            Console.WriteLine("F9 - поиск товара");

            Console.SetCursorPosition(2, 2);
            Console.WriteLine("ID");
            Console.SetCursorPosition(10, 2);
            Console.WriteLine("Название товара");
            Console.SetCursorPosition(40, 2);
            Console.WriteLine("Цена");
            Console.SetCursorPosition(50, 2);
            Console.WriteLine("Колличество");
            Console.SetCursorPosition(65, 2);
            Console.WriteLine("Внимание");
        }
    }
}
