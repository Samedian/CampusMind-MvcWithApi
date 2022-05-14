using CampusMindAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusMindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadsController : ControllerBase
    {
        [HttpGet]
        [Route("GetLead")]
        public ActionResult GetAllLead()
        {
            using (var context = new CampusMindContext())
            {
                var leads = context.Leads.ToList();
                return Ok(leads);
            }
        }

        [HttpPost]
        [Route("AddLead")]
        public Task<ActionResult> AddLead(Lead lead)
        {

            using (var context = new CampusMindContext())
            {
                context.Leads.Add(new Lead
                {
                    LeadId = lead.LeadId,
                    LeadName = lead.LeadName,
                    ImagePath = lead.ImagePath,
                    TechnologyId = lead.TechnologyId
                }) ;

                context.SaveChanges();
            }

            return new Task<ActionResult>(() => Ok());
        }

        [HttpPut]
        [Route("UpdateLead")]
        public Task<ActionResult> UpdateLead(Lead lead)
        {

            using (var context = new CampusMindContext())
            {
                var data = context.Leads.Find(lead.LeadId);

                data.LeadName = lead.LeadName;
                data.TechnologyId = lead.TechnologyId;
                data.ImagePath = lead.ImagePath;

                context.SaveChanges();
            }

            return new Task<ActionResult>(() => Ok());
        }

        [HttpDelete]
        [Route("DeleteLead")]
        public Task<ActionResult> DeleteLead(int LeadId)
        {

            using (var context = new CampusMindContext())
            {
                var data = context.Leads.Find(LeadId);
                context.Leads.Remove(data);
                context.SaveChanges();
            }

            return new Task<ActionResult>(() => Ok());
        }
    }
}
