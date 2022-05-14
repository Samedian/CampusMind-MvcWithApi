using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampusMind.Models
{
    public class Technology
    {
        [Key]
        [Required]
        public int TechnolgyId { get; set; }

        [Required]
        public string TechnologyName { get; set; }
    }
}
