using Castle.Core.Resource;
using DataAccessLayer.Abstract;
using DataAccessLayer.Implementation;
using EntityLayer.Concrete;
using EntityLayer.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace ErasmusBlogWrb.Controllers
{
    public class WriterController : Controller
    {
        public IWriterService writeser;
        public UserManager<ApplicationUser> usermanager;
        public WriterController(IWriterService writeser, UserManager<ApplicationUser> userManager)
        {
            this.writeser = writeser;
            this.usermanager = userManager;
        }

        public IActionResult Index()
        {
            var list = writeser.GetAll();
            return View(list);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Add(Writer model)
        {

            //var id = usermanager.GetUserId(User);
            //var tt = new WritersAndUsersRelationship
            //{
            //    UserId = id,
            //    WritersId = model.WriterId
            //};

            ModelState.Remove("Contents");
            ModelState.Remove("Headers");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                var result = writeser.Add(model);
                if (result)
                {
                    RegistrationModel data = new RegistrationModel
                    {
                        Email = model.WriterMail,
                        Name = model.WriterName,
                        Username = model.WriterUsername,
                        Password = model.WritePassword,
                        PasswordConfirm = model.WritePassword,
                        WritersId= model.WriterId,
                        
                    };

                    //TempData["msg"] = "Added Successfully";
                    return RedirectToAction("RegisterSeri", "UserAuthentication", data);

                }
                else
                {
                    TempData["msg"] = "Error on server side";
                    return View(model);
                }
            }
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = writeser.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Writer model)
        {
            var result = writeser.Update(model);
            if (result)
            {
                TempData["msg"] = "Updated Successfully";
                return RedirectToAction(nameof(GetList));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }

        }
        public ActionResult GetList()
        {
            var list = writeser.GetAll();
            return View(list);
        }
        public ActionResult WriterProfile(int id)
        {
            
            return View(writeser.GetById(id));
        }
        public ActionResult Delete(int id)
        {

            writeser.Delete(writeser.GetById(id));
            return RedirectToAction(nameof(Index));
        }
    }
}
