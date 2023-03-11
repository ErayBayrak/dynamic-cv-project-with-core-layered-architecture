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
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        
        AboutManager aboutManager = new AboutManager(new EfAboutRepo());
        ContactManager contactManager = new ContactManager(new EfContactRepo());
        public IActionResult Index()
        {
            var aboutValue = aboutManager.GetById(1);
            ViewBag.aboutImage = aboutValue.Image;
            return View();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }
        [HttpPost]
        public IActionResult SendMessage(Contact contact)
        {
            ContactValidator rules = new ContactValidator();
            ValidationResult result = rules.Validate(contact);
            if (result.IsValid)
            {
                contact.Tarih = DateTime.Now.ToShortDateString();
                contactManager.TInsert(contact);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var x in result.Errors)
                {

                    ModelState.AddModelError(x.PropertyName, x.ErrorMessage);
                }
            }
            return RedirectToAction("Index");
        }

    }
}
