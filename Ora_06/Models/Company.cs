﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Ora_06.Models
{
    public class Company
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string CompanyName { get; set; }
        public string OwnerName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Worker> Workers { get; set; }

        [ForeignKey(nameof(Country))]
        public string CountryId { get; set; }

        [JsonIgnore]
        public virtual Country Country { get; set; }

        public Company()
        {
            Workers = new List<Worker>();
        }
    }
}