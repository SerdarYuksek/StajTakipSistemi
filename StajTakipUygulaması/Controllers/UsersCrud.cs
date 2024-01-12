using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using X.PagedList;


namespace StajTakipUygulaması.Controllers
{
 
	public class UsersCrud : Controller
    {
        //Depolardan service nesneleri ve veri tabanı nesnesi oluşturulması
        PersonalManager pm = new PersonalManager(new EfPersonalRepository());
        StudentManager sm = new StudentManager(new EfStudentRepository());
        DataContext dc = new DataContext();

		[Authorize(Roles = "Admin")]
		//Personel Listeleme Fonksiyonu
		public IActionResult PersonalList(int page = 1)
        {
            var personal = dc.personals.Where(x => x.Rol == "Personal").ToList().ToPagedList(page,5);
            return View(personal);
        }

		[Authorize(Roles = "Admin,Personal")]
        //Öğrenci Listeleme Fonksiyonu
        public IActionResult StudentList(string classname, string studentStatus, int page = 1)
        {
            var students = dc.students.Include(s => s.StajBilgis).ToList().Distinct();

            if (!string.IsNullOrEmpty(classname))
            {
                students = students.Where(s => s.sınıf == classname).ToList();
            }

            if (studentStatus != null)
            {
                
             

                students = dc.students.Include(s=> s.StajBilgis).Where(s =>
                    (studentStatus == "onay" && s.StajBilgis.All(s=> s.Onay) == false ) ||
                    (studentStatus == "kabul" && s.StajBilgis.All(s => s.Kabul) == false)
                ).ToList().Distinct();
            }

            var pageNumber = page < 1 ? 1 : page;
            var pageSize = 5;

            var pagedStudents = students.ToPagedList(pageNumber, pageSize);

            return View(pagedStudents);

        }

        //Personel Silme Fonksiyonu
        public IActionResult PersonalDel(Personal P)
        {
            var personalId = pm.TGetById(P.KullaniciID);
            pm.TDelete(personalId);
            return RedirectToAction("PersonalList");
        }

        //Öğrenci Silme Fonksiyonu
        public IActionResult StudentDel(Student s)
        {
            var StudentId = sm.TGetById(s.KullaniciID);
            sm.TDelete(StudentId);
            return RedirectToAction("StudentList");
        }

        //Personel bilgilerinin yetkili tarafından güncellenmesi fonksiyonu(get)
        [Authorize(Roles = "Admin")]
		[HttpGet]
        public IActionResult PersonalUpdate(int id)
        {
            var x = pm.TGetById(id);
            return View(x);
        }

        //Personel bilgilerinin yetkili tarafından güncellenmesi fonksiyonu(post)
        [Authorize(Roles = "Admin")]
		[HttpPost]
        public IActionResult PersonalUpdate(Personal p, IFormFile Image)
        {
			p.Image = Image.FileName.ToString();
			PersonalUpdateValidator puv = new PersonalUpdateValidator();
            ValidationResult result = puv.Validate(p);

            if (result.IsValid)
            {
                var x = pm.TGetById(p.KullaniciID);
                x.AdSoyad = p.AdSoyad;
                x.TCNO = p.TCNO;
                x.Mail = p.Mail;
                x.Cinsiyet = p.Cinsiyet;
                x.PersonalNo = p.PersonalNo;
                x.Unvan = p.Unvan;
                x.Image = p.Image;
				string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/PersonalImageFile/{p.Image}");
				using var stream = new FileStream(path, FileMode.Create);
				Image.CopyTo(stream);
				pm.TUpdate(x);
                return RedirectToAction("PersonalList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View("PersonalUpdate", p );
        }

        //Öğrenci bilgilerinin yetkili tarafından güncellenmesi fonksiyonu(get)
        [Authorize(Roles = "Admin,Personal")]
		[HttpGet]
		public IActionResult StudentUpdate(int id)
		{
			var x = sm.TGetById(id);
			return View(x);
		}

        //Öğrenci bilgilerinin yetkili tarafından güncellenmesi fonksiyonu(post)
        [Authorize(Roles = "Admin,Personal")]
		[HttpPost]
		public IActionResult StudentUpdate(Student s, IFormFile Image)
        {
			s.Image = Image.FileName.ToString();
			StudentUpdateValidator suv = new StudentUpdateValidator();
            ValidationResult result = suv.Validate(s);

            if (result.IsValid)
            {
                var x = sm.TGetById(s.KullaniciID);
                x.AdSoyad = s.AdSoyad;
                x.TCNO = s.TCNO;
                x.Cinsiyet = s.Cinsiyet;
                x.Mail = s.Mail;
                x.OgrenciNo = s.OgrenciNo;
                x.Image = s.Image;
                x.sınıf = s.sınıf;
				string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/StudentImageFile/{s.Image}");
				using var stream = new FileStream(path, FileMode.Create);
				Image.CopyTo(stream);
				sm.TUpdate(x);
                return RedirectToAction("StudentList");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View("StudentUpdate", s);
        }
        [AllowAnonymous]
        public IActionResult StudentFile(int studentid, int stajid)
        {
            var kontrol =  dc.dosyas.Any(d=> d.StudentID == studentid && d.StajId == stajid);
            ViewBag.onaykontrol = dc.stajBilgis.Include(s => s.dosyas.Where(d=>d.StajId == stajid && d.StudentID == studentid)).Any(s=> s.Onay);
            ViewBag.kabulkontrol = dc.stajBilgis.Include(s => s.dosyas.Where(d => d.StajId == stajid && d.StudentID == studentid)).Any(s => s.Kabul);
            if (kontrol == true)
            {
                var dosya = dc.dosyas.Where(d => d.StudentID == studentid && d.StajId == stajid).ToList();
                return View(dosya);
            }
            else
            {
                ViewBag.Kayıt = "Öğrencinin Dosya Kaydı Bulunmamaktadır!";
                var dosya = dc.dosyas.Where(d => d.StudentID == studentid && d.StajId == stajid).ToList();
                return View(dosya);          
            }
             
        }
    }
}
