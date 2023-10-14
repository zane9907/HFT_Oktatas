using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ora_05.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string OwnerName { get; set; }

        public virtual ICollection<Worker> Workers { get; set; }

        public Company()
        {
            Workers = new List<Worker>();
        }
    }
}