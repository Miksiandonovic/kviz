using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kviz
{
    class Kviz
    {
        public BankaPitanja BankaPitanja { get;private set; }
        public Kviz(BankaPitanja bankapitanja) {
            BankaPitanja = bankapitanja;
        }
        public void UrediKviz() {
            Console.WriteLine("Šta želite da uradite?");
            Console.WriteLine("1) Dodati pitanje");
            Console.WriteLine("2) Izbrisati Pitanje");
            Console.WriteLine("3) Prikazati sva pitanja");
            Console.WriteLine("Unesite broj u zavisnosti koju opciju želite.");
            string input = Console.ReadLine();
            int n;
            int.TryParse(input,out n);
            if (n == 1) {

                Console.WriteLine("Unesite pitanje koje želite da dodate:");
                string Pitanje = Console.ReadLine();
                Console.WriteLine("Unesite Tacan odgovor:");
                string TacanOdgovor = Console.ReadLine();
                Console.WriteLine("Unesite 3 Netacna odgovora:");
                string NetacanOdgovor1 = Console.ReadLine();
                string NetacanOdgovor2 = Console.ReadLine();
                string NetacanOdgovor3 = Console.ReadLine();
                List<string> NetacniOdgovori123=null;
                NetacniOdgovori123.Add(NetacanOdgovor1);
                NetacniOdgovori123.Add(NetacanOdgovor2);
                NetacniOdgovori123.Add(NetacanOdgovor3);
                Console.WriteLine("Koliko bodova ima vaše pitanje");
                string output = Console.ReadLine();
                int brojBodova;
                int.TryParse(output,out brojBodova);
                Pitanje NovoPitanje = new Pitanje( Pitanje, TacanOdgovor, NetacniOdgovori123,brojBodova);
                BankaPitanja.Pitanja.Add(NovoPitanje);
            }
            if (n == 2) {
                Console.WriteLine("Unesite ID pitanja koje zelite da obrisete");
                string put = Console.ReadLine();
                int ID;
                int.TryParse(put, out ID);
                BankaPitanja.ObrisiPitanje(ID);
            }
            if (n == 3) {
                Console.WriteLine("Prikaz svih pitanja:");
                BankaPitanja.IzlistajPitanja();
            }

            }
        

    }
}
