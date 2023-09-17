using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora_01
{
    //Leszármaztatunk az Allat osztályból és az IMozgathato interfészből
    public class Macska : Allat, IMozgathato
    {
        //Létrehozunk egy delegált típusú eseményt
        public event MiauEsemeny MiauTortent;

        //Átadjuk az ős konstruktorának az értékeket
        public Macska(string nev, int kor, AllatFajta allatFajta) : base(nev, kor, allatFajta)
        {
        }

        //Felülírjuk a HangotAd virtuális metódust
        public override string HangotAd()
        {
            //Meghívjuk az eseményt és ellenőrizzük hogy az értéke nem NULL
            MiauTortent?.Invoke();
            return "Miau";
        }

        //Implementáljuk az interfész Mozog metódusát
        public string Mozog()
        {
            return "Mászik";
        }
    }
}
