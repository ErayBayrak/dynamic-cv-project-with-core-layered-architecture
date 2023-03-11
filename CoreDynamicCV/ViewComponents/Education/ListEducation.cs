using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDynamicCV.ViewComponents.Education
{
    public class ListEducation : ViewComponent
    {
        EducationManager educationManager = new EducationManager(new EfEducationRepo());
        public IViewComponentResult Invoke()
        {
            var values = educationManager.GetList();
            return View(values);
        }
    }
}
