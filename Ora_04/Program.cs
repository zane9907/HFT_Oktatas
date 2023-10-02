using PersonClasses;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Ora_04
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("asd");
            person.Name = "Test";

            Assembly a = Assembly.GetExecutingAssembly();

            var types = a.GetTypes();

            var type =  person.GetType();

            var propInfo = type.GetProperty("Name");
            var infos = type.GetProperties();

            var name = propInfo.GetValue(person);
            propInfo.SetValue(person, "TEST2");

            var methodInfos = type.GetMethods();


            //methodInfos[0].Invoke(person, new object[] { "asd", 125 });

            var fieldInfos = type.GetFields();

            var newPerson  =(Person)Activator.CreateInstance(typeof(Person),"asd");


            var attr = propInfo.GetCustomAttribute(typeof(TestAttribute));


            ;
        }
    }
}