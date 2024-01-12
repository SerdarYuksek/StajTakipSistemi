using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StajTakipUygulaması.Controllers
{
	[Authorize(Roles ="Admin")]
	public class Admin : Controller
	{
        //Admin sayfasına gönderilecek dinemik bilgilerin kodları 
        DataContext dc = new DataContext();
        public IActionResult AdminMain()
		{
            var pernumber = dc.personals.Where(x => x.Rol == "Personal").Count();
            ViewBag.PersonalTotal = pernumber;

            var studnumber = dc.students.Count();
            ViewBag.StudentTotal = studnumber;

            var frststudnumber = dc.students.Where(x=>x.sınıf=="1.sınıf").Count();
            ViewBag.fırstStudentTotal = frststudnumber;

            var scndstudnumber = dc.students.Where(x => x.sınıf == "2.sınıf").Count();
            ViewBag.scndStudentTotal = scndstudnumber;

            var thrtstudnumber = dc.students.Where(x => x.sınıf == "3.sınıf").Count();
            ViewBag.thrtStudentTotal = thrtstudnumber;

            var fourstudnumber = dc.students.Where(x => x.sınıf == "4.sınıf").Count();
            ViewBag.fourStudentTotal = fourstudnumber;

            var degrestudnumber = dc.students.Where(x => x.sınıf == "YüksekLisans").Count();
            ViewBag.degreStudentTotal = degrestudnumber;

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
        
    }
}
