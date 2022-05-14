using System;
using System.Collections.Generic;

#nullable disable

namespace CampusMindAPI.Models
{
    public partial class Candidate
    {
        public int CandidateId { get; set; }
        public string CandidateName { get; set; }
        public string ImagePath { get; set; }
        public int? LeadId { get; set; }

        public virtual Lead Lead { get; set; }
    }
}
