using CampusMind.Models;
using CampusMindEntity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CampusMind.Controllers
{
    public class CampusMindController : Controller
    {
        private readonly IConvertModelToEntity _convertModelToEntity;
        private readonly IWebHostEnvironment _webHostEnvironment;

        HttpClientHandler _httpClientHandler = new HttpClientHandler();

        public CampusMindController(IConvertModelToEntity convertModelToEntity, IWebHostEnvironment webHostEnvironment )
        {
            _convertModelToEntity = convertModelToEntity;
            _webHostEnvironment = webHostEnvironment;

            _httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyError) => { return true; };
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTechnology()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddTechnology(Technology technology)
        {
            TechnologyEntity technologyEntity = _convertModelToEntity.ConvertTechnologyToEntity(technology);
            string message = null;
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                using (var client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:44357");
                    var response = await client.PostAsJsonAsync<TechnologyEntity>("api/Leads/AddLead", technologyEntity);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                message = "Success";
            }
            catch (SqlException)
            {
                message = "Error";
            }
            catch (Exception)
            {
                message = "Error";
            }
            return Json(new { Message = message, System.Web.Mvc.JsonRequestBehavior.AllowGet });
        }

        [HttpGet]
        public IActionResult DeleteTechnology()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> DeleteTechnology(int techonologyId)
        {
            string message = null;
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                using (var client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:44357");
                    var response = await client.DeleteAsync("api/Techonology/DeleteTechonology" + techonologyId);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

                //_campusMindBAL.DeleteTechnology(technologyEntity);
                message = "Success";
            }
            catch (SqlException)
            {
                message = "Error";
            }
            catch (Exception)
            {
                message = "Error";
            }
            return Json(new { Message = message, System.Web.Mvc.JsonRequestBehavior.AllowGet });
        }

        [HttpGet]
        public IActionResult AddLead()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddLead(Lead lead)
        {
           
            LeadEntity leadEntity = _convertModelToEntity.ConvertLeadToEntity(lead);
            if (lead.Profile != null)
            {
                leadEntity.ImagePath = UploadedFile(lead);
            }
            try
            { 

                HttpClientHandler clientHandler = new HttpClientHandler();
                using(var client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:44357");
                    var response = await client.PostAsJsonAsync<LeadEntity>("api/Leads/AddLead", leadEntity);

                    if(response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

                //_campusMindBAL.AddLead(leadEntity);
            }
            catch (SqlException ex)
            {
                throw ex.InnerException;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;

            }
            return View();
        }

        private string UploadedFile(Lead model)
        {
            string uniqueFileName = null;

            if (model.Profile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Profile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Profile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        [HttpGet]
        public IActionResult UpdateLead()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateLead(Lead lead)
        {
            LeadEntity leadEntity = _convertModelToEntity.ConvertLeadToEntity(lead);
            try
            {
                if (lead.Profile != null)
                {
                    leadEntity.ImagePath = UploadedFile(lead);
                }

                HttpClientHandler clientHandler = new HttpClientHandler();
                using (var client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:44357");
                    var response = await client.PutAsJsonAsync<LeadEntity>("api/Leads/UpdateLead", leadEntity);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                //_campusMindBAL.UpdateLead(leadEntity);
            }
            catch (SqlException)
            {
            }
            catch (Exception)
            {
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteLead()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> DeleteLead(int leadId)
        {
            string message = null;
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                using (var client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:44357");
                    var response = await client.DeleteAsync("api/Leads/DeleteLead" + leadId);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

                //_campusMindBAL.DeleteLead(leadEntity);
                message = "Success";
            }
            catch (SqlException)
            {
                message = "Error";
            }
            catch (Exception)
            {
                message = "Error";
            }
            return Json(new { Message = message, System.Web.Mvc.JsonRequestBehavior.AllowGet });
        }

        [HttpGet]
        public async Task<IActionResult> ShowLead()
        {
            List<LeadEntity> leadEntities = null;
            HttpClientHandler clientHandler = new HttpClientHandler();
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:44357");
                var response = await client.GetAsync("api/Leads/GetLead");

                if (response.IsSuccessStatusCode)
                {
                    var inputResponse = response.Content.ReadAsStringAsync().Result;
                    leadEntities = JsonConvert.DeserializeObject<List<LeadEntity>>(inputResponse);

                    ViewBag.Data = leadEntities;
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult AddAccess()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAccess(User user)
        {
            UserEntity userEntity = _convertModelToEntity.ConvertAccessToEntity(user);

            string message = null;
            try
            {
                message = "Success";
            }
            catch (SqlException)
            {
                message = "Error";
            }
            catch (Exception)
            {
                message = "Error";
            }
            return Json(new { Message = message, System.Web.Mvc.JsonRequestBehavior.AllowGet });

        }

        [HttpGet]
        public IActionResult AddCandidate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidate(Candidate candidate)
        {

            CandidateEntity candidateEntity = _convertModelToEntity.ConvertCandidateToEntity(candidate);
            if (candidate.Profile != null)
            {
                candidateEntity.ImagePath = UploadedFile(candidate);
            }
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                using (var client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:44357");
                    var response = await client.PostAsJsonAsync<CandidateEntity>("api/Candidate/AddCandidate", candidateEntity);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }


                //_campusMindBAL.AddCandidate(candidateEntity);
            }
            catch (SqlException)
            {
            }
            catch (Exception)
            {
            }
            return View();
        }

        private string UploadedFile(Candidate model)
        {
            string uniqueFileName = null;

            if (model.Profile != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Profile.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Profile.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        [HttpGet]
        public IActionResult UpdateCandidate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCandidate(Candidate candidate)
        {
            CandidateEntity candidateEntity = _convertModelToEntity.ConvertCandidateToEntity(candidate);
            try
            {
                if (candidate.Profile != null)
                {
                    
                    candidateEntity.ImagePath = UploadedFile(candidate);
                }

                HttpClientHandler clientHandler = new HttpClientHandler();
                using (var client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:44357");
                    var response = await client.PutAsJsonAsync<CandidateEntity>("api/Candidate/UpdateCandidate", candidateEntity);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                //_campusMindBAL.UpdateCandidate(candidateEntity);
            }
            catch (SqlException)
            {
            }
            catch (Exception)
            {
            }
            return View();
        }

        [HttpGet]
        public IActionResult DeleteCandidate()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> DeleteCandidate(int candidateId)
        {
            string message = null;
            try
            {
                HttpClientHandler clientHandler = new HttpClientHandler();
                using (var client = new HttpClient(clientHandler))
                {
                    client.BaseAddress = new Uri("https://localhost:44357");
                    var response = await client.DeleteAsync("api/Candidate/DeleteCandidate" + candidateId);

                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }

                message = "Success";
            }
            catch (SqlException)
            {
                message = "Error";
            }
            catch (Exception)
            {
                message = "Error";
            }
            return Json(new { Message = message, System.Web.Mvc.JsonRequestBehavior.AllowGet });
        }

        [HttpGet]
        public async Task<IActionResult> ShowCandidate()
        {
            List<CandidateEntity> candidateEntity = null;
            HttpClientHandler clientHandler = new HttpClientHandler();
            using (var client = new HttpClient(clientHandler))
            {
                client.BaseAddress = new Uri("https://localhost:44357");
                var response = await client.GetAsync("api/Candidate/GetCandidate");

                if (response.IsSuccessStatusCode)
                {
                    var inputResponse = response.Content.ReadAsStringAsync().Result;
                    candidateEntity = JsonConvert.DeserializeObject<List<CandidateEntity>>(inputResponse);

                    ViewBag.Data = candidateEntity;
                }
            }

            return View();
        }

    }
}
