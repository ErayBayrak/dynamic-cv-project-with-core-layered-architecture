using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDynamicCV.ViewComponents.Experience
{
    public class ListExperience : ViewComponent
    {
        ExperienceManager experienceManager = new ExperienceManager(new EfExperienceRepo());
        public IViewComponentResult Invoke()
        {
            var values = experienceManager.GetList();
            return View(values);
        }
    }
}
