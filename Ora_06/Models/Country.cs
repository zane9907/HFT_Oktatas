using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ora_06.Models
{
    public class Country
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Name { get; set; }
        public double Population { get; set; }
        public string Currency { get; set; }

        [JsonIgnore]
        public virtual ICollection<Company> Companies { get; set; }

        public Country()
        {
            Id = Guid.NewGuid().ToString();
            Companies = new List<Company>();
        }
    }
}
