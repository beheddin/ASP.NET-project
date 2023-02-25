using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;
using System.Diagnostics;

//using MyProject.Web.Models;   //22
using MyProject.BL.Entities;   //22

namespace MyProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //24
        /*[HttpGet]
        public IActionResult MyBlogs()
        {
            return View();
        }*/

        //23
        /*[HttpGet]
        public IActionResult CreateBlog()
        {
            return View(new Blog());
        }*/

        //23
        /*[HttpPost]
        public IActionResult CreateBlog(Blog blog)
        {
            return RedirectToAction("Index");
        }*/


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}