using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDynamicCV.Controllers
{
    public class EducationController : Controller
    {
        EducationManager educationManager = new EducationManager(new EfEducationRepo());
        public IActionResult Index()
        {
            var values = educationManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEducation()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEducation(Education education)
        {
            EducationValidator rules = new EducationValidator();
            ValidationResult result = rules.Validate(education);
            if (result.IsValid) {
                education.EducationTime = DateTime.Parse(DateTime.Now.ToShortDateString());
                education.EducationStatus = true;
                educationManager.TInsert(education);
                return RedirectToAction("Index", "Education");
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
       public IActionResult DeleteEducation(int id)
        {
            var value = educationManager.GetById(id);
            value.EducationStatus = false;
            educationManager.TUpdate(value);
            return RedirectToAction("Index","Education");
        }
        [HttpGet]
        public IActionResult UpdateEducation(int id)
        {
            var values = educationManager.GetById(id); 
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateEducation(Education education)
        {
            EducationValidator rules = new EducationValidator();
            ValidationResult result = rules.Validate(education);
            if (result.IsValid)
            {
                education.EducationTime = DateTime.Parse(DateTime.Now.ToShortDateString());
                education.EducationStatus = true;
                educationManager.TUpdate(education);
                return RedirectToAction("Index", "Education");
            }
            else
            {
                foreach (var x in result.Errors)
                {

                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return View();
        }
    }
}
