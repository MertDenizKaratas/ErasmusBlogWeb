using Ardalis.Result;
using BusinessLayer.Validations;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ValidationResult = FluentValidation.Results.ValidationResult;

namespace ErasmusBlogWrb.Controllers
{
    public class CategoryController : Controller
    {
        public ICategoryService catservice;

        public CategoryController(ICategoryService catservice)
        {
            this.catservice = catservice;
        }

        public IActionResult Index()
        {
            var d = catservice.GetAll();
            return View(d);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Category model) 
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult results =categoryValidator.Validate(model);
            if (results.IsValid)
            {
                catservice.Add(model);
                return RedirectToAction("GetList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                
            }
            return View();
        }
        public ActionResult GetList()
        {
            var model = catservice.GetAll();
            return View(model);
        }
        public ActionResult Delete(int id) 
        {
            var x = catservice.GetById(id);
            catservice.Delete(x);
            return RedirectToAction("GetList");
        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var model = catservice.GetById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Update(Category category)
        {
            ModelState.Remove("Headers");
            if (!ModelState.IsValid)
            {
                return View(category);
            }
            else
            {
                catservice.Update(category);
                return RedirectToAction("GetList");
            }
        }

    }
}
