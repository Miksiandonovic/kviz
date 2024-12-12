using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO
namespace Kviz
{
    class StorageManager
    {
        static string FilePath = "PitanjaZaKviz.txt";

        public static BankaPitanja UcitajPitanja() { 
            string [] lines = File.ReadAllLines(FilePath);
            BankaPitanja b = new BankaPitanja();
            foreach (string line in lines){
                string [] parts = line.Split(',');
                string TekstPitanja=parts[0];
                string TacanOdgovor=parts[1];
                List<String> NetacniOdgovori=new List<String>{parts[2], parts[3], parts[4]};
                int brBodova=int.Parse (parts[5]);
                Pitanje pitanje=new Pitanje(TekstPitanja,TacanOdgovor,NetacniOdgovori,brBodova);
                b.DodajPitanje(pitanje);
            }
            return b;
        }

    }
}
