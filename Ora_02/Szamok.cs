using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora_02
{
    public class Szamok
    {
        static Random rnd;

        static Szamok()
        {
            rnd = new Random();
        }

        public int A { get; set; }
        public int B { get; set; }

        public event Muvelet muveletEsemeny;

        public Szamok()
        {            
            A = rnd.Next(1, 10);
            B = rnd.Next(1, 10);
        }

        public void Szamol(Muvelet muvelet)
        {
            //if (muvelet != null)
            //{
            //    muvelet(A, B);
            //}

            muvelet?.Invoke(A, B);
        }

        public void Szamol()
        {
            muveletEsemeny?.Invoke(A, B);
        }
    }
}
