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
    public enum EyeColorEnum
    {
        Brown,
        Blue,
        Green
    }

    public class Worker
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public int Balance { get; set; }
        public EyeColorEnum EyeColor { get; set; }
        public string Gender { get; set; }
        public DateTime Registered { get; set; }

        [ForeignKey(nameof(Company))]
        public string CompanyID { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual Company Company { get; set; }

        public Worker()
        {
            Id = Guid.NewGuid().ToString();
        }

    }
}
