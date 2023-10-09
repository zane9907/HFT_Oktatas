using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PersonClasses
{
    public class TestAttribute : Attribute
    {
        public string DisplayName { get; set; }

        public TestAttribute(string displayName)
        {
            DisplayName = displayName;
        }
    }

    public class Person
    {
        [StringLength(10)]
        [Test("Név")]
        public string Name { get; set; }

        
        public int Age { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"name: {Name} - age: {Age}";
        }
    }
}