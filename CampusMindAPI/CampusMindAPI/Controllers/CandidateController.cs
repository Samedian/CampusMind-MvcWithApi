using CampusMindAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CampusMindAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        [HttpGet]
        [Route("GetCandidate")]
        public ActionResult GetAllCandidate()
        {
            using (var context = new CampusMindContext())
            {
                var candidates = context.Candidates.ToList();
                return Ok(candidates);
            }
        }

        [HttpPost]
        [Route("AddCandidate")]
        public Task<ActionResult> AddCandidate(Candidate candidate)
        {

            using (var context = new CampusMindContext())
            {
                context.Candidates.Add(new Candidate
                {
                 CandidateId=candidate.CandidateId,
                 CandidateName=candidate.CandidateName,
                 ImagePath=candidate.ImagePath,
                 LeadId=candidate.LeadId
                });

                context.SaveChanges();
            }

            return new Task<ActionResult>(() => Ok());
        }

        [HttpPut]
        [Route("UpdateCandidate")]
        public Task<ActionResult> UpdateCandidate(Candidate candidate)
        {

            using (var context = new CampusMindContext())
            {
                var data = context.Candidates.Find(candidate.LeadId);

                data.CandidateName = candidate.CandidateName;
                data.LeadId = candidate.LeadId;
                data.ImagePath = candidate.ImagePath;

                context.SaveChanges();
            }

            return new Task<ActionResult>(() => Ok());
        }

        [HttpDelete]
        [Route("DeleteCandidate")]
        public Task<ActionResult> DeleteCandidate(int candidateId)
        {

            using (var context = new CampusMindContext())
            {
                var data = context.Leads.Find(candidateId);
                context.Leads.Remove(data);
                context.SaveChanges();
            }

            return new Task<ActionResult>(() => Ok());
        }
    }
}
