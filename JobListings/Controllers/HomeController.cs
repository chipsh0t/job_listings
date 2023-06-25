using JobListings.Models;
using JobListingsBusiness.Services.Contracts;
using JobListingsWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using JobListingsShared.Services.Contracts;

namespace JobListings.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IJobsService _jobsService;
        private ILookupService _lookupsService;

        private const int _job_listings_amount = 5;

        public HomeController(ILogger<HomeController> logger, IJobsService jobService, ILookupService lookupService)
        {
            _logger = logger;   
            _jobsService = jobService;
            _lookupsService = lookupService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["isHome"] = true;
            ViewBag.Locations = _lookupsService.Locations;
            ViewBag.Categories = _lookupsService.Categories;
            var (job_list,_) = await _jobsService.ListJobsAsync(_job_listings_amount, 1);
            var job_view_models = job_list.Select(job => new JobViewModel(job));
            return View(job_view_models);
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