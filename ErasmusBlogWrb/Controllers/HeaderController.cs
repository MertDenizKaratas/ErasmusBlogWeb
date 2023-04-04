using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ErasmusBlogWrb.Controllers
{
    public class HeaderController : Controller
    {
        public IHeaderService headservice;
        public IWriterService writeservice;
        public ICategoryService catservice;

        public HeaderController(IHeaderService headservice, IWriterService writeservice, ICategoryService catservice, IContentHeader contentservice)
        {
            this.headservice = headservice;
            this.writeservice = writeservice;
            this.catservice = catservice;
      
        }

        public IActionResult Index()
        {
            var model = headservice.GetAll();
            return View(model);
        }
        [HttpGet]
        public ActionResult Add()
        {
            
            List<SelectListItem> d = (from x in catservice.GetAll()
                                      select new SelectListItem
                                      {
                                          Text = x.CategoryName,
                                          Value = x.CategoryId.ToString()
                                      }).ToList();
            List<SelectListItem> d2 = (from x in writeservice.GetAll()
                                       select new SelectListItem
                                       {
                                           Text = x.WriterName,
                                           Value = x.WriterId.ToString()

                                       }).ToList();
            ViewBag.slm = d;
            ViewBag.slk = d2;
            return View();
        }
        [HttpPost]
        public ActionResult Add(Header model)
        {
            model.HeadingDate = DateTime.Now.ToShortDateString();
            headservice.Add(model);
            return RedirectToAction(nameof(Index));

        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update(Header model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                headservice.Update(model);
                return RedirectToAction(nameof(Index));
            }
          
        }
        public ActionResult Delete(int id)
        {
            var model = headservice.GetById(id);
            headservice.Delete(model);
            return RedirectToAction(nameof(Index));
        }


    }
}
