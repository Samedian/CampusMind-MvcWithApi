using System;
using System.Collections.Generic;

#nullable disable

namespace CampusMindAPI.Models
{
    public partial class Lead
    {
        public Lead()
        {
            Candidates = new HashSet<Candidate>();
        }

        public int LeadId { get; set; }
        public string LeadName { get; set; }
        public string ImagePath { get; set; }
        public int? TechnologyId { get; set; }

        public virtual Technology Technology { get; set; }
        public virtual ICollection<Candidate> Candidates { get; set; }
    }
}
