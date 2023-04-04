using Microsoft.AspNetCore.Mvc;

namespace ErasmusBlogWrb.Controllers
{
    public class AdminCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
