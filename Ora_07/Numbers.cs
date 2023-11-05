namespace NumberLogic
{
    public class Numbers
    {
        private readonly List<int> numbers = new List<int>();


        public void Add(int value)
        {
            if (!numbers.Contains(value))
            {
                numbers.Add(value);
                return;
            }

            throw new Exception("Number already exists");
        }

        public void Delete(int value)
        {
            if (numbers.Contains(value))
            {
                numbers.Remove(value);
                return;
            }

            throw new Exception("Number doesn't exist");
        }

        public List<int> Get()
        {
            return numbers.ToList();
        }


        public int Add(int a, int b)
        {
            return a + b;
        }

        public int Subtract(int a, int b)
        {
            return a - b;
        }

        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new Exception("Can't divide with zero");
            }


            return a / b;
        }

        public int Sum()
        {
            return numbers.Sum();
        }

        public double Average()
        {
            return numbers.Average();
        }
    }
}