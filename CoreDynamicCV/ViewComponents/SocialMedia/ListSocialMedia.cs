using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDynamicCV.ViewComponents.SocialMedia
{
    public class ListSocialMedia:ViewComponent
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaRepo());
        public IViewComponentResult Invoke()
        {
            var values = socialMediaManager.GetList();
            return View(values);
        }
    }
}
