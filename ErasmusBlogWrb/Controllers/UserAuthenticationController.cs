using DataAccessLayer.Abstract;
using DataAccessLayer.Abstract.Authentication;
using EntityLayer.Concrete;
using EntityLayer.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ErasmusBlogWrb.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private IUserAuthenticationService authService;
        private UserManager<ApplicationUser> _userManager;
        private IWriterService writerservice;

        public IActionResult Index()
        {
            return View();
        }
        public UserAuthenticationController(IUserAuthenticationService authService, UserManager<ApplicationUser> userManager, IWriterService writerService)
        {
            this.authService = authService;
            this._userManager = userManager;
            this.writerservice = writerService;

        }
        /* We will create a user with admin rights, after that we are going
          to comment this method because we need only
          one user in this application 
          If you need other users ,you can implement this registration method with view
          I have create a complete tutorial for this, you can check the link in description box
         */

        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegistrationModel model)
        {

            // if you want to register with user , Change Role="User"
            var result = await authService.RegisterAsync(model);
            var tt = _userManager.GetUserId(User);
  
            return Ok(result.Message);
            
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {

            if (!ModelState.IsValid)
                return View(model);

            var result = await authService.LoginAsync(model);
            if (result.StatusCode == 1)
            {

                return RedirectToAction("index", "Home");
            }
            else
            {
                TempData["msg"] = "Could not logged in..";
                return RedirectToAction(nameof(Login));
            }

        }

        public async Task<IActionResult> Logout()
        {
            await authService.LogoutAsync();
            return RedirectToAction("Login", "UserAuthentication");
        }
        public async Task<IActionResult> GetUser()
        {
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }
        public async Task<IActionResult> RegisterSeri(RegistrationModel data)
        {
            var result = await authService.RegisterAsync(data);
            if (result.StatusCode == 1)
            {
                Logout();
                return RedirectToAction("Login", "UserAuthentication");
            }
            else
            {
                TempData["msg"] = "Could not logged in..";
                return RedirectToAction(nameof(Login));
            }
         
            
        }
        
    }
}
