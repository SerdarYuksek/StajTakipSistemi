using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace StajTakipUygulaması.Controllers
{
    public class User : Controller
    {
        //Depolardan service nesneleri ve veri tabanı nesnesi oluşturulması
        PersonalManager pm = new PersonalManager(new EfPersonalRepository());
        StudentManager sm = new StudentManager(new EfStudentRepository());
        DataContext dc = new DataContext();


        //Personelin kendi bilgilerini görüntülediği ve güncellediği fonksiyon(get)
        [Authorize(Roles = "Admin,Personal")]
        [HttpGet]
        public IActionResult PersonalUp()
        {
            var perid = pm.TGetById(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value));
            var bilgiler = dc.personals.FirstOrDefault(x => x.KullaniciID == perid.KullaniciID );
            return View(bilgiler);
        }

        //Personelin kendi bilgilerini görüntülediği ve güncellediği fonksiyon(post)
        [Authorize(Roles = "Admin,Personal")]
        [HttpPost]
        public IActionResult PersonalUp( Personal data, IFormFile ımage)
        {

            if (ımage!=null)//fotoğrafın değiştirilip değiştirilmeme kontrolü
            {
                PersonalUpdateValidator puv = new PersonalUpdateValidator();
                ValidationResult result = puv.Validate(data);

                if (result.IsValid)
                {
                    var user = dc.personals.Where(x => x.KullaniciID == data.KullaniciID).FirstOrDefault();
                    data.Image = ımage.FileName.ToString();

                    user.AdSoyad = data.AdSoyad;
                    user.TCNO = data.TCNO;
                    user.Mail = data.Mail;
                    user.Cinsiyet = data.Cinsiyet;
                    user.PersonalNo = data.PersonalNo;
                    user.Unvan = data.Unvan;
                    user.Image = data.Image;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/PersonalImageFile/{data.Image}");//dosyanın klasöre kaydedilmesi
                    using var stream = new FileStream(path, FileMode.Create);
                    ımage.CopyTo(stream);
                    pm.TUpdate(user);//yeni bilgilerin güncellenmesi
                    return RedirectToAction("PersonalUp");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else
            {
                PersonalUpdateValidator puv = new PersonalUpdateValidator();
                ValidationResult result = puv.Validate(data);

                if (result.IsValid)
                {
                  
                    var user = dc.personals.Where(x => x.KullaniciID == data.KullaniciID).FirstOrDefault();

                    user.AdSoyad = data.AdSoyad;
                    user.TCNO = data.TCNO;
                    user.Mail = data.Mail;
                    user.Cinsiyet = data.Cinsiyet;
                    user.PersonalNo = data.PersonalNo;
                    user.Unvan = data.Unvan;
                    user.Image = data.Image;
                    pm.TUpdate(user);
                    return RedirectToAction("PersonalUp");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            return View("PersonalUp", data);
        }

        //Öğrencinin kendi bilgilerini görüntülediği ve güncellediği fonksiyon
        [Authorize(Roles = "Admin,Student")]
        [HttpGet]
        public IActionResult StudentUp()
        {
            var sutid = sm.TGetById(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value));
            var bilgiler = dc.students.FirstOrDefault(x => x.KullaniciID == sutid.KullaniciID);
            return View(bilgiler);
        }

        //Personelin kendi bilgilerini görüntülediği ve güncellediği fonksiyon
        [Authorize(Roles = "Admin,Student")]
        [HttpPost]
        public IActionResult StudentUp(Student data, IFormFile ımage)
        {
            if (ımage!=null)//fotoğrafın değiştirilip değiştirilmeme kontrolü
            {
                StudentUpdateValidator suv = new StudentUpdateValidator();
                ValidationResult result = suv.Validate(data);

                if (result.IsValid)
                {
                    var user = dc.students.Where(x => x.KullaniciID == data.KullaniciID).FirstOrDefault();
                    data.Image = ımage.FileName.ToString();

                    user.AdSoyad = data.AdSoyad;
                    user.TCNO = data.TCNO;
                    user.Mail = data.Mail;
                    user.Cinsiyet = data.Cinsiyet;
                    user.OgrenciNo = data.OgrenciNo;
                    user.sınıf = data.sınıf;
                    user.Image = data.Image;
                    string path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/StudentImageFile/{data.Image}");//dosyanın klasöre kaydedilmesi
                    using var stream = new FileStream(path, FileMode.Create);
                    ımage.CopyTo(stream);
                    sm.TUpdate(user);//yeni bilgilerin güncellenmesi
                    return RedirectToAction("StudentUp");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            else
            {
                StudentUpdateValidator suv = new StudentUpdateValidator();
                ValidationResult result = suv.Validate(data);

                if (result.IsValid)
                {
                    var user = dc.students.Where(x => x.KullaniciID == data.KullaniciID).FirstOrDefault();

                    user.AdSoyad = data.AdSoyad;
                    user.TCNO = data.TCNO;
                    user.Mail = data.Mail;
                    user.Cinsiyet = data.Cinsiyet;
                    user.OgrenciNo = data.OgrenciNo;
                    user.sınıf = data.sınıf;
                    user.Image = data.Image;
                    sm.TUpdate(user);
                    return RedirectToAction("StudentUp");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                    }
                }
            }
            return View("StudentUp", data);
        }
    }
}
