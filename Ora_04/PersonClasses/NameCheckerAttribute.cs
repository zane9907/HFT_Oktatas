using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClasses
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NameCheckerAttribute : Attribute
    {
        public int Length { get; set; }

        public NameCheckerAttribute(int length)
        {
            Length = length;
        }
    }
}
