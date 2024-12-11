using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kviz
{
    class BankaPitanja
    {
        public List<Pitanje> Pitanja { get; private set; }

        public BankaPitanja() {
            Pitanja = new List<Pitanje>();
        }
        public BankaPitanja(List<Pitanje> p)
        {
            Pitanja = p;
        }
        public int maxID()
        {
            int a = Pitanja[0].Id;
            for (int i = 1; i < Pitanja.Count; i++)
            {
                if (Pitanja[i].Id > a)
                {
                    a = Pitanja[i].Id;
                }
            }
            return a;
        }
        public void DodajPitanje(Pitanje Question)
        {
            if (Pitanja == null || Pitanja.Count()==0)
            {
                Question.Id = 1;
            }
            else
            {
                 Question.Id = maxID()+1;
            }
            Pitanja.Add(Question);
        }
        public bool PostojiID(int ID)
        {
            for (int i = 0; i < Pitanja.Count; i++)
            {
                if (ID == Pitanja[i].Id)
                {
                    return true;
                }
            }
            return false;
        }

        public void ObrisiPitanje (int ID)
        {
            if (!PostojiID(ID)) {
                Console.WriteLine($"**ERROR** Pitanje sa ID-jem {ID} ne postoji.");
                return;
            }
            foreach (var pitanje in Pitanja)
            {
                if (pitanje.Id == ID)
                {
                    Pitanja.Remove(pitanje);
                    Console.WriteLine($"Pitanje sa ID-jem {ID} je uklonjeno.");
                    return;
                }
            }
        }

        public List<Pitanje> NasumicnaPitanja(int n, int m)
        {
            Random rand = new Random();
            List<Pitanje> filtriranaPitanja = new List<Pitanje>();
            foreach (Pitanje pitanje in Pitanja)
            {
                if (pitanje.BrojBodova == m)
                {
                    filtriranaPitanja.Add(pitanje);
                }
            }
            if (filtriranaPitanja.Count < n)
            {
                Console.WriteLine("Ne postoji dovoljno pitanja odgovarajuće težine");
                return new List<Pitanje>();
            }

            List<Pitanje> nasumicnaPitanja = new List<Pitanje>();

            
            for (int i = 0; i < n; i++)
            {
                int indeks = rand.Next(filtriranaPitanja.Count);
                Pitanje izabranoPitanje = filtriranaPitanja[indeks];
                nasumicnaPitanja.Add(izabranoPitanje);
                filtriranaPitanja.RemoveAt(indeks);
            }

            return nasumicnaPitanja;
        }

    }
}