using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ora05.Models
{
    public class Car
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int Year { get; set; }

        public virtual Person Person { get; set; }

        [ForeignKey(nameof(Person))]
        public string PersonId { get; set; }

        public Car()
        {
            Id = Guid.NewGuid().ToString();
        }

        //public Car(string name, int year)
        //{

        //}
    }
}
