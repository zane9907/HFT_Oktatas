using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora_01
{
    //Leszármaztatunk az Allat osztályból és az IMozgathato interfészből
    public class Kutya : Allat, IMozgathato
    {
        //Átadjuk az ős konstruktorának az értékeket
        public Kutya(string nev, int kor, AllatFajta allatFajta) : base(nev, kor)
        {
            AllatFajta = allatFajta;
        }

        //Felülírjuk a HangotAd virtuális metódust
        public override string HangotAd()
        {
            return "Vau";
        }

        //Implementáljuk az interfész Mozog metódusát
        public string Mozog()
        {
            return "Fut";
        }
    }
}
