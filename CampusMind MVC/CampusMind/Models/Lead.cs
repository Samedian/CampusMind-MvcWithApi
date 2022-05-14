using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampusMind.Models
{
    public class Lead
    {

        [Key]
        [Required]
        public int LeadId { get; set; }

        [Required]
        public string LeadName { get; set; }

        [Required]
        public IFormFile Profile { get; set; }


        [Required]
        public int technologyId { get; set; }
    }
}
