
namespace кафе
{
    internal class Adminstr : ICRUD
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
                
                int b = 3;
                foreach (var pleer in rab)
                {
                    Console.SetCursorPosition(2, b);
                    Console.WriteLine(pleer.ID);
                    Console.SetCursorPosition(10, b);
                    Console.WriteLine(pleer.Login);
                    Console.SetCursorPosition(40, b);
                    Console.WriteLine(pleer.Password);
                    Console.SetCursorPosition(70, b);
                    Console.WriteLine(pleer.Work);
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

            Console.SetCursorPosition(0, 2);
            Console.WriteLine("                                                                               ");
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("  ID: ");
            Console.WriteLine("  Логин: ");
            Console.WriteLine("  Пароль: ");
            Console.WriteLine("  Должность: ");
            Console.WriteLine("  Завершить.");
            int a = 0, b = 0, c = 0, d = 0;
            Sotrudniki sotrudnik = new Sotrudniki();
            
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
                        if (r!= 0)
                        {
                            break;
                        }
                    }
                    d++;
                    rab = Deser_and_Seril.DeCer<List<Sotrudniki>>("Данные сотрудников.json");

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
                    Console.WriteLine("  Логин:                 ");
                    Console.SetCursorPosition(10, 3);
                    sotrudnik.Login = Console.ReadLine();
                    a++;
                }
                if (k == 4)
                {
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine("  Пароль:                 ");
                    Console.SetCursorPosition(11, 4);
                    sotrudnik.Password = Console.ReadLine();
                    b++;
                }
                if (k == 5)
                {
                    {
                        Console.SetCursorPosition(0, 5);
                        Console.WriteLine("  Должность:                 ");
                        Console.SetCursorPosition(92, 12);
                        Console.WriteLine("Должности: ");
                        Console.SetCursorPosition(92, 13);
                        Console.WriteLine("Admin - администратор");
                        Console.SetCursorPosition(92, 14);
                        Console.WriteLine("MPers - мен. персонала");
                        Console.SetCursorPosition(92, 15);
                        Console.WriteLine("Mskld - мен. склада");
                        Console.SetCursorPosition(92, 16);
                        Console.WriteLine("Kassa - кассир");
                        Console.SetCursorPosition(92, 17);
                        Console.WriteLine("Bhglt - бухгалтер");
                        Console.SetCursorPosition(13, 5);
                    }
                    sotrudnik.Work = Console.ReadLine();
                    c++;
                    {
                        Console.SetCursorPosition(92, 12);
                        Console.WriteLine("                          ");
                        Console.SetCursorPosition(92, 13);
                        Console.WriteLine("                          ");
                        Console.SetCursorPosition(92, 14);
                        Console.WriteLine("                          ");
                        Console.SetCursorPosition(92, 15);
                        Console.WriteLine("                          ");
                        Console.SetCursorPosition(92, 16);
                        Console.WriteLine("                          ");
                        Console.SetCursorPosition(92, 17);
                        Console.WriteLine("                          ");
                    }
                    if (sotrudnik.Work != "Admin" && sotrudnik.Work != "MPers" && sotrudnik.Work != "Mskld" && sotrudnik.Work != "Kassa" && sotrudnik.Work != "Bhglt")
                    {
                        Console.SetCursorPosition(92, 12);
                        Console.WriteLine("Такой должности нет!");
                        c--;
                        Console.SetCursorPosition(0, 5);
                        Console.WriteLine("  Должность:                 ");
                    }
                    

                }
                if (k == 6)
                {
                    if (a > 0 && b > 0 && c > 0 && d > 0)
                    {
                        
                        rab = Deser_and_Seril.DeCer<List<Sotrudniki>>("Данные сотрудников.json");
                        rab.Add(sotrudnik);
                        List<Sotrudniki> pler = rab.OrderByDescending(x => x.ID).Reverse().ToList();
                        Deser_and_Seril.Cerialaz(pler, "Данные сотрудников.json");

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
        public void Read(int id)
        {

            List<Sotrudniki> rab = Deser_and_Seril.DeCer<List<Sotrudniki>>("Данные сотрудников.json");
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
                    Console.Write("  Логин: ");
                    Console.WriteLine(rab[d - 3].Login);
                    Console.Write("  Пароль: ");
                    Console.WriteLine(rab[d - 3].Password);
                    Console.Write("  Должность: ");
                    Console.WriteLine(rab[d - 3].Work);
                    Console.WriteLine("  Вернуться.");

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
            
                rab = Deser_and_Seril.DeCer<List<Sotrudniki>>("Данные сотрудников.json");
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
                    Console.WriteLine(rab[so].Login);
                    Console.SetCursorPosition(40, b);
                    Console.WriteLine(rab[so].Password);
                    Console.SetCursorPosition(70, b);
                    Console.WriteLine(rab[so].Work);
                    so++;
                    lo--;
                    b++;
                }
            }
        }
        public void Update(int s, int id)
        {
            List<Sotrudniki> rab = Deser_and_Seril.DeCer<List<Sotrudniki>>("Данные сотрудников.json");
            Sotrudniki rabik = new Sotrudniki();
            int z = 3 + rab.Count;
            Console.Clear();
            Tekst(id);
            Console.SetCursorPosition(0, 2);
            Console.WriteLine("                                                                               ");
            Console.SetCursorPosition(0, 2);
            Console.Write("  ID: ");
            Console.WriteLine(rab[s].ID);
            rabik.ID = rab[s].ID;
            Console.Write("  Логин: ");
            Console.WriteLine(rab[s].Login);
            rabik.Login = rab[s].Login;
            Console.Write("  Пароль: ");
            Console.WriteLine(rab[s].Password);
            rabik.Password = rab[s].Password;
            Console.Write("  Должность: ");
            Console.WriteLine(rab[s].Work);
            rabik.Work = rab[s].Work;
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
                            break;
                        }
                    }

                    rab = Deser_and_Seril.DeCer<List<Sotrudniki>>("Данные сотрудников.json");

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
                    }
                    
                }
                if (k == 3)
                {
                    Console.SetCursorPosition(0, 3);
                    Console.WriteLine("  Логин:                 ");
                    Console.SetCursorPosition(10, 3);
                    rabik.Login = Console.ReadLine();
                }
                if (k == 4)
                {
                    Console.SetCursorPosition(0, 4);
                    Console.WriteLine("  Пароль:                 ");
                    Console.SetCursorPosition(11, 4);
                    rabik.Password = Console.ReadLine();
                }
                if (k == 5)
                {
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("  Должность:                 ");
                    Console.SetCursorPosition(13, 5);
                    rabik.Work = Console.ReadLine();
                }
                if (k == 6)
                { 
                    rab = Deser_and_Seril.DeCer<List<Sotrudniki>>("Данные сотрудников.json");
                    rab.RemoveAt(s);
                    rab.Add(rabik);
                    List<Sotrudniki> pler = rab.OrderByDescending(x => x.ID).Reverse().ToList();
                    Deser_and_Seril.Cerialaz(pler, "Данные сотрудников.json");

                    break;
                    
                }
            }
        }
        public void Delet(int id)
        {
            List<Sotrudniki> rab = Deser_and_Seril.DeCer<List<Sotrudniki>>("Данные сотрудников.json");
            int z = 3 + rab.Count;
            int d = str.Strel(3, z);
            rab.RemoveAt(d-3);
            Deser_and_Seril.Cerialaz(rab, "Данные сотрудников.json");
        }
        public void Poisk(int id)
        {
            List<Sotrudniki> rab = Deser_and_Seril.DeCer<List<Sotrudniki>>("Данные сотрудников.json");
            Console.Clear();
            Tekst(id);
            while (true)
            {
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("                                                                               ");
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("  ID.");
                Console.WriteLine("  Логин.");
                Console.WriteLine("  Пароль.");
                Console.WriteLine("  Должность.");
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
                    Console.WriteLine("                  \n                  \n                  \n                  ");
                    Console.SetCursorPosition(6, 2);
                    int idi = Convert.ToInt32(Console.ReadLine());
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("                                                                    ");
                    int n = 0;
                    int d = 3;
                    Console.SetCursorPosition(2, 2);
                    Console.WriteLine("ID");
                    Console.SetCursorPosition(10, 2);
                    Console.WriteLine("Логин");
                    Console.SetCursorPosition(40, 2);
                    Console.WriteLine("Пароль");
                    Console.SetCursorPosition(70, 2);
                    Console.WriteLine("Должность");
                    foreach (var pleer in rab)
                    {
                        if (pleer.ID == idi)
                        {
                            Console.SetCursorPosition(2, d);
                            Console.WriteLine(pleer.ID);
                            Console.SetCursorPosition(10, d);
                            Console.WriteLine(pleer.Login);
                            Console.SetCursorPosition(40, d);
                            Console.WriteLine(pleer.Password);
                            Console.SetCursorPosition(70, d);
                            Console.WriteLine(pleer.Work);
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
                    Console.WriteLine("  Логин: ");
                    Console.WriteLine("                  \n                  \n                  \n                  ");
                    Console.SetCursorPosition(10, 2);
                    string prov = Console.ReadLine();
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("                                                                    ");
                    int n = 0;
                    int d = 3;
                    Console.SetCursorPosition(2, 2);
                    Console.WriteLine("ID");
                    Console.SetCursorPosition(10, 2);
                    Console.WriteLine("Логин");
                    Console.SetCursorPosition(40, 2);
                    Console.WriteLine("Пароль");
                    Console.SetCursorPosition(70, 2);
                    Console.WriteLine("Должность");
                    foreach (var pleer in rab)
                    {
                        if (pleer.Login == prov)
                        {
                            Console.SetCursorPosition(2, d);
                            Console.WriteLine(pleer.ID);
                            Console.SetCursorPosition(10, d);
                            Console.WriteLine(pleer.Login);
                            Console.SetCursorPosition(40, d);
                            Console.WriteLine(pleer.Password);
                            Console.SetCursorPosition(70, d);
                            Console.WriteLine(pleer.Work);
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
                    Console.WriteLine("  Пароль: ");
                    Console.WriteLine("                  \n                  \n                  \n                  ");
                    Console.SetCursorPosition(10, 2);
                    string prov = Console.ReadLine();
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("                                                                    ");
                    int n = 0;
                    Console.SetCursorPosition(2, 2);
                    Console.WriteLine("ID");
                    Console.SetCursorPosition(10, 2);
                    Console.WriteLine("Логин");
                    Console.SetCursorPosition(40, 2);
                    Console.WriteLine("Пароль");
                    Console.SetCursorPosition(70, 2);
                    Console.WriteLine("Должность");
                    int d = 3;
                    foreach (var pleer in rab)
                    {
                        if (pleer.Password == prov)
                        {
                            Console.SetCursorPosition(2, d);
                            Console.WriteLine(pleer.ID);
                            Console.SetCursorPosition(10, d);
                            Console.WriteLine(pleer.Login);
                            Console.SetCursorPosition(40, d);
                            Console.WriteLine(pleer.Password);
                            Console.SetCursorPosition(70, d);
                            Console.WriteLine(pleer.Work);
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
                    Console.WriteLine("  Должность: ");
                    Console.WriteLine("                  \n                  \n                  \n                  ");
                    Console.SetCursorPosition(15, 2);
                    string prov = Console.ReadLine();
                    Console.SetCursorPosition(0, 2);
                    Console.WriteLine("                                                                    ");
                    int n = 0;
                    Console.SetCursorPosition(2, 2);
                    Console.WriteLine("ID");
                    Console.SetCursorPosition(10, 2);
                    Console.WriteLine("Логин");
                    Console.SetCursorPosition(40, 2);
                    Console.WriteLine("Пароль");
                    Console.SetCursorPosition(70, 2);
                    Console.WriteLine("Должность");
                    int d = 3;
                    foreach (var pleer in rab)
                    {
                        if (pleer.Work == prov)
                        {
                            Console.SetCursorPosition(2, d);
                            Console.WriteLine(pleer.ID);
                            Console.SetCursorPosition(10, d);
                            Console.WriteLine(pleer.Login);
                            Console.SetCursorPosition(40, d);
                            Console.WriteLine(pleer.Password);
                            Console.SetCursorPosition(70, d);
                            Console.WriteLine(pleer.Work);
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
                if (pleer.Work == "Admin" && pleer.Name != null && pleer.ID == id)
                {
                    Console.SetCursorPosition(50, 0);
                    Console.WriteLine("----- " + pleer.Name + " -----");
                    d++;
                }
            }
            if (d == 0)
            {
                Console.SetCursorPosition(50, 0);
                Console.WriteLine("----Администратор------");
            }
            while (b!= 29)
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
            Console.SetCursorPosition(10, 2);
            Console.WriteLine("Логин");
            Console.SetCursorPosition(40, 2);
            Console.WriteLine("Пароль");
            Console.SetCursorPosition(70, 2);
            Console.WriteLine("Должность");
        }
    }
}
