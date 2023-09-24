namespace Ora_02
{
    class Program
    {
        static void Main(string[] args)
        {
            Muvelet muvelet = new Muvelet(Osszeadas);
            muvelet += Kulonbseg;
            muvelet += Szorzas;
            muvelet += Osztas;

            //muvelet(10,5);
            Szamok sz = new Szamok();
            sz.Szamol(muvelet);
            Console.WriteLine("--------------------");

            sz.muveletEsemeny += muvelet;
            //sz.muveletEsemeny += Osszeadas;
            sz.Szamol();

            muvelet = null;

            Console.WriteLine("---------------------");


            Action<int, int> action = delegate (int x, int y)
            {
                Console.WriteLine(x % y);
            };

            //action += Osszeadas;
            action?.Invoke(10, 3);


            Func<int, int, double> function = delegate (int x, int y)
            {
                return (x + y) / 2;
            };

            double? atlag = function?.Invoke(6, 5);

            if (atlag != null)
            {
                Console.WriteLine(atlag);
            }


            Predicate<int> predicate = delegate (int x)
            {
                return x % 2 == 0;
            };

            bool parosE = predicate(2 + 7);

            Console.WriteLine(parosE ? "A szám páros" : "A szám pártalan");


            action += (x, y) =>
            {
                Console.WriteLine(x % y);
            };


            function += (x, y) =>
            {
                return (x + y) / 2d;
            };


            predicate += x =>
            {
                return x % 2 == 0;
            };

            Console.WriteLine("---------------");
            action?.Invoke(10, 5);
            Console.WriteLine(function?.Invoke(6, 5));
            Console.WriteLine(predicate(3 + 9));

        }

        static void Osszeadas(int a, int b)
        {
            Console.WriteLine(a + b);
        }

        static void Kulonbseg(int a, int b)
        {
            Console.WriteLine(a - b);
        }

        static void Szorzas(int a, int b)
        {
            Console.WriteLine(a * b);
        }

        static void Osztas(int a, int b)
        {
            if (a != 0 || b != 0)
            {
                Console.WriteLine(a / b);
            }
        }
    }
}