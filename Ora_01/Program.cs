
using Ora_01;

//A program.cs .NET 6.0 verziótól kezdve átalakult. A Program osztály és a Main függvény elrejtve léteznek.



//statikus metódus amit feliratkoztatunk a Macska eseményére
static void KiirMacska()
{
    Console.WriteLine("A macska miauzott!");
}

//Osztályok példányosítása
Kutya kutya = new Kutya("k1",21, AllatFajta.Kutya);
Macska macska = new Macska("m1", 12, AllatFajta.Macska);

//Feliratkozás az eseményre
macska.MiauTortent += KiirMacska;

//Mozog metódus meghívása
Console.WriteLine(kutya.Mozog());

//Objetumok hozzáadása a statikus Allat listához
AllatLista.Hozzaad(kutya);
AllatLista.Hozzaad(macska);

//Statikus metódus meghívása
AllatLista.HangotAdAzAllatok();


//Kivétel kezelése
object teszt = new object();

try
{
    AllatLista.Hozzaad(teszt);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}



;


