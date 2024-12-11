using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kviz
{
    public class Pitanje
    {
        public string TekstPitanja { get; private set; }
        public string TacanOdgovor { get; private set; }
        public int Id { get; private set; } 
        public List<string> NetacniOdgovori { get; private set; }   
        public int BrojBodova { get; private set; }

    }
}
