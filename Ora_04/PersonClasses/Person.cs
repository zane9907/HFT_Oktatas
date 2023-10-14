namespace PersonClasses
{
    public abstract class Person : IPerson
    {
        [NameChecker(5)]
        public string Name { get; set; }
        public int Age { get; set; }

        protected Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public abstract string Description();

        public override string ToString()
        {
            return $"{Name} - {Age} | {Description()}";
        }
    }
}