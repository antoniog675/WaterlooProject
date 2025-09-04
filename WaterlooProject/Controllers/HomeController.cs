using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WaterlooProject.Models;
using WaterlooProject.Shared.Contracts;

namespace WaterlooProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGoogleSearchService _searchService;

        public HomeController(ILogger<HomeController> logger,IGoogleSearchService searchService)
        {
            _logger = logger;
            _searchService = searchService;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Search()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Search(string query)
        {
            var results = await _searchService.SearchAsyc(query); // Service call
            return View("Search", results);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
