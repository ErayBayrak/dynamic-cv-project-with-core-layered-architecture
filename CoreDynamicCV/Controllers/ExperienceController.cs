using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
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
    public class ExperienceController : Controller
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceRepo());
       
        public IActionResult Index()
        {
            var values = experienceManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddExperience()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddExperience(Experience experience)
        {
            ExperienceValidator rules = new ExperienceValidator();
            ValidationResult result = rules.Validate(experience);
            if (result.IsValid)
            {
                experienceManager.TInsert(experience);
                return RedirectToAction("Index","Experience");
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
        public IActionResult DeleteExperience(int id)
        {
            var value = experienceManager.GetById(id);
            value.ExperienceStatus = false;
            experienceManager.TUpdate(value);
            return RedirectToAction("Index","Experience");
        }
        [HttpGet]
        public IActionResult UpdateExperience(int id)
        {
            var value = experienceManager.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateExperience(Experience experience)
        {
            ExperienceValidator rules = new ExperienceValidator();
            ValidationResult result = rules.Validate(experience);
            if (result.IsValid)
            {
                experience.ExperienceStatus = true;
                experienceManager.TUpdate(experience);
                return RedirectToAction("Index", "Experience");
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
