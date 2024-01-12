using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;



namespace StajTakipUygulaması.Controllers
{
	[AllowAnonymous]
	public class Account : Controller
	{
		//Depolardan service nesneleri ve veri tabanı nesnesi oluşturulması
		EPostaService postaservice = new EPostaService();
        PersonalManager pm = new PersonalManager(new EfPersonalRepository());
        StudentManager sm = new StudentManager(new EfStudentRepository());
        DataContext dc = new DataContext();
		
        [HttpGet]
		public IActionResult PersonalLog()
		{
			return View();
		}

		//Personel İçin Sisteme Giriş Kodları
		[HttpPost]
		public async Task<IActionResult> PersonalLog(Personal p) //Sisteme Giriş Fonksiyonu

		{
			PersonalGirisValidator pgv = new PersonalGirisValidator();
			ValidationResult result = pgv.Validate(p);
			if (result.IsValid)  //Validasyon kontrolü
			{
				var bilgiler = dc.personals.FirstOrDefault(x => x.TCNO == p.TCNO && x.Password == p.Password);

				if (bilgiler != null)  //Giriş Doğruluk kontrolü
				{
					var Claims = new List<Claim>
					{
					new Claim(ClaimTypes.Name,bilgiler.AdSoyad),
					new Claim(ClaimTypes.Role,bilgiler.Rol),
                    new Claim(ClaimTypes.NameIdentifier, bilgiler.KullaniciID.ToString())
                    };

					// Role Göre İlgili Sayfaya Yönlendirme
					if (bilgiler.Rol == "Admin")
					{
						var useridentity = new ClaimsIdentity(Claims, "a");
						ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
						await HttpContext.SignInAsync(principal);
						return RedirectToAction("AdminMain", "Admin");
					}
					else if (bilgiler.Rol == "Personal")
					{
						var useridentity = new ClaimsIdentity(Claims, "b");
						ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
						await HttpContext.SignInAsync(principal);
						return RedirectToAction("PersonalMain", "Personal");
					}

				}
				else
				{
					foreach (var item in result.Errors) //Validation yanlış socuç verirse hata mesajı yazdırılması kodu
					{
						ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
					}
				}
				}
			ViewBag.hata = "TCNO veya Şifreniz hatalıdır";
			return View();
		}

	
		//Öğrenci İçin Sisteme Giriş Kodları
		[HttpGet]
		public IActionResult StudentLog()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> StudentLog(Student s) //Sisteme Giriş Fonksiyonu

