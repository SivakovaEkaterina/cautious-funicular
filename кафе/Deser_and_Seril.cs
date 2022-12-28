using Newtonsoft.Json;

namespace кафе
{
    internal class Deser_and_Seril
    {
        public static T DeCer<T>(string files)
        {
            string put = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string file = put + "\\Кафешка\\" + files;
            string json = File.ReadAllText(file);
            T uchastnik = JsonConvert.DeserializeObject<T>(json);
            return uchastnik;
        }
        public static void Cerialaz<T>(T pleer, string files)
        {
            string put = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string file = put + "\\Кафешка\\" + files;
            var json = JsonConvert.SerializeObject(pleer);
            File.WriteAllText(file, json);
        }
        /*public List<InfSotrud> DeCeri(string file)
        {
            List<InfSotrud> uchastnik = new List<InfSotrud>();
            string json = File.ReadAllText(file);
            uchastnik = JsonConvert.DeserializeObject<List<InfSotrud>>(json) ?? new List<InfSotrud>();
            return uchastnik;
        }
        public void Cerialazi(List<InfSotrud> pleer, string file)
        {
            List<InfSotrud> pler = pleer.OrderByDescending(x => x.ID).Reverse().ToList();
            var json = JsonConvert.SerializeObject(pler);
            File.WriteAllText(file, json);
        }*/
    }
}
