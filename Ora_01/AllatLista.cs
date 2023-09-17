using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora_01
{
    //Delegált létrehozása - Bárhol, akár másik fájlban is, lehet de a lényeg hogy namespace-n belül legyen
    public delegate void MiauEsemeny();

    //Saját exception, származtatjuk az Exception ősosztályból
    //(Általában külön fájlba tesszük, de a feladat egyszerűségéért itt hoztam létre)
    public class NemAllatException : Exception
    {
        //Meghívjuk az ős konstruktorát és átadjuk a üzenetet
        public NemAllatException(string message) : base(message)
        {
            
        }
    }


    //Statikus osztály - Csak egy példány létezik belőle futásidőben, nem lehet pédányosítani
    //Csakis statikus metódusok, tulajdonságok és adattatog lehetnek benne
    public static class AllatLista
    {
        //Statikus adattag
        //A listát kötelező példányosítani (létrehozni), ezt meg lehet tenni egy "=" segítségével vagy statikus konstruktor segítségével.
        private static List<Allat> allatok = new List<Allat>();

        //Statikus konstruktor
        static AllatLista()
        {
            allatok = new List<Allat>();
        }

        //Bemeneti paraméterként "object" típusú változót kérünk be, hogy tudjuk ellenőrizni a típusokat
        public static void Hozzaad(object allat)
        {
            //Ellenőrizzük hogy "Allat" típusú objektumot adunk-e hozzá a listához
            if (allat is not Allat)
            {
                //Ha nem akkor kivételt dobunk
                throw new NemAllatException("Az átadott objektum nem állat!");
            }

            //Hozzáadjuk az objektumot a listához, de előbb "Allat" típusra kell konvertálni
            allatok.Add(allat as Allat);
        }

        public static void HangotAdAzAllatok()
        {
            //Végig iterálunk az allatok listán és meghívjuk az összes elem HangotAd metódusát
            foreach (Allat allat in allatok)
            {
                Console.WriteLine(allat.HangotAd());
            }
        }
    }
}
