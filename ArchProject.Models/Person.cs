using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SampleArch.Model;

namespace ArchProject.Models
{
    [Table("Person")]
    public class Person : AuditableEntity<long>
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [Required]
        [MaxLength(50)]
        public string State { get; set; }
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        [ForeignKey("CountryId")]
        public Country Country { get; set; }
    }
}
