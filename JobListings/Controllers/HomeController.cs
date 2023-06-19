using JobListings.Models;
using JobListingsBusiness.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace JobListings.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IJobsService _jobsService;

        public HomeController(ILogger<HomeController> logger, IJobsService jobService)
        {
            _logger = logger;
            _jobsService = jobService;
        }

        public IActionResult Index()
        {
            ViewData["isHome"] = true;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}