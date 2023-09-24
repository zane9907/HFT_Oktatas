namespace Ora2
{
    public delegate void TestDelegate(string message);

    public class Auto
    {
        public event TestDelegate testEvent;
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            TestDelegate t = new TestDelegate(Kiir);

            t += Kiir2;

            t?.Invoke("Szia");

            t -= Kiir;

            t?.Invoke("Szia");

            t = null;

            Auto a = new Auto();
            a.testEvent += Kiir;

            Action<int> action = new Action<int>(Szamol);
            action?.Invoke(1);

            Func<string, string> function = new Func<string, string>(Nagybetu);
            Console.WriteLine(function?.Invoke("asd"));

            Predicate<int> pred = new Predicate<int>(ParosE);
            Console.WriteLine((bool)pred?.Invoke(2) ? "Páros" : "Páratlan");


            Action<int> action2 = delegate (int x)
            {
                Console.WriteLine(x * x);
            };

            action2?.Invoke(5);

            Action<int, int> action3 = (x, y) =>
            {
                if (x % 2 == 0)
                {
                    Console.WriteLine(x + x);
                }
                if (y % 2 == 0)
                {
                    Console.WriteLine(y * y);

                }
            };


            action3?.Invoke(3, 8);

            ;
        }

        static bool ParosE(int szam)
        {
            return szam % 2 == 0;
        }

        static string Nagybetu(string a)
        {
            return a.ToUpper();
        }

        static void Szamol(int a)
        {
            Console.WriteLine(a + 2);
        }

        static void Kiir2(string message)
        {
            Console.WriteLine(message.ToUpper());
        }

        static void Kiir(string message)
        {
            Console.WriteLine(message);
        }
    }
}