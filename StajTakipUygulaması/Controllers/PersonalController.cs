using DataAccessLayer.Concrete;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StajTakipUygulaması.Controllers
{
	
	public class PersonalController : Controller
	{
        //Personel sayfasına gönderilecek dinamik bilgilerin kodları 
        DataContext dc = new DataContext();

        [Authorize(Roles = "Personal,Admin")]
        public IActionResult PersonalMain()
		{

			var pernumber = dc.personals.Where(x => x.Rol == "Personal").Count();
			ViewBag.PersonalTotal = pernumber;

			var studnumber = dc.students.Count();
			ViewBag.StudentTotal = studnumber;
            
            var aktifstajyer = dc.stajBilgis.Select(x => x.StudentID).Distinct().Count();
            ViewBag.aktifstajyer = aktifstajyer;

            var dosya = dc.dosyas.Count();
            ViewBag.dosya = dosya;

            var donanimstaj = dc.stajBilgis.Where(x => x.StajTürü == "Donanım").Count();
            ViewBag.donanimtstaj = donanimstaj;

            var yazilimstaj = dc.stajBilgis.Where(x => x.StajTürü == "Yazılım").Count();
            ViewBag.yazilimstaj = yazilimstaj;

            var mastertstaj = dc.stajBilgis.Where(x => x.StajTürü == "İş yeri eğitimi").Count();
            ViewBag.masterstaj = mastertstaj;
            return View();
        }

        
        //Sıkça sorulan sorular sayfasının fonksiyonu
        public IActionResult SSS()
		{
			return View();
		}
    }
}
