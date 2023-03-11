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
    public class SocialMediaController : Controller
    {
        SocialMediaManager socialMediaManager = new SocialMediaManager(new EfSocialMediaRepo());
        public IActionResult Index()
        {
            var values = socialMediaManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddSocialMedia(SocialMedia socialMedia)
        {
            socialMedia.SocialMediaStatus = true;
            socialMediaManager.TInsert(socialMedia);
            return RedirectToAction("Index", "SocialMedia");
        }
        public IActionResult DeleteSocialMedia(int id)
        {
            var value = socialMediaManager.GetById(id);
            //value.SocialMediaStatus = false;
            if (value.SocialMediaStatus == true)
            {
                value.SocialMediaStatus = false;
            }else if(value.SocialMediaStatus == false)
            {
                value.SocialMediaStatus = true;
            }
            socialMediaManager.TUpdate(value);
            return RedirectToAction("Index","SocialMedia");
        }
        [HttpGet]
        public IActionResult UpdateSocialMedia(int id)
        {
            var values = socialMediaManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateSocialMedia(SocialMedia socialMedia)
        {
            socialMedia.SocialMediaStatus = true;
            socialMediaManager.TUpdate(socialMedia);
            return RedirectToAction("Index", "SocialMedia");
        }
        
    }
}
