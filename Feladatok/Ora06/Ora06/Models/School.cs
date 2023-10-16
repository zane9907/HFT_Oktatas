using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora06.Models
{
    public class School
    {
        [Key]
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Person> People { get; set; }

        public School()
        {
            Id = Guid.NewGuid().ToString();
            People = new List<Person>();
        }
    }
}
