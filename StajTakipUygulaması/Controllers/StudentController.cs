using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace StajTakipUygulaması.Controllers
{
	[Authorize(Roles = "Student,Admin")]

	//Öğrenci sayfasının fonksiyonu
	public class StudentController : Controller
	{
		DataContext dc = new DataContext();
        public IActionResult StudentMain()
        {
            var ogrenci = dc.students.FirstOrDefault(x => x.AdSoyad == User.Identity.Name);

            var fırststaj = dc.stajBilgis.Where(x => x.stajsayi == 1 && x.StudentID == ogrenci.KullaniciID).Select(x => x.KabulGün).FirstOrDefault();
            ViewBag.firststaj = fırststaj;

            var sectstaj = dc.stajBilgis.Where(x => x.stajsayi == 2 && x.StudentID == ogrenci.KullaniciID).Select(x => x.KabulGün).FirstOrDefault();
            ViewBag.secstaj = sectstaj;

            var masterstaj = dc.stajBilgis.Where(x => x.stajsayi == 3 && x.StudentID == ogrenci.KullaniciID).Select(x => x.KabulGün).FirstOrDefault();
            ViewBag.masterstaj = masterstaj;

            var fırstname = dc.stajBilgis.Where(x => x.stajsayi == 1 && x.StudentID == ogrenci.KullaniciID).Select(x => x.StajTürü).FirstOrDefault();
            ViewBag.firstname = fırstname;

            var secname = dc.stajBilgis.Where(x => x.stajsayi == 2 && x.StudentID == ogrenci.KullaniciID).Select(x => x.StajTürü).FirstOrDefault();
            ViewBag.secname = secname;


            return View();
        }

    }
}
