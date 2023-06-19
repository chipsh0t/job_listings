using Microsoft.AspNetCore.Mvc;
using JobListingsShared.Models;
using JobListingsWeb.Models;
using System.Net.Http.Headers;
using JobListingsBusiness.Services.Contracts;

namespace JobListingsWeb.Controllers
{
    public class JobsController : Controller
    {

        private IEnumerable<string> _locations = new List<string>{"Tbilisi", "Kutaisi", "Batumi", "Gori", "Zugdidi"};
        private IEnumerable<string> _categories = new List<string> {"Accounting", "Development", "Technology", "Media and News", "Medical", "Government"};
        private IJobsService _jobsService;

        public JobsController(IJobsService jobsService) 
        { 
            _jobsService = jobsService;
        }
        
        public IActionResult DetailedDescription(int id) 
        { 
            var result = _jobsService.GetJobByIdAsync(id);
            return View(result);
        }

        [HttpGet]
        public IActionResult CreateJobListing() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateJobListing(Job job) 
        {
            if (ModelState.IsValid)
            {
                //save valid posting
                _jobsService.CreateJobAsync(job);
                return RedirectToAction("Index","HomeController");
            }
            return View();
        }
    }
}
