namespace Numbers
{
    public class NumberLogic
    {
        public int A { get; set; }
        public int B { get; set; }

        public NumberLogic(int a, int b)
        {
            A = a;
            B = b;
        }

        public int Osszead(int a, int b)
        {
            return a + b;
        }

        public int Kivonas(int a, int b)
        {
            return a - b;
        }

        public int Osztas(int a, int b)
        {
            if (b == 0)
            {
                throw new Exception("0-val nem osztunk");
            }

            return a / b;
        }
    }
}