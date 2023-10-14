using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora05.Models
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Car> Cars { get; set; }

        public Person()
        {
            Id = Guid.NewGuid().ToString();
            Cars = new List<Car>();
        }

    }
}
