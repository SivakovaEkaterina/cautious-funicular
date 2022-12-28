using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace кафе
{
    internal interface ICRUD
    {
        void Create(int id);
        void Read(int id);
        void Update(int s, int id);
        void Delet(int id);
        void Poisk(int id);
    }
}
