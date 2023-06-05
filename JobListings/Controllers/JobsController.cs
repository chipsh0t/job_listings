using Microsoft.AspNetCore.Mvc;
using JobListingsShared.Models;
using JobListingsWeb.Models;
using System.Net.Http.Headers;

namespace JobListingsWeb.Controllers
{
    public class JobsController : Controller
    {
        //ublic IActionResult Index()
        //
        //   return View();
        //

        public IActionResult ListJobs()
        {
            //List<JobViewModel> jobs = new List<JobViewModel>{ 
            //    new JobViewModel { Id = 1, Name = "test1"},
            //    new JobViewModel { Id = 2, Name = "test2"}
            //};

            return View();
        }

        public IActionResult DetailedDescription() 
        { 
            return View();
        }

        [HttpGet]
        public IActionResult CreateJobListing() 
        {
            return View();
        }

        
    }
}
