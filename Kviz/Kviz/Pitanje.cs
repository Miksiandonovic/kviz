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

            List<int> Redosled = new List<int>();
            Redosled.Add(-1);
            Redosled.Add(0);    
            Redosled.Add(1);
            Redosled.Add(2);

            Random r = new Random();
            double res;

            for (int i = 0; i < 3; i++)
            {
                for (int j = i + 1; j < 4; j++)
                { res = r.Next(100);
                    if (res>50)
                    {
                        int tmp;
                        tmp = Redosled[i];
                        Redosled[i] = Redosled[j];
                        Redosled[j] = tmp;
                    }
                }
            }
            string sb = "";

            sb += this.TekstPitanja;
            sb += "|";
            sb += this.BrojBodova.ToString();
            sb += "\n";
            
            for (int i = 0;i<4;i++)
            {
                sb += (i + 1).ToString() + ". ";
                if (Redosled[i] == -1)
                { sb += TacanOdgovor; }
                else
                { sb += NetacniOdgovori[Redosled[i]]; }
                sb += "\n";
            }






            return sb.ToString();
        }

        
        public override string ToString()
        {
            
            return ID.ToString() + "," + TekstPitanja.ToString() + "," + TacanOdgovor.ToString() + "," + this.NetacniOdgovori[0].ToString() + "," + this.NetacniOdgovori[1].ToString() + "," + this.NetacniOdgovori[2].ToString();
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
