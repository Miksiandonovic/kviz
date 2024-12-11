using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kviz
{
    class BankaPitanja
    {
        public List<Pitanje> Pitanja { get; private set; }

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
        void DodajPitanje(Pitanje Question)
        {
            Pitanja.Add(Question);
            Question.Id = maxID();
        }


    }
}