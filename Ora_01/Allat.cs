using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora_01
{
    //Állatfajta enum
    public enum AllatFajta
    {
        Kutya,
        Macska
    }

    //Abstract osztály, nem pédányosítható
    public abstract class Allat
    {
        //publikus tulajdonságok - Publikus láthatóságú, mindig nagybetűvel kezdődik a nevük és getter, setter metódussal rendelkeznek
        public string Nev { get; set; }
        public int Kor { get; set; }

        public AllatFajta AllatFajta { get; set; }

        //Konstruktorban beállítjuk a tulajdonságok értékét
        public Allat(string nev, int kor, AllatFajta allatFajta)
        {
            Nev = nev;
            Kor = kor;
            AllatFajta = allatFajta;
        }

        public Allat(string nev, int kor)
        {
            Nev = nev;
            Kor = kor;
        }

        //Virtuális metódus, leszármazottakban felülírható
        public virtual string HangotAd()
        {
            return "Ismeretlen hangot ad";
        }
    }
}
