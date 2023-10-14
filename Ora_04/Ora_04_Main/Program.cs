using PersonClasses;
using System.Reflection;

namespace Ora_04_Main
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<IPerson> people = new List<IPerson>();

            Random rnd = new Random();

            Func<Type> typeRandomizer = () =>
            {
                int num = rnd.Next(0, 3);
                switch (num)
                {
                    case 0: return typeof(Worker);
                    case 1: return typeof(Student);
                    default: return typeof(Retired);
                }
            };

            for (int i = 0; i < 5; i++)
            {
                string rName = "";
                for (int j = 0; j < rnd.Next(3,11); j++)
                {
                    rName += ((char)rnd.Next('A', 'Z')).ToString();
                }

                int rAge = rnd.Next(1, 101);

                IPerson p = (IPerson)Activator.CreateInstance(typeRandomizer(), new object[] { rName, rAge });
                people.Add(p);
                Console.WriteLine($"Added new {p.GetType().Name}: {p}");
            }

            Console.WriteLine("\n-------------------------------------------------------------\n");

            foreach (var person in people)
            {
                Type t = person.GetType();
                Console.WriteLine("Type: " + t.Name);

                Console.WriteLine("FIELDS:");
                foreach (var field in t.GetFields())
                {
                    Console.WriteLine("-> " + field.Name);
                }


                Console.WriteLine("PROPERTIES:");
                foreach (var prop in t.GetProperties())
                {
                    Console.WriteLine("-> " + prop.Name);
                }

                Console.WriteLine("METHODS:");
                foreach (var method in t.GetMethods())
                {
                    Console.WriteLine("-> " + method.Name);
                }

                Console.WriteLine();
            }

            Console.WriteLine("\n-------------------------------------------------------------\n");

            foreach (var person in people)
            {
                Type t = person.GetType();

                //MethodInfo method = t.GetMethod("Description");
                MethodInfo method = t.GetMethod(nameof(person.Description));

                string result = (string)method.Invoke(person, new object[] { });
                Console.WriteLine(result);
            }
            Console.WriteLine("\n-------------------------------------------------------------\n");


            foreach (var person in people)
            {
                NameValidator(person);
            }


            ClassDetector.ClassesToXML();

            ;

        }

        static void NameValidator(object obj)
        {
            PropertyInfo info = obj.GetType().GetProperty("Name");
            NameCheckerAttribute attr = (NameCheckerAttribute)info.GetCustomAttribute(typeof(NameCheckerAttribute));

            if (attr != null)
            {
                if (attr.Length <= info.GetValue(obj).ToString().Length)
                {
                    Console.WriteLine($"Name accepted. {info.GetValue(obj)}");
                }
                else
                {
                    Console.WriteLine($"Name is too short. {info.GetValue(obj)}");
                }
            }
        }
    }
}