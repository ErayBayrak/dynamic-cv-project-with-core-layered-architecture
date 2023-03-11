using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDynamicCV.ViewComponents.Certificate
{
    public class ListCertificate:ViewComponent
    {
        CertificateManager certificateManager = new CertificateManager(new EfCertificateRepo());
        public IViewComponentResult Invoke()
        {
            var values = certificateManager.GetList();
            return View(values);
        }
    }
}
