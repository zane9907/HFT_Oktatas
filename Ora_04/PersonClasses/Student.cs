using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClasses
{
    public class Student : Person
    {
        private int sesmestercount;

        public Student(string name, int age, string neptunID, string email, int credits) : base(name, age)
        {
            NeptunID = neptunID;
            Email = email;
            Credits = credits;
        }

        public Student(string name, int age) : base(name, age)
        {

        }

        public string NeptunID { get; set; }
        public string Email { get; set; }
        public int Credits { get; set; }



        public override string Description()
        {
            return "Studying hard for credits!";
        }
    }
}
