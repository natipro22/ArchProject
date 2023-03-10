using SampleArch.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchProject.Models
{
    public class Country : Entity<int>
    {
        [Required]
        [MaxLength(100)]
        [Display(Name ="Country Name")]
        public string Name { get; set; }
        public IEnumerable<Person> People { get; set; }
    }
}
