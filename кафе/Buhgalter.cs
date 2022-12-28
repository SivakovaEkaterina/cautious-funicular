using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace кафе
{
    internal class Buhgalter : ICRUD
    {
        public Strelka str = new Strelka();
        public ConsoleKeyInfo key;
        public void Privetstvie(int id)
        {
            while (true)
            {
                string put = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string file = put + "\\Кафешка" + "\\Бухгалтерский учёт.json";
                if (!File.Exists(file))
                {
                    Dengi pust = new Dengi();
                    List<Dengi> mani = new List<Dengi>();
                    pust.ID = 0;
                    pust.Name = "";
                    pust.SumDen = 10;
                    pust.Date = "";
                    pust.PluMin = 0;
                    mani.Add(pust);
                    File.Create(put + "\\Кафешка\\Бухгалтерский учёт.json").Close();
                    Deser_and_Seril.Cerialaz(mani, "\\Бухгалтерский учёт.json");
                }
                Tekst(id);
                List<Dengi> dengi = Deser_and_Seril.DeCer<List<Dengi>>("Бухгалтерский учёт.json");

                int b = 3;
                foreach (var pleer in dengi)
                {
                    Console.SetCursorPosition(2, b);
                    Console.WriteLine(pleer.ID);
                    Console.SetCursorPosition(10, b);
                    Console.WriteLine(pleer.Name);
                    Console.SetCursorPosition(30, b);
                    Console.WriteLine(pleer.SumDen);
                    Console.SetCursorPosition(50, b);
                    Console.WriteLine(pleer.Date);
                    Console.SetCursorPosition(65, b);
                    if (pleer.PluMin == 0)
                    {
                        Console.WriteLine("-");
                    }
                    else if (pleer.PluMin == 1)
                    {
                        Console.WriteLine("+");
                    }
                    else
                    {
                        Console.WriteLine("?");
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
            List<Dengi> rab = Deser_and_Seril.DeCer<List<Dengi>>("Бухгалтерский учёт.json");

            Console.SetCursorPosition(0, 2);
            Console.WriteLine("                                                                               ");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("  ID: ");
            Console.WriteLine("  Название: ");
            Console.WriteLine("  Сумма изменения: ");
            Console.WriteLine("  Дата оформления: ");
            Console.WriteLine("  Завершить.");
            int a = 0, b = 0, c = 0, d = 0;
            Dengi sotrudnik = new Dengi();
            sotrudnik.ID = rab.Count + 1;
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("  ID: "+ sotrudnik.ID);
            d++;
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
                    Console.SetCursorPosition(10, 2);
                    Console.WriteLine("Вы уверены что хотите изменить данный пункт? ");
                    Console.SetCursorPosition(10, 3);
                    Console.WriteLine("Это может сломать программу. Да -1, нет - 0:");
                    key = Console.ReadKey(true);
                    int prov = Convert.ToInt16(key.KeyChar.ToString());
                    if (prov == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(10, 2);
                        Console.WriteLine("                                             ");
                        Console.SetCursorPosition(10, 3);
                        Console.WriteLine("                                             ");

                        Console.SetCursorPosition(0, 2);
                        Console.WriteLine("  ID:");

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
                        rab = Deser_and_Seril.DeCer<List<Dengi>>("Бухгалтерский учёт.json");

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
                }
                if (k == 3)
                {
                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("  Название операции:                 ");
                    Console.SetCursorPosition(12, 3);
                    sotrudnik.Name = Console.ReadLine();
                    a++;
                }
                if (k == 4)
                {
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine("  Сумма изменения:                 ");
                    Console.SetCursorPosition(15, 4);
                    sotrudnik.SumDen = Convert.ToInt32(Console.ReadLine());
                    if (sotrudnik.SumDen > 0)
                    {
                        sotrudnik.PluMin = 1;
                    }
                    else
                    {
                        sotrudnik.PluMin = 0;
                    }
                    b++;
                }
                if (k == 5)
                {
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("  Дата оформления:                 ");
                    Console.SetCursorPosition(25, 5);
                    sotrudnik.Date = Console.ReadLine();
                    c++;

                }
                if (k == 6)
                {
                    if (a > 0 && b > 0 && c > 0 && d > 0)
                    {

                        rab = Deser_and_Seril.DeCer<List<Dengi>>("Бухгалтерский учёт.json");
                        rab.Add(sotrudnik);
                        List<Dengi> pler = rab.OrderByDescending(x => x.ID).Reverse().ToList();
                        Deser_and_Seril.Cerialaz(pler, "Бухгалтерский учёт.json");

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
            List<Dengi> rab = Deser_and_Seril.DeCer<List<Dengi>>("Бухгалтерский учёт.json");
            int z = 3 + rab.Count;
            int d = str.Strel(3, z);
            rab.RemoveAt(d - 3);
            Deser_and_Seril.Cerialaz(rab, "Бухгалтерский учёт.json");
        }

        public void Poisk(int id)
        {
        }

        public void Read(int id)
        {
            List<Dengi> rab = Deser_and_Seril.DeCer<List<Dengi>>("Бухгалтерский учёт.json");
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
                    Console.WriteLine(rab[d - 3].SumDen);
                    Console.Write("  Колличество на складе: ");
                    Console.WriteLine(rab[d - 3].Date);
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

                rab = Deser_and_Seril.DeCer<List<Dengi>>("Бухгалтерский учёт.json");
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
                    Console.SetCursorPosition(30, b);
                    Console.WriteLine(rab[so].SumDen);
                    Console.SetCursorPosition(50, b);
                    Console.WriteLine(rab[so].Date);
                    Console.SetCursorPosition(65, b);
                    if (rab[so].PluMin == 0)
                    {
                        Console.WriteLine("-");
                    }
                    else if (rab[so].PluMin == 1)
                    {
                        Console.WriteLine("+");
                    }
                    else
                    {
                        Console.WriteLine("?");
                    }
                    so++;
                    lo--;
                    b++;
                }
            }
        }

        public void Update(int s, int id)
        {
            List<Dengi> rab = Deser_and_Seril.DeCer<List<Dengi>>("Бухгалтерский учёт.json");
            Dengi rabik = new Dengi();
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
            Console.WriteLine(rab[s].SumDen);
            rabik.SumDen = rab[s].SumDen;
            Console.Write("  Колличество на складе: ");
            Console.WriteLine(rab[s].Date);
            rabik.Date = rab[s].Date;
            Console.WriteLine("  Вернуться.");
            int f = 0;
            while (true)
            {
                int k = str.Strel(2, 6);
                if (k == 2)
                {
                    int provik = rabik.ID;
                    Console.SetCursorPosition(92, 11);
                    Console.WriteLine("                               ");
                    Console.SetCursorPosition(10, 2);
                    Console.WriteLine("Вы уверены что хотите изменить данный пункт? ");
                    Console.SetCursorPosition(10, 3);
                    Console.WriteLine("Это может сломать программу. Да -1, нет - 0:");
                    key = Console.ReadKey(true);
                    int prov = Convert.ToInt16(key.KeyChar.ToString());
                    if (prov == 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.SetCursorPosition(10, 2);
                        Console.WriteLine("                                             ");
                        Console.SetCursorPosition(10, 3);
                        Console.WriteLine("                                             ");

                        Console.SetCursorPosition(0, 2);
                        Console.WriteLine("  ID:");

                        Console.SetCursorPosition(6, 2);
                        int r = 0;
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
                                break;
                            }
                        }
                        
                        rab = Deser_and_Seril.DeCer<List<Dengi>>("Бухгалтерский учёт.json");

                        foreach (var pleer in rab)
                        {
                            if (pleer.ID == rabik.ID)
                            {
                                Console.SetCursorPosition(92, 11);
                                Console.WriteLine("Такой ID уже существует!");
                                rabik.ID = provik;
                            }
                        }
                    }
                }
                if (k == 3)
                {
                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("  Название операции:                 ");
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
                            Console.WriteLine("  Сумма изменения:              ");
                            Console.SetCursorPosition(16, 4);
                            rabik.SumDen = Convert.ToInt32(Console.ReadLine());
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
                    Console.WriteLine("  Дата операции:              ");
                    Console.SetCursorPosition(25, 5);
                    rabik.Date = Console.ReadLine();
                         
                }
                if (k == 6)
                {
                    rab = Deser_and_Seril.DeCer<List<Dengi>>("Бухгалтерский учёт.json");
                    rab.RemoveAt(s);
                    rab.Add(rabik);
                    List<Dengi> pler = rab.OrderByDescending(x => x.ID).Reverse().ToList();
                    Deser_and_Seril.Cerialaz(pler, "Бухгалтерский учёт.json");

                    break;

                }
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
                if (pleer.Work == "Bhglt" && pleer.Name != null && pleer.ID == id)
                {
                    Console.SetCursorPosition(50, 0);
                    Console.WriteLine("----- " + pleer.Name + " -----");
                    d++;
                }
            }
            if (d == 0)
            {
                Console.SetCursorPosition(50, 0);
                Console.WriteLine("----Бухгалтер------");
            }

            while (b != 29)
            {
                Console.SetCursorPosition(85, b);
                Console.WriteLine("||");
                b++;
            }
            Console.SetCursorPosition(93, 7);
            Console.WriteLine("F1 - новый пункт");
            Console.SetCursorPosition(91, 8);
            Console.WriteLine("F2 - удалить пункт");
            Console.SetCursorPosition(92, 9);
            Console.WriteLine("F3 - посмотреть пункт");
            Console.SetCursorPosition(94, 10);
            Console.WriteLine("F9 - поиск товара (не работает)");

            Console.SetCursorPosition(2, 2);
            Console.WriteLine("ID");
            Console.SetCursorPosition(10, 2);
            Console.WriteLine("Название операции");
            Console.SetCursorPosition(30, 2);
            Console.WriteLine("Сумма операции");
            Console.SetCursorPosition(50, 2);
            Console.WriteLine("Дата операции");
            Console.SetCursorPosition(65, 2);
            Console.WriteLine("Прибавление");
        }
    }
}
