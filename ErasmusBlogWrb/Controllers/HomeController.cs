using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using ErasmusBlogWrb.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Diagnostics;

namespace ErasmusBlogWrb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService catservice;
        private readonly UserManager<ApplicationUser> usermanager;
        private readonly IWriterService writerservice;
        public HomeController(ILogger<HomeController> logger, ICategoryService categoryService, UserManager<ApplicationUser> usermg, IWriterService writerservice)
        {
            _logger = logger;
            catservice = categoryService;
            usermanager = usermg;
            this.writerservice = writerservice;
        }

        public async Task<IActionResult> Index()
        {
            var d = await usermanager.FindByIdAsync(usermanager.GetUserId(User));
            if (d == null)
            {
                return RedirectToAction("Index", "Header");
            }
            ViewBag.name = d.Name;
            ViewBag.image = writerservice.GetByUsername(d.UserName).WriterImage;
            
            return View(d);
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