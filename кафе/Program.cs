using Newtonsoft.Json;

namespace кафе
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s = "C:\\Users\\edlit\\OneDrive\\Рабочий стол\\Кафешка\\Данные сотрудников.json";
            string ss = "C:\\Users\\edlit\\OneDrive\\Рабочий стол\\Кафешка\\Личные данные сотрудников.json";
            if (!File.Exists(s))
            {
                string put = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                Directory.CreateDirectory(put+"\\Кафешка");
                Sotrudniki Adm = new Sotrudniki();
                Adm.Login = "Admin"; 
                Adm.Password = "11111";
                Adm.Work = "Admin";
                Adm.ID = 0;
                List<Sotrudniki> rab = new List<Sotrudniki>();
                rab.Add(Adm);

                InfSotrud pust = new InfSotrud();
                List<InfSotrud> irab = new List<InfSotrud>();
                irab.Add(pust);
                File.Create(put + "\\Кафешка" + "\\Данные сотрудников.json").Close();
                File.Create(put + "\\Кафешка" + "\\Личные данные сотрудников.json").Close();
                Deser_and_Seril.Cerialaz(rab, "\\Данные сотрудников.json");
                Deser_and_Seril.Cerialaz(irab, "\\Личные данные сотрудников.json");
            }
            Vvod inpt = new Vvod();
            
            while (true)
            {
                string[] pr = inpt.Hi();
                string who = "";
                List<Sotrudniki> rab = Deser_and_Seril.DeCer<List<Sotrudniki>>("Данные сотрудников.json");
                int n = 0;
                int id = 0;
                foreach (var pleer in rab)
                {
                    if (pleer.Login == pr[0])
                    {
                        if (pleer.Password == pr[1])
                        {
                            n = 1;
                            who = pleer.Work;
                            id = pleer.ID;
                        }
                    }
                }
                if (n == 1)
                {
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("Такой человек здесь работает");
                   
                }
                else
                {
                    Console.SetCursorPosition(0, 5);
                    Console.WriteLine("Такого логина или пароля нет");
                }
                if (who == "Admin")
                {
                    Console.WriteLine("Это администратор");
                    Adminstr adm = new Adminstr();
                    adm.Privetstvie(id);
                }
                if (who == "MPers")
                {
                    Console.WriteLine("Это менеджер по персоналу");
                    Mened_Person adm = new Mened_Person();
                    adm.Privetstvie(id);
                }
                if (who == "Mskld")
                {
                    Console.WriteLine("Это кладовщик по персоналу");
                    Men_Sklad adm = new Men_Sklad();
                    adm.Privetstvie(id);
                }
                if (who == "Kassa")
                {
                    Console.WriteLine("Это кассир");
                    Kassir adm = new Kassir();
                    adm.Privetstvie(id);
                }
                if (who == "Bhglt")
                {
                    Console.WriteLine("Это бухгалтер");
                    Buhgalter adm = new Buhgalter();
                    adm.Privetstvie(id);
                }
            }
            

        }
    }
}
//И так... нам плохо. НО! - 1. Администратор - есть. 2. Менеджер по персоналу - есть. 3. Склад - в процессе.  4. Бугалтер. 5. Бариста.
//начнём с Администратора и строки ввода данных.
// 1.1 - complit =_)
//ЕЕЕЕЕЕЕЕЕССССССССС!!!! Администратор готов. 0:43 24.12.2022
// Блин... Не закончила. Но сейчас изменим >=)
// Вспонила, дописала часть с Серелизацией и дересерилизацией. Теперь оно универсально. Но пришлось убить на это 4 часа... 
// Окей, ВАЖНО следить за нижним тз. А то будет плохо.
// Следующим надо обработать исключения на случай пустоты в отдели с цифрами.
// И так вроде как с персоналом закончено.
// В итоге ещё весь вечер ушёл на "вроде как"
// Перехожу к складу. Надеюсь что хоть с ним проблем не будет.....
// И так, в целом CRUD на складе написаль, остался поиск. И можно будет страшиться кассу с бугалтерией
// И так склад закончен. В принципе он был простым, если я ничего не забыла ("OwO)
// Касса готова. Товар продаёт, со склада исчезает, но вот деньги пока что некуда не идут. Время делать последнюю часть!
// БУХГАЛТЕР Я ИДУ.