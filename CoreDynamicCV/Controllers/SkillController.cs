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
    public class SkillController : Controller
    {
        SkillManager skillManager = new SkillManager(new EfSkillRepo());

        public IActionResult Index()
        {
            var values = skillManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            SkillValidator rules = new SkillValidator();
            ValidationResult result = rules.Validate(skill);
            if (result.IsValid)
            {
                skill.RateStatus = true;
                skillManager.TInsert(skill);
                return RedirectToAction("Index", "Skill");
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
        public IActionResult DeleteSkill(int id)
        {
            var value = skillManager.GetById(id);
            value.RateStatus = false;
            skillManager.TUpdate(value);
            return RedirectToAction("Index","Skill");
        }
        [HttpGet]
        public IActionResult UpdateSkill(int id)
        {
            var value = skillManager.GetById(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateSkill(Skill skill)
        {
            SkillValidator rules = new SkillValidator();
            ValidationResult result = rules.Validate(skill);
            if (result.IsValid)
            {
                skill.RateStatus = true;
                skillManager.TUpdate(skill);
                return RedirectToAction("Index", "Skill");
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