		{
			StudentGirisValidator sgv = new StudentGirisValidator();
			ValidationResult result = sgv.Validate(s);

			if (result.IsValid)  //Validasyon kontrolü
				{
				var bilgiler = dc.students.FirstOrDefault(x => x.TCNO == s.TCNO && x.Password == s.Password);
				if (bilgiler != null)  //Giriş Doğruluk kontrolü
				{
					var Claims = new List<Claim>
					{
					new Claim(ClaimTypes.Name,bilgiler.AdSoyad),
					new Claim(ClaimTypes.Role, bilgiler.Rol),
                    new Claim(ClaimTypes.NameIdentifier, bilgiler.KullaniciID.ToString())
                    };

						// Role Göre İlgili Sayfaya Yönlendirme
					if (bilgiler.Rol == "Student")
					{
							var useridentity = new ClaimsIdentity(Claims, "a");
							ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
							await HttpContext.SignInAsync(principal);
							return RedirectToAction("StudentMain", "Student");
					}
				}
			}
			else
			{
				foreach (var item in result.Errors) //Validation yanlış socuç verirse hata mesajı yazdırılması kodu
                {
						ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			ViewBag.hata = "TCNO veya Şifreniz hatalıdır";
			return View();
		}

		//Sistemden Çıkış Fonksiyonu
		[HttpGet]
		public async Task<IActionResult> LogOut()  
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
			return RedirectToAction("Main", "Home");
		}

		
		//Öğrenci Kayıt Fonksiyonu
		[HttpGet]
		public IActionResult StudentReg()
		{
			return View();
		}

		[HttpPost]
		public IActionResult StudentReg(Student s, IFormFile Image)
		{
			s.Image = Image.FileName.ToString();
			StudentRegValidator sgv = new StudentRegValidator();
			ValidationResult result = sgv.Validate(s);

			if (result.IsValid)
			{
				dc.students.Add(s);
				s.Rol = "Student";
				dc.SaveChanges();
                var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/StudentImageFile/{s.Image}");
                var stream = new FileStream(path, FileMode.Create);
                Image.CopyTo(stream);
                return RedirectToAction("Main","Home");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View("StudentReg", s);
		}

		
		//Personel Kayıt Fonksiyonu
		[HttpGet]
		public IActionResult PersonalReg()
		{
			return View();
		}

		[HttpPost]
		public IActionResult PersonalReg(Personal p, IFormFile Image)
		{
			p.Image = Image.FileName.ToString();
			PersonalRegValidator prv = new PersonalRegValidator();
			ValidationResult result = prv.Validate(p);

			if (result.IsValid)
			{
				dc.personals.Add(p);
				p.Rol = "Personal";
				dc.SaveChanges();
				var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/PersonalImageFile/{p.Image}");
				var stream = new FileStream(path, FileMode.Create);
				Image.CopyTo(stream);
				return RedirectToAction("Main", "Home");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View("PersonalReg", p);
		}

		//Şifremi Unuttum Fonksiyonu Kodları
		[HttpGet]
		public IActionResult MailConfirm()
		{
			return View();
		}
		[HttpPost]
		public IActionResult MailConfirm(string email)
		{
			var personal = dc.personals.FirstOrDefault(x => x.Mail == email);
			var student  = dc.students.FirstOrDefault(x => x.Mail == email);

			if (personal !=null)
			{
				postaservice.EPostaGonder(new EPostaBilgi
				{
					AlıcıAdres = personal.Mail,
					Link = "https://localhost:44383/Account/PersonalPasswordReset"
                });
                ViewBag.bilgi = "Lütfen Mail Adresinize Gelen Bağlantı Adresi İle İşleminizi Gerçekleştiriniz.";
                return View("MailConfirm", personal.Mail);
				
			}
			else if (student !=null)
			{
                postaservice.EPostaGonder(new EPostaBilgi
                {
                    AlıcıAdres = student.Mail,
                    Link = "https://localhost:44383/Account/StudentPasswordReset"
                });
                ViewBag.bilgi = "Lütfen Mail Adresinize Gelen Bağlantı Adresi İle İşleminizi Gerçekleştiriniz.";
                return View("MailConfirm", student.Mail);
            }
			else
			{
                ViewBag.bos = "Girdiğiniz Mail Eksik veya Hatalı.";
            }
			return View();
		}

		//Personel Şifre sıfırlama fonksiyonu kodları
		[HttpGet]
        public IActionResult PersonalPasswordReset()
        {
            return View();
        }

        [HttpPost]
		public IActionResult PersonalPasswordReset(Personal p)
		{
            PersonalPasswordValidator ppv = new PersonalPasswordValidator();
            ValidationResult result = ppv.Validate(p);

            if (result.IsValid)
            {
                var x = dc.personals.FirstOrDefault(x => x.TCNO == p.TCNO); 
                x.Password = p.Password;
                x.RePassword = p.RePassword;
                pm.TUpdate(x);
                return RedirectToAction("PersonalLog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View("PersonalPasswordReset",p);

		}

		//öğrenci şifre sıfırlama fonksiyonu kodları
        [HttpGet]
        public IActionResult StudentPasswordReset()
        {

            return View();

        }

        public IActionResult StudentPasswordReset(Student s)
        {
            StudentPasswordValidator spv = new StudentPasswordValidator();
            ValidationResult result = spv.Validate(s);

            if (result.IsValid)
            {
                var x = dc.students.FirstOrDefault(x => x.TCNO == s.TCNO);
                x.Password = s.Password;
                x.RePassword = s.RePassword;
                sm.TUpdate(x);
                return RedirectToAction("StudentLog");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View("StudentPasswordReset", s);

        }
    }
}
