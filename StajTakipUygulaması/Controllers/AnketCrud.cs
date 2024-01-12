using DataAccessLayer.Concrete;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;
using X.PagedList;

namespace StajTakipUygulaması.Controllers
{
    [AllowAnonymous]
    public class AnketCrud : Controller
    {
        DataContext dc = new DataContext();
        [HttpGet]
        public IActionResult AnketView(int page = 1)
        {
           
            var sorular = dc.ankets.ToList().ToPagedList(page, 10);
            return View(sorular);
        }

        [HttpPost]
        public IActionResult AnketView(Anket a)
        {
            dc.ankets.Add(a);
            dc.SaveChanges();
            return RedirectToAction("StudentMain", "Student");
        }
    }
}
 