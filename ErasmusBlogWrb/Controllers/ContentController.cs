using DataAccessLayer.Abstract;
using DataAccessLayer.Implementation;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ErasmusBlogWrb.Controllers
{
    public class ContentController : Controller
    {
        public IContentHeader contentservice;
        public UserManager<ApplicationUser> usermanager;
        public IWriterService writerservice;
        public IHeaderService headerService;
        public ContentController(IContentHeader contentservicem, UserManager<ApplicationUser> UserManager, IWriterService writerservice, IHeaderService headerservice)
        {
            this.contentservice = contentservicem;
            this.usermanager = UserManager;
            this.writerservice = writerservice;
            this.headerService = headerservice;
        }

        public IActionResult Index()
        {
            var d = contentservice.GetAll();
            return View(d);
        }
        [HttpGet]
        public ActionResult Add(int Id)
        {
            ViewBag.d = Id;
            return View();
        }
        [HttpPost]
        public ActionResult Add(Content model)
        {
            
            model.ContentDate = DateTime.Now.ToShortDateString();
            var appUserNick  = usermanager.FindByIdAsync(usermanager.GetUserId(User)).Result.UserName;
            var user = writerservice.GetByUsername(appUserNick);
            model.WriterId = user.WriterId;

            contentservice.Add(model);
            return RedirectToAction(nameof(Index));

        }
        public ActionResult Update(int id)
        {
            var model = contentservice.GetById(id);
            return View(model);
        }
        public ActionResult Update(Content model)
        {
            contentservice.Update(model);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult Delete(int id)
        {
            var model = contentservice.GetById(id);
            contentservice.Delete(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public ActionResult GetContentById(int id)
        {
            var model = contentservice.GetContentById(id);
            return View(model);
        }
    }
}
