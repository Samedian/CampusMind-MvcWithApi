using System;
using System.Collections.Generic;

#nullable disable

namespace CampusMindAPI.Models
{
    public partial class Technology
    {
        public Technology()
        {
            Leads = new HashSet<Lead>();
        }

        public int TechnologyId { get; set; }
        public string TechnologyName { get; set; }

        public virtual ICollection<Lead> Leads { get; set; }
    }
}
