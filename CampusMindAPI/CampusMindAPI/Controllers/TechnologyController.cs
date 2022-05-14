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
    public class TechnologyController : ControllerBase
    { [HttpGet]
        [Route("GetTechnology")]
        public ActionResult GetAllTechnology()
        {
            using (var context = new CampusMindContext())
            {
                var technology = context.Technologies.ToList();
                return Ok(technology);
            }
        }

        [HttpPost]
        [Route("AddTechnology")]
        public Task<ActionResult> AddTechnology(Technology technology)
        {

            using (var context = new CampusMindContext())
            {
                context.Technologies.Add(new Technology
                {
                    TechnologyId=technology.TechnologyId,
                    TechnologyName=technology.TechnologyName
                });

                context.SaveChanges();
            }

            return new Task<ActionResult>(() => Ok());
        }
       
    }
}
