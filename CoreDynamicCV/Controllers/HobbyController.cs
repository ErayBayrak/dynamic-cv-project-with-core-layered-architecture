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
    public class HobbyController : Controller
    {
        HobbyManager hobbyManager = new HobbyManager(new EfHobbyRepo());
        [HttpGet]
        public IActionResult Index()
        {
            var values = hobbyManager.GetList();
            return View(values);
        }
        [HttpPost]
        public IActionResult Index(Hobby hobby)
        {
            HobbyValidator rules = new HobbyValidator();
            ValidationResult result = rules.Validate(hobby);
            if (result.IsValid)
            {
                var value = hobbyManager.GetById(1);
                value.Description1 = hobby.Description1;
                value.Description2 = hobby.Description2;
                hobbyManager.TUpdate(value);
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
