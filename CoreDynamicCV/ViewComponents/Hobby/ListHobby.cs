using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDynamicCV.ViewComponents.Hobby
{
    public class ListHobby:ViewComponent
    {
        HobbyManager hobbyManager = new HobbyManager(new EfHobbyRepo());
        public IViewComponentResult Invoke()
        {
            var values = hobbyManager.GetList();
            return View(values);
        }
    }
}
