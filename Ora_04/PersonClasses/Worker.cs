using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClasses
{
    public class Worker : Person
    {
        public string Job { get; set; }
        public int Salary { get; set; }

        public Worker(string name, int age, string job, int salary) : base(name, age)
        {
            Job = job;
            Salary = salary;
        }

        public Worker(string name, int age) : base(name, age)
        {
            
        }

        public override string Description()
        {
            return "Working for money!";
        }
    }
}
