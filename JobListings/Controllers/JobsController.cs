using Microsoft.AspNetCore.Mvc;
using JobListingsShared.Models;
using JobListingsWeb.Models;
using System.Net.Http.Headers;
using JobListingsBusiness.Services.Contracts;
using JobListingsShared.Services.Contracts;

namespace JobListingsWeb.Controllers
{
    public class JobsController : Controller
    {

        private IJobsService _jobsService;
        private ILookupService _lookupService;

        public JobsController(IJobsService jobsService, ILookupService lookupService) 
        { 
            _jobsService = jobsService;
            _lookupService = lookupService;
        }

        private void GetLocationsAndCategories()
        {
            ViewBag.Locations = _lookupService.Locations;
            ViewBag.Categories = _lookupService.Categories;
        }

        public async Task<IActionResult> DetailedDescription(int id) 
        { 
            var result = new JobViewModel(await _jobsService.GetJobByIdAsync(id));
            return View(result);
        }

        [HttpGet]
        public IActionResult CreateJobListing() 
        {
            GetLocationsAndCategories();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateJobListing(Job job) 
        {
            if (ModelState.IsValid)
            {
                //save valid posting
                await _jobsService.CreateJobAsync(job);
                return RedirectToAction("Index","Home");
            }                                                                   
            GetLocationsAndCategories();
            return View();
        }
    }
}
