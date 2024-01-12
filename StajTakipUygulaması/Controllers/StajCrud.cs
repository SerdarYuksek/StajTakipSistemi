using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StajTakipUygulaması.Controllers
{

    public class StajCrud : Controller
    {
        PersonalManager pm = new PersonalManager(new EfPersonalRepository());
        DataContext dc = new DataContext();

        [HttpGet]
        public IActionResult CreateIntern()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateIntern(StajBilgi s) //Staj Başvuru Fpnksiyonu
        {
            InternAddValidator ıav = new InternAddValidator();
            ValidationResult result = ıav.Validate(s);

            if (result.IsValid)// Validasyon Kontrolü
            {
                var ogrenci = dc.students.FirstOrDefault(x => x.AdSoyad == User.Identity.Name);
                s.StudentID = ogrenci.KullaniciID;
                s.Başlamatrh = new DateTime(s.Başlamatrh.Year, s.Başlamatrh.Month, s.Başlamatrh.Day);
                s.Bitistrh = new DateTime(s.Bitistrh.Year, s.Bitistrh.Month, s.Bitistrh.Day);
                dc.stajBilgis.Add(s);
                dc.SaveChanges();
                return RedirectToAction("StudentMain", "Student");
            }
            else
            {
                foreach (var item in result.Errors) //Validation yanlış sonuç verirse hata mesajı yazdırılması kodu
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View("CreateIntern", s);
        }

        public IActionResult ListIntern()
        {
                var ogrenci = dc.students.FirstOrDefault(x => x.AdSoyad == User.Identity.Name);
                var intern = dc.stajBilgis.Where(x => x.StudentID == ogrenci.KullaniciID).ToList();
                return View(intern);
              
        }

        public IActionResult ListInternInfo(int id)
        {
            var ogrenci = dc.students.FirstOrDefault(x => x.AdSoyad == User.Identity.Name);
            var intern = dc.stajBilgis.Where(x => x.StudentID == ogrenci.KullaniciID && x.StajBilgiID==id).ToList();
            return View(intern);
        }

        public IActionResult InternDel(StajBilgi s)
        {
            var stajId = pm.TGetById(s.StajBilgiID);
            pm.TDelete(stajId);
            return RedirectToAction("ListIntern");
        }
        public IActionResult ListInternFile(int id)
        {
            ViewBag.stajid = id;
            return View();
        }
        public IActionResult ListStudentIntern(int id)
        {
            var intern = dc.stajBilgis.Where(x => x.StudentID == id).ToList();
            return View(intern);

        }
        public IActionResult Basvuruonay(int id)
        {
            var staj = dc.stajBilgis.Where(s => s.StudentID == id).FirstOrDefault();
            staj.Onay = true;
            dc.SaveChanges();
            return RedirectToAction("StudentList","UsersCrud");

        }
        public IActionResult StajKabul(int id)
        {
            var staj = dc.stajBilgis.Where(s => s.StudentID == id).FirstOrDefault();
            staj.Kabul = true;
            dc.SaveChanges();
            return RedirectToAction("StudentList", "UsersCrud");

        }
    }
}
