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
    public class CertificateController : Controller
    {
        CertificateManager certificateManager = new CertificateManager(new EfCertificateRepo());
        public IActionResult Index()
        {
            var values = certificateManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddCertificate()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddCertificate(Certificate certificate)
        {
            CertificateValidator rules = new CertificateValidator();
            ValidationResult result = rules.Validate(certificate);
            if (result.IsValid)
            {
                certificate.CertificateStatus = true;
                certificateManager.TInsert(certificate);
                return RedirectToAction("Index", "Certificate");
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
        public IActionResult DeleteCertificate(int id)
        {
            var value = certificateManager.GetById(id);
            value.CertificateStatus = false;
            certificateManager.TUpdate(value);
            return RedirectToAction("Index", "Certificate");
        }
        [HttpGet]
        public IActionResult UpdateCertificate(int id)
        {
            var values = certificateManager.GetById(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateCertificate(Certificate certificate)
        {
            CertificateValidator rules = new CertificateValidator();
            ValidationResult result = rules.Validate(certificate);
            if (result.IsValid)
            {
                certificate.CertificateStatus = true;
                certificateManager.TUpdate(certificate);
                return RedirectToAction("Index", "Certificate");
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
