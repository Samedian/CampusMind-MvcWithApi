using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace CampusMindEntity
{
    public class LeadEntity
    {

        public int LeadId { get; set; }

        public string LeadName { get; set; }

        public string ImagePath { get; set; }


        public int TechnologyId { get; set; }
    }
}
