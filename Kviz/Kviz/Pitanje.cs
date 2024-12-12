using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kviz
{

    public class Pitanje
    {
           
        public int ID;
        public string TekstPitanja { get; private set; }
        public string TacanOdgovor { get; private set; }
        public List<string> NetacniOdgovori { get; private set; }
        public int BrojBodova { get; private set; }

        
        public Pitanje(string tekstPitanja, string tacanOdgovor, List<string> netacniOdgovori, int brojBodova)
        {
            ID =0;  
            TekstPitanja = tekstPitanja;
            TacanOdgovor = tacanOdgovor;
            NetacniOdgovori = netacniOdgovori;
            BrojBodova = brojBodova;
        }

       
        public Pitanje(string linija)
        {
            var delovi = linija.Split(',');
            if (delovi.Length < 6)
                throw new ArgumentException("String reprezentacija nije validna!");

            
            this.TekstPitanja = delovi[0];
            this.TacanOdgovor = delovi[1];
            this.NetacniOdgovori = new List<string> { delovi[2], delovi[3], delovi[4] };
            this.BrojBodova = int.Parse(delovi[5]);

            
            
        }

        
        public string Prikaz()
        {
            // Tacan odgovor uvek na poziciji 1 za sada, tako ste Vi rekli

            string sb = "";

            sb += this.TekstPitanja;
            sb += "|";
            sb += this.BrojBodova.ToString();
            sb += "\n";
            sb += "1. ";
            sb += this.TacanOdgovor;
            sb += "\n";
            sb += "2. ";
            sb += this.NetacniOdgovori[0];
            sb += "\n";
            sb += "3. ";
            sb += this.NetacniOdgovori[1];
            sb += "\n";
            sb += "4. ";
            sb += this.NetacniOdgovori[2];
            sb += "\n";






            return sb.ToString();
        }

        
        public override string ToString()
        {
            
            return ID.ToString() + "," + TekstPitanja.ToString() + "," + TacanOdgovor.ToString() + "," + this.NetacniOdgovori[0].ToString() + "," + this.NetacniOdgovori[1].ToString() + "," + this.NetacniOdgovori[2].ToString() + "," + BrojBodova;
        }
        public int Provera(string odgovor)
        {
            if (string.Equals(odgovor, this.TacanOdgovor, StringComparison.CurrentCultureIgnoreCase))
                {
                return BrojBodova;
            }
            return 0;
            
        }

    }
}
