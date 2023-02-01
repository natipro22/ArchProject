using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace ArchProject.Models
{
    public class Test
    {
        [Required]
        public string Name { get; set; }
    }
}
