using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CampusMindEntity
{
    public class Candidate
    {
        [Key]
        [Required]
        public int CandidateId { get; set; }

        [Required]
        public string CandidateName { get; set; }

        [Required]
        public string ImagePath { get; set; }

        [Required]
        public int LeadId { get; set; }

    }
}
