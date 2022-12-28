using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace кафе
{
    internal class Mened_Person: ICRUD
    {
        public Deser_and_Seril deser_And_Seril = new Deser_and_Seril();
        public Strelka str = new Strelka();
        public ConsoleKeyInfo key;
        public void Privetstvie(int id)
        {
            while (true)
            {
                Tekst(id);
                List<Sotrudniki> rab = Deser_and_Seril.DeCer<List<Sotrudniki>>("Данные сотрудников.json");
                List<InfSotrud> irab = Deser_and_Seril.DeCer<List<InfSotrud>>("Личные данные сотрудников.json");

                int b = 3;
                foreach (var pleer in irab)
                {
                    Console.SetCursorPosition(2, b);
                    Console.WriteLine(pleer.ID);
                    Console.SetCursorPosition(6, b);
                    Console.WriteLine(pleer.Ima);
                    Console.SetCursorPosition(20, b);
                    Console.WriteLine(pleer.Famil);
                    Console.SetCursorPosition(35, b);
                    Console.WriteLine(pleer.Otchestv);
                    Console.SetCursorPosition(50, b);
                    Console.WriteLine(pleer.Dolgn);
                    Console.SetCursorPosition(65, b);
                    if (pleer.IDs != -1)
                    {
                        Console.WriteLine(pleer.IDs);
                    }
                    else { Console.WriteLine("-"); }
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
            List<Sotrudniki> rab = Deser_and_Seril.DeCer<List<Sotrudniki>>("Данные сотрудников.json");
            List<InfSotrud> irab = Deser_and_Seril.DeCer<List<InfSotrud>>("Личные данные сотрудников.json");

            Console.SetCursorPosition(0, 2);
            Console.WriteLine("                                                                               ");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("  ID: ");
            Console.WriteLine("  Имя: ");
            Console.WriteLine("  Фамилия: ");
            Console.WriteLine("  Отчество: ");
            Console.WriteLine("  Телефон: ");
            Console.WriteLine("  Паспорт: ");
            Console.WriteLine("  День рождения: ");
            Console.WriteLine("  Должность: ");
            Console.WriteLine("  Зарплата: ");
            Console.WriteLine("  Привязан к ID: ");
            Console.WriteLine("  Завершить.");
            InfSotrud sotrudnik = new InfSotrud();
            Sotrudniki sotid = new Sotrudniki();
            int n = 0;
            int tt = -1;
            int d = 0;
            sotrudnik.IDs = -1;
            while (true)
            {
                
                int k = str.Strel(2, 12);
                if (k == 0)
                {
                    break;
                }
                {
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
                        irab = Deser_and_Seril.DeCer<List<InfSotrud>>("Личные данные сотрудников.json");

                        foreach (var pleer in irab)
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
                        Console.WriteLine("  Имя:                 ");
                        Console.SetCursorPosition(8, 3);
                        sotrudnik.Ima = Console.ReadLine();
                    }
                    if (k == 4)
                    {
                        Console.SetCursorPosition(0, 4);
                        Console.WriteLine("  Фамилия:                 ");
                        Console.SetCursorPosition(11, 4);
                        sotrudnik.Famil = Console.ReadLine();

                    }
                    if (k == 5)
                    {
                        Console.SetCursorPosition(0, 5);
                        Console.WriteLine("  Отчество:                 ");
                        Console.SetCursorPosition(12, 5);
                        sotrudnik.Otchestv = Console.ReadLine();

                    }
                    if (k == 6)
                    {
                        try
                        {
                            Console.SetCursorPosition(0, 6);
                            Console.WriteLine("  Телефон: +                ");
                            Console.SetCursorPosition(12, 6);
                            sotrudnik.Telf = Convert.ToInt64(Console.ReadLine());
                        }
                        catch
                        {
                            Console.SetCursorPosition(11, 6);
                            sotrudnik.Telf = 0;
                            Console.WriteLine("+00000000000");
                        }
                        
                    }
                    if (k == 7)
                    {
                        try
                        {
                            Console.SetCursorPosition(0, 7);
                            Console.WriteLine("  Паспорт:                 ");
                            Console.SetCursorPosition(11, 7);
                            sotrudnik.Pasport = Convert.ToInt64(Console.ReadLine());
                        }
                        catch
                        {
                            Console.SetCursorPosition(11, 7);
                            sotrudnik.Pasport = 0;
                            Console.WriteLine("0000000000");

                        }


                    }
                    if (k == 8)
                    {
                        Console.SetCursorPosition(0, 8);
                        Console.WriteLine("  День рождения:                                      ");
                        Console.SetCursorPosition(16, 8);
                        sotrudnik.DenRog = Console.ReadLine();

                    }
                    if (k == 9)
                    {
                        Console.SetCursorPosition(0, 9);
                        Console.WriteLine("  Должность:                                           ");
                        Console.SetCursorPosition(12, 9);
                        sotrudnik.Dolgn = Console.ReadLine();

                    }
                    if (k == 10)
                    {
                        try
                        {
                            Console.SetCursorPosition(0, 10);
                            Console.WriteLine("  Зарплата:                       ");
                            Console.SetCursorPosition(11, 10);
                            sotrudnik.Zrpl = Convert.ToDouble(Console.ReadLine());
                        }
                        catch
                        {
                            sotrudnik.Zrpl = 0;
                        }

                    }
                    if (k == 11)
                    {
                        Console.SetCursorPosition(0, 11);
                        Console.WriteLine("  ID сотрудника:              ");
                        Console.SetCursorPosition(17, 11);
                        sotrudnik.IDs = Convert.ToInt32(Console.ReadLine());
                        int t = -1;

                        foreach (var pleer in rab)
                        {
                            t++;
                            if (pleer.ID == sotrudnik.IDs)
                            {
                                if (pleer.Name == null)
                                {
                                    n = 10;
                                    tt = t;
                                    Console.SetCursorPosition(20, 2);
                                    Console.WriteLine("                        ");
                                }
                                else
                                {
                                    n = 5;
                                }
                            }
                        }
                        if (n == 0)
                        {
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("Нет такого сотрудника");
                            sotrudnik.IDs = -1;
                        }
                        if (n == 5)
                        {
                            Console.SetCursorPosition(20, 2);
                            Console.WriteLine("Такой участник уже есть");
                            sotrudnik.IDs = -1;
                        }
                    }
                }
                if (k == 12)
                {
                    if (d == 0)
                    {
                        Console.WriteLine("Поле ID обязательно к заполнению!");
                    }
                    else
                    {
                        rab = Deser_and_Seril.DeCer<List<Sotrudniki>>("Данные сотрудников.json");
                        irab = Deser_and_Seril.DeCer<List<InfSotrud>>("Личные данные сотрудников.json");
                        if (n == 10)
                        {
                            rab[tt].Name = sotrudnik.Ima + " " + sotrudnik.Famil;
                            Deser_and_Seril.Cerialaz(rab, "Данные сотрудников.json");
                        }
                        irab.Add(sotrudnik);
                        List<InfSotrud> pler = irab.OrderByDescending(x => x.ID).Reverse().ToList();
                        Deser_and_Seril.Cerialaz(pler, "Личные данные сотрудников.json");

                        break;
                    }
                    
                }

            }
        }
        public void Delet(int id)
        {
            List<InfSotrud> irab = Deser_and_Seril.DeCer<List<InfSotrud>>("Личные данные сотрудников.json");
            List<Sotrudniki> rab = Deser_and_Seril.DeCer<List<Sotrudniki>>("Данные сотрудников.json");
            int z = 3 + irab.Count;
            int d = str.Strel(3, z);
            int ss = -1;
            int gg = -1;
            foreach (var pleer in rab)
            {
                ss++;
                if (pleer.ID == irab[d - 3].IDs)
                {
                    gg = ss;
                    rab[gg].Name = null;
                }
            }
            if (gg >= 0)
            {
                Deser_and_Seril.Cerialaz(rab, "Данные сотрудников.json");
            }
            irab.RemoveAt(d - 3);
            Deser_and_Seril.Cerialaz(irab, "Личные данные сотрудников.json");
        }
        public void Read(int id)
        {
            List<InfSotrud> rab = Deser_and_Seril.DeCer<List<InfSotrud>>("Личные данные сотрудников.json");
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
                    Console.Write("  Имя: ");
                    Console.WriteLine(rab[d - 3].Ima);
                    Console.Write("  Фамилия: ");
                    Console.WriteLine(rab[d - 3].Famil);
                    Console.Write("  Отчество: ");
                    Console.WriteLine(rab[d - 3].Otchestv);
                    Console.Write("  Телефон: +");
                    Console.WriteLine(rab[d - 3].Telf);
                    Console.Write("  Паспорт: ");
                    Console.WriteLine(rab[d - 3].Pasport);
                    Console.Write("  День рождения: ");
                    Console.WriteLine(rab[d - 3].DenRog);
                    Console.Write("  Должность: ");
                    Console.WriteLine(rab[d - 3].Dolgn);
                    Console.Write("  Зарплата: ");
                    Console.WriteLine(rab[d - 3].Zrpl);
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

                rab = Deser_and_Seril.DeCer<List<InfSotrud>>("Личные данные сотрудников.json");
                Console.Clear();
                Tekst(id);
                int lo = rab.Count;
                int so = 0;
                b = 3;
                while (lo != 0)
                {
                    Console.SetCursorPosition(2, 2);
                    Console.WriteLine("ID");
                    Console.SetCursorPosition(6, 2);
                    Console.WriteLine("Имя");
                    Console.SetCursorPosition(20, 2);
                    Console.WriteLine("Фамилия");
                    Console.SetCursorPosition(35, 2);
                    Console.WriteLine("Отчество");
                    Console.SetCursorPosition(50, 2);
                    Console.WriteLine("Должность");
                    Console.SetCursorPosition(65, 2);
                    Console.WriteLine("Привязан к ID");
                    Console.SetCursorPosition(2, b);
                    Console.WriteLine(rab[so].ID);
                    Console.SetCursorPosition(6, b);
                    Console.WriteLine(rab[so].Ima);
                    Console.SetCursorPosition(20, b);
                    Console.WriteLine(rab[so].Famil);
                    Console.SetCursorPosition(35, b);
                    Console.WriteLine(rab[so].Otchestv);
                    Console.SetCursorPosition(50, b);
                    Console.WriteLine(rab[so].Dolgn);
                    Console.SetCursorPosition(65, b);
                    if (rab[so].ID != -1)
                    {
                        Console.WriteLine(rab[so].IDs);
                    }
                    else { Console.WriteLine("-"); }
                    so++;
                    lo--;
                    b++;
                }
            }
        }
        public void Update(int s, int id)
        {
            List<Sotrudniki> rab = Deser_and_Seril.DeCer<List<Sotrudniki>>("Данные сотрудников.json");
            List<InfSotrud> irab = Deser_and_Seril.DeCer<List<InfSotrud>>("Личные данные сотрудников.json");

            InfSotrud rabik = new InfSotrud();
            int z = 3 + irab.Count;
            Console.Clear();
            Tekst(id);
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("                                                                                     ");
            Console.SetCursorPosition(0, 2);
            Console.Write("  ID: ");
            Console.WriteLine(irab[s].ID);
            rabik.ID = irab[s].ID;
            Console.Write("  Имя: ");
            Console.WriteLine(irab[s].Ima);
            rabik.Ima = irab[s].Ima;
            Console.Write("  Фамилия: ");
            Console.WriteLine(irab[s].Famil);
            rabik.Famil = irab[s].Famil;
            Console.Write("  Отчество: ");
            Console.WriteLine(irab[s].Otchestv);
            rabik.Otchestv = irab[s].Otchestv;
            Console.Write("  Телефон: +");
            Console.WriteLine(irab[s].Telf);
            rabik.Telf = irab[s].Telf;
            Console.Write("  Паспорт: ");
            Console.WriteLine(irab[s].Pasport);
            rabik.Pasport = irab[s].Pasport;
            Console.Write("  День Рождения: ");
            Console.WriteLine(irab[s].DenRog);
            rabik.DenRog = irab[s].DenRog;
            Console.Write("  Должность: ");
            Console.WriteLine(irab[s].Dolgn);
            rabik.Dolgn = irab[s].Dolgn;
            Console.Write("  Зарплата: ");
            Console.WriteLine(irab[s].Zrpl);
            rabik.Zrpl = irab[s].Zrpl;
            Console.Write("  ID сотрудники: ");
            Console.WriteLine(irab[s].IDs);
            rabik.IDs = irab[s].IDs;
            Console.WriteLine("  Вернуться.");
            int n = 0;
            int t = -1;
            int tt = -1;
            rab = Deser_and_Seril.DeCer<List<Sotrudniki>>("Данные сотрудников.json");

            foreach (var pleer in rab)
            {
                tt++;
                if (pleer.ID == irab[s].IDs)
                {
                    t = tt;
                    n = 10;
                }
            }
            while (true)
            {
                int k = str.Strel(2, 12);

                if (k == 2)
                {
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("  ID:              ");
                    Console.SetCursorPosition(6, 2);
                    int idik = rabik.ID;
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
                    irab = Deser_and_Seril.DeCer<List<InfSotrud>>("Личные данные сотрудников.json");

                    foreach (var pleer in irab)
                    {
                        if (pleer.ID == rabik.ID)
                        {
                            Console.SetCursorPosition(92, 11);
                            Console.WriteLine("Такой ID уже существует!");
                            n = 5;
                        }
                    }
                    if (n == 5)
                    {
                        Console.SetCursorPosition(20, 2);
                        Console.WriteLine("Такой участник уже есть");
                        rabik.ID = idik;
                    }
                }
                if (k == 3)
                {
                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("  Имя:                 ");
                    Console.SetCursorPosition(8, 3);
                    rabik.Ima = Console.ReadLine();
                }
                if (k == 4)
                {
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine("  Фамилия:                 ");
                    Console.SetCursorPosition(11, 4);
                    rabik.Famil = Console.ReadLine();

                }
                if (k == 5)
                {
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("  Отчество:                 ");
                    Console.SetCursorPosition(12, 5);
                    rabik.Otchestv = Console.ReadLine();

                }
                if (k == 6)
                {
                    /*System.FormatException*/
                    try
                    {
                        Console.SetCursorPosition(0, 6);
                        Console.WriteLine("  Телефон: +                ");
                        Console.SetCursorPosition(12, 6);
                        rabik.Telf = Convert.ToInt64(Console.ReadLine());
                    }
                    catch
                    {
                        Console.SetCursorPosition(11, 6);
                        rabik.Telf = 0;
                        Console.WriteLine("+00000000000");
                    }
                }
                if (k == 7)
                {
                    try
                    {
                        Console.SetCursorPosition(0, 7);
                        Console.WriteLine("  Паспорт:                 ");
                        Console.SetCursorPosition(11, 7);
                        rabik.Pasport = Convert.ToInt64(Console.ReadLine());
                    }
                    catch
                    {
                        Console.SetCursorPosition(11, 7);
                        rabik.Pasport = 0;
                        Console.WriteLine("0000000000");

                    }

                }
                if (k == 8)
                {
                    Console.SetCursorPosition(0, 8);
                    Console.WriteLine("  День рождения:                                      ");
                    Console.SetCursorPosition(16, 8);
                    rabik.DenRog = Console.ReadLine();

                }
                if (k == 9)
                {
                    Console.SetCursorPosition(0, 9);
                    Console.WriteLine("  Должность:                                           ");
                    Console.SetCursorPosition(12, 9);
                    rabik.Dolgn = Console.ReadLine();

                }
                if (k == 10)
                {
                    try
                    {
                        Console.SetCursorPosition(0, 10);
                        Console.WriteLine("  Зарплата:                       ");
                        Console.SetCursorPosition(11, 10);
                        rabik.Zrpl = Convert.ToDouble(Console.ReadLine());
                    }
                    catch
                    {
                        rabik.Zrpl = 0;
                    }
                }
                if (k == 11)
                {
                    Console.SetCursorPosition(0, 11);
                    Console.WriteLine("  ID сотрудника:              ");
                    Console.SetCursorPosition(10, 11);
                    rabik.IDs = Convert.ToInt32(Console.ReadLine());
                    t = -1;

                    foreach (var pleer in rab)
                    {
                        t++;
                        if (pleer.ID == rabik.IDs)
                        {
                            if (pleer.Name == null)
                            {
                                n = 10;
                                tt = t;
                                Console.SetCursorPosition(20, 11);
                                Console.WriteLine("                        ");

                            }
                            else
                            {
                                rab[tt].Name = null;
                                n = 10;
                                t = tt;
                            }
                        }
                    }
                    if (n == 0)
                    {
                        Console.SetCursorPosition(20, 11);
                        Console.WriteLine("Нет такого сотрудника");
                        rabik.IDs = -1;
                    }
                }
                if (k == 12)
                {
                    List<InfSotrud> rabs = Deser_and_Seril.DeCer<List<InfSotrud>>("Личные данные сотрудников.json");
                    if (n == 10)
                    {
                        rab[t].Name = rabik.Ima + " " + rabik.Famil;
                        Deser_and_Seril.Cerialaz(rab, "Данные сотрудников.json");
                    }
                    rabs.RemoveAt(s);
                    rabs.Add(rabik);
                    List<InfSotrud> plers = rabs.OrderByDescending(x => x.ID).Reverse().ToList();
                    Deser_and_Seril.Cerialaz(plers, "Личные данные сотрудников.json");
                    

                    break;

                }
            }
        }
        public void Poisk(int id)
        {
            List<InfSotrud> rab = Deser_and_Seril.DeCer<List<InfSotrud>>("Личные данные сотрудников.json");
            Console.Clear();
            Tekst(id);
            while (true)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("                                                                               ");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("  ID. ");
                Console.WriteLine("  Имя. ");
                Console.WriteLine("  Фамилия. ");
                Console.WriteLine("  Отчество. ");
                Console.WriteLine("  Должность. ");
                Console.WriteLine("  Вернуться.");
                int d = str.Strel(2, 6);
                if (d == 0 || d == 7)
                {
                    break;
                }

                if (d == 2)
                {
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("  ID: ");
                    Console.WriteLine("                  \n                  \n                  \n                  \n                  \n                  \n                  \n                  \n                  \n                  ");
                    Console.SetCursorPosition(6, 2);
                    int idi = Convert.ToInt32(Console.ReadLine());
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("                                                                    ");
                    int n = 0;
                    int b = 3;
                    Console.Clear();
                    Tekst(id);
                    foreach (var pleer in rab)
                    {
                        if (pleer.ID == idi)
                        {
                            Console.SetCursorPosition(2, b);
                            Console.WriteLine(pleer.ID);
                            Console.SetCursorPosition(6, b);
                            Console.WriteLine(pleer.Ima);
                            Console.SetCursorPosition(20, b);
                            Console.WriteLine(pleer.Famil);
                            Console.SetCursorPosition(35, b);
                            Console.WriteLine(pleer.Otchestv);
                            Console.SetCursorPosition(50, b);
                            Console.WriteLine(pleer.Dolgn);
                            Console.SetCursorPosition(65, b);
                            if (pleer.ID != -1)
                            {
                                Console.WriteLine(pleer.ID);
                            }
                            else { Console.WriteLine("-"); }
                            b++;
                            n++;
                        }

                    }
                    if (n == 0)
                    {
                        Console.SetCursorPosition(6, b);
                        Console.WriteLine("Нет таких элементов =(");
                    }
                }
                if (d == 3)
                {
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("  Имя: ");
                    Console.WriteLine("                  \n                  \n                  \n                  \n                  \n                  \n                  \n                  \n                  \n                  ");
                    Console.SetCursorPosition(6, 2);
                    string idi = Console.ReadLine();
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("                                                                    ");
                    int n = 0;
                    int b = 3;
                    Console.Clear();
                    Tekst(id);
                    foreach (var pleer in rab)
                    {
                        if (pleer.Ima == idi)
                        {
                            Console.SetCursorPosition(2, b);
                            Console.WriteLine(pleer.ID);
                            Console.SetCursorPosition(6, b);
                            Console.WriteLine(pleer.Ima);
                            Console.SetCursorPosition(20, b);
                            Console.WriteLine(pleer.Famil);
                            Console.SetCursorPosition(35, b);
                            Console.WriteLine(pleer.Otchestv);
                            Console.SetCursorPosition(50, b);
                            Console.WriteLine(pleer.Dolgn);
                            Console.SetCursorPosition(65, b);
                            if (pleer.ID != -1)
                            {
                                Console.WriteLine(pleer.ID);
                            }
                            else { Console.WriteLine("-"); }
                            b++;
                            n++;
                        }

                    }
                    if (n == 0)
                    {
                        Console.SetCursorPosition(6, b);
                        Console.WriteLine("Нет таких элементов =(");
                    }
                }
                if (d == 4)
                {
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("  Фамиля: ");
                    Console.WriteLine("                  \n                  \n                  \n                  \n                  \n                  \n                  \n                  \n                  \n                  ");
                    Console.SetCursorPosition(6, 2);
                    string idi = Console.ReadLine();
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("                                                                    ");
                    int n = 0;
                    int b = 3;
                    Console.Clear();
                    Tekst(id);
                    foreach (var pleer in rab)
                    {
                        if (pleer.Famil == idi)
                        {
                            Console.SetCursorPosition(2, b);
                            Console.WriteLine(pleer.ID);
                            Console.SetCursorPosition(6, b);
                            Console.WriteLine(pleer.Ima);
                            Console.SetCursorPosition(20, b);
                            Console.WriteLine(pleer.Famil);
                            Console.SetCursorPosition(35, b);
                            Console.WriteLine(pleer.Otchestv);
                            Console.SetCursorPosition(50, b);
                            Console.WriteLine(pleer.Dolgn);
                            Console.SetCursorPosition(65, b);
                            if (pleer.ID != -1)
                            {
                                Console.WriteLine(pleer.ID);
                            }
                            else { Console.WriteLine("-"); }
                            b++;
                            n++;
                        }

                    }
                    if (n == 0)
                    {
                        Console.SetCursorPosition(6, b);
                        Console.WriteLine("Нет таких элементов =(");
                    }
                }
                if (d == 5)
                {
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("  Отчество: ");
                    Console.WriteLine("                  \n                  \n                  \n                  \n                  \n                  \n                  \n                  \n                  \n                  ");
                    Console.SetCursorPosition(6, 2);
                    string idi = Console.ReadLine();
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("                                                                    ");
                    int n = 0;
                    int b = 3;
                    Console.Clear();
                    Tekst(id);
                    foreach (var pleer in rab)
                    {
                        if (pleer.Otchestv == idi)
                        {
                            Console.SetCursorPosition(2, b);
                            Console.WriteLine(pleer.ID);
                            Console.SetCursorPosition(6, b);
                            Console.WriteLine(pleer.Ima);
                            Console.SetCursorPosition(20, b);
                            Console.WriteLine(pleer.Famil);
                            Console.SetCursorPosition(35, b);
                            Console.WriteLine(pleer.Otchestv);
                            Console.SetCursorPosition(50, b);
                            Console.WriteLine(pleer.Dolgn);
                            Console.SetCursorPosition(65, b);
                            if (pleer.ID != -1)
                            {
                                Console.WriteLine(pleer.ID);
                            }
                            else { Console.WriteLine("-"); }
                            b++;
                            n++;
                        }

                    }
                    if (n == 0)
                    {
                        Console.SetCursorPosition(6, b);
                        Console.WriteLine("Нет таких элементов =(");
                    }
                }
                if (d == 6)
                {
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("  Должность: ");
                    Console.WriteLine("                  \n                  \n                  \n                  \n                  \n                  \n                  \n                  \n                  \n                  ");
                    Console.SetCursorPosition(6, 2);
                    string idi = Console.ReadLine();
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("                                                                    ");
                    int n = 0;
                    int b = 3;
                    Console.Clear();
                    Tekst(id);
                    foreach (var pleer in rab)
                    {
                        if (pleer.Dolgn == idi)
                        {
                            Console.SetCursorPosition(2, b);
                            Console.WriteLine(pleer.ID);
                            Console.SetCursorPosition(6, b);
                            Console.WriteLine(pleer.Ima);
                            Console.SetCursorPosition(20, b);
                            Console.WriteLine(pleer.Famil);
                            Console.SetCursorPosition(35, b);
                            Console.WriteLine(pleer.Otchestv);
                            Console.SetCursorPosition(50, b);
                            Console.WriteLine(pleer.Dolgn);
                            Console.SetCursorPosition(65, b);
                            if (pleer.ID != -1)
                            {
                                Console.WriteLine(pleer.ID);
                            }
                            else { Console.WriteLine("-"); }
                            b++;
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
                Console.WriteLine("                                                                           \n                                                                            \n                                                                            \n                                                                            \n                                                                            \n                                                                            \n                                                                            ");
            }
        }
        private void Tekst(int id)
        {
            Console.Clear();
            int b = 0;
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("========================================================================================================================");
            List<Sotrudniki> rab = Deser_and_Seril.DeCer<List<Sotrudniki>>("Данные сотрудников.json");
            List <InfSotrud> irab = Deser_and_Seril.DeCer<List<InfSotrud>>("Личные данные сотрудников.json");
            int d = 0;
            foreach (var pleer in rab)
            {
                if (pleer.Work == "MPers" && pleer.Name != null && pleer.ID == id)
                {
                    Console.SetCursorPosition(50, 0);
                    Console.WriteLine("----- " + pleer.Name + " -----");
                    d++;
                }
            }
            if (d == 0)
            {
                Console.SetCursorPosition(50, 0);
                Console.WriteLine("----Менеджер по прерсоналу------");
            }

            while (b != 29)
            {
                Console.SetCursorPosition(85, b);
                Console.WriteLine("||");
                b++;
            }
            Console.SetCursorPosition(93, 7);
            Console.WriteLine("F1 - новый сотрудник");
            Console.SetCursorPosition(91, 8);
            Console.WriteLine("F2 - удалить сотрудника");
            Console.SetCursorPosition(92, 9);
            Console.WriteLine("F3 - посмотреть данные");
            Console.SetCursorPosition(94, 10);
            Console.WriteLine("F9 - поиск данных");

            Console.SetCursorPosition(2, 2);
            Console.WriteLine("ID");
            Console.SetCursorPosition(6, 2);
            Console.WriteLine("Имя");
            Console.SetCursorPosition(20, 2);
            Console.WriteLine("Фамилия");
            Console.SetCursorPosition(35, 2);
            Console.WriteLine("Отчество");
            Console.SetCursorPosition(50, 2);
            Console.WriteLine("Должность");
            Console.SetCursorPosition(65, 2);
            Console.WriteLine("Привязан к ID");
        }

        
    }
}
