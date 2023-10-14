using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClasses
{
    public class Retired : Person
    {
        public Retired(string name, int age, int sulejmanEpisode) : base(name, age)
        {
            SulejmanEpisode = sulejmanEpisode;
        }

        public Retired(string name, int age) : base(name, age)
        {

        }

        public int SulejmanEpisode { get; set; }

        public override string Description()
        {
            return "Watching Sulejman all day!";
        }
    }
}
