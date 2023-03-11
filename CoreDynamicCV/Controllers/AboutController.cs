using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDynamicCV.Controllers
{
    
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutRepo());
        [HttpGet]
        public IActionResult Index()
        {
            var value = aboutManager.GetList();
            return View(value);
        }
        [HttpPost]
        public IActionResult Index(About about)
        {
            AboutValidator rules = new AboutValidator();
            ValidationResult result = rules.Validate(about);
            if (result.IsValid)
            {
                var values = aboutManager.GetById(1);
                values.Name = about.Name;
                values.Surname = about.Surname;
                values.Mail = about.Mail;
                values.Address = about.Address;
                values.Image = about.Image;
                values.Description = about.Description;
                values.PhoneNumber = about.PhoneNumber;
                aboutManager.TUpdate(values);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}
