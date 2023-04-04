using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ErasmusBlogWrb.Controllers
{
    public class MessageController : Controller
    {
        public IMessageService messageservice;
        public IWriterService writerservice;
        public UserManager<ApplicationUser> usermanager;

        public MessageController(IMessageService messageservice, IWriterService writerservice, UserManager<ApplicationUser> Usermanager)
        {
            this.messageservice = messageservice;
            this.writerservice = writerservice;
            this.usermanager= Usermanager;
        }

        public IActionResult Index(int id)
        {
            messageservice.GetByUserId(id);
            return View();
        }
        [HttpGet]
        public ActionResult Add(int id)
        {
            var t = writerservice.GetById(id);
            ViewBag.b = t.WriterMail;
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Add(Message model)
        {
            model.MessageDate = DateTime.Now.ToShortDateString();

            var t = usermanager.FindByIdAsync(usermanager.GetUserId(User));
            model.SenderMail= t.Result.Email;

            messageservice.Add(model);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult GetListById(int id)
        {
            messageservice.GetByUserId(id);
            return View(messageservice.GetByUserId(id));
        }
        public ActionResult GetList()
        {
            var t = usermanager.FindByIdAsync(usermanager.GetUserId(User));
            return View(messageservice.GetAll().Where(p=>p.SenderMail == t.Result.Email).ToList());
        }
    }
}
