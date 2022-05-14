using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CampusMind.Models
{
    public class Candidate
    {

        [Key]
        [Required]
        public int CandidateId { get; set; }

        [Required]
        public string CandidateName { get; set; }

        public IFormFile Profile { get; set; }

        [Required]
        public int LeadId { get; set; }
    }
}
