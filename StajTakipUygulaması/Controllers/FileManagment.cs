using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace StajTakipUygulaması.Controllers
{
   
    public class FileManagment : Controller
	{

        StudentManager sm = new StudentManager(new EfStudentRepository());

        //Veri tabanı nesnesi ve dosya görüntüleme servicesinin tanımlanması
        DataContext dc = new DataContext();
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileManagment(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        [Authorize(Roles = "Admin,Personal")]
        //Dosya Yükleme Fonksiyonunun kodları
        [HttpGet]
		public IActionResult FileUpload()
		{
            
            return View();
        }

        [Authorize(Roles = "Admin,Personal")]
        [HttpPost]
		public IActionResult FileUpload(Dosya d,int dosyaid, string submit, IFormFile Akissemasi, IFormFile degerledirmedok, IFormFile yonerge, IFormFile basvuru, IFormFile devam, IFormFile degerlendirmeform, IFormFile raporsablon)
		{

 
            if (Akissemasi != null)
			{
				d.Akissemasi = Akissemasi.FileName.ToString();
				dc.dosyas.Add(d);
				dc.SaveChanges();
				var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/StajDosyalar/{d.Akissemasi}");
				var stream = new FileStream(path, FileMode.Create);
				Akissemasi.CopyTo(stream);

              
            }
			else if (degerledirmedok != null)
			{
				d.degerledirmedok = degerledirmedok.FileName.ToString();
				dc.dosyas.Add(d);
				dc.SaveChanges();
				var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/StajDosyalar/{d.degerledirmedok}");
				var stream = new FileStream(path, FileMode.Create);
				degerledirmedok.CopyTo(stream);

                if (submit == "Görüntüle")
                {
                    return RedirectToAction("FilePdfShow", new { dosyaAdi = degerledirmedok });
                }
            }
			else if (yonerge != null)
			{
				d.yonerge = yonerge.FileName.ToString();
				dc.dosyas.Add(d);
				dc.SaveChanges();
				var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/StajDosyalar/{d.yonerge}");
				var stream = new FileStream(path, FileMode.Create);
				yonerge.CopyTo(stream);

                if (submit == "Görüntüle")
                {
                    return RedirectToAction("FilePdfShow", new { dosyaAdi = yonerge });
                }
            }
			else if (basvuru != null)
			{
				d.basvuru = basvuru.FileName.ToString();
				dc.dosyas.Add(d);
				dc.SaveChanges();
				var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/StajDosyalar/{d.basvuru}");
				var stream = new FileStream(path, FileMode.Create);
				basvuru.CopyTo(stream);

                if (submit == "Görüntüle")
                {
                    return RedirectToAction("FileWordShow", new { dosyaAdi = basvuru });
                }
            }
			else if (devam != null)
			{
				d.devam = devam.FileName.ToString();
				dc.dosyas.Add(d);
				dc.SaveChanges();
				var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/StajDosyalar/{d.devam}");
				var stream = new FileStream(path, FileMode.Create);
				devam.CopyTo(stream);

                if (submit == "Görüntüle")
                {
                    return RedirectToAction("FileWordShow", new { dosyaAdi = devam });
                }
            }
			else if (degerlendirmeform != null)
			{
				d.degerlendirmeform = degerlendirmeform.FileName.ToString();
				dc.dosyas.Add(d);
				dc.SaveChanges();
				var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/StajDosyalar/{d.degerlendirmeform}");
				var stream = new FileStream(path, FileMode.Create);
				degerlendirmeform.CopyTo(stream);

                if (submit == "Görüntüle")
                {
                    return RedirectToAction("FileWordShow", new { dosyaAdi = degerledirmedok });
                }
            }
			else if (raporsablon != null)
			{
				d.raporsablon = raporsablon.FileName.ToString();
				dc.dosyas.Add(d);
				dc.SaveChanges();
				var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/StajDosyalar/{d.raporsablon}");
				var stream = new FileStream(path, FileMode.Create);
				raporsablon.CopyTo(stream);

                if (submit == "Görüntüle")
                {
                    return RedirectToAction("FileWordShow", new { dosyaAdi = raporsablon });
                }
            }

			return View();
		}

        [Authorize(Roles = "Admin,Personal,Student")]
        //Dosya Yükleme Fonksiyonunun kodları
        [HttpGet]
        public IActionResult StudentFileUpload()
        {
            return View();
        }

        [Authorize(Roles = "Admin,Personal,Student")]
        [HttpPost]
        public IActionResult StudentFileUpload(Dosya d, int stajid, string submit, IFormFile basvuru, IFormFile raporsablon)
        {
            var sutid = sm.TGetById(int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value));
          
            if (basvuru != null)
            {
                d.basvuru = basvuru.FileName.ToString();
                d.StudentID = sutid.KullaniciID;
                d.StajId = stajid;
                dc.dosyas.Add(d);
                dc.SaveChanges();
                var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/StajDosyalar/{d.basvuru}");
                var stream = new FileStream(path, FileMode.Create);
                basvuru.CopyTo(stream);

                if (submit == "Görüntüle")
                {
                    return RedirectToAction("FileWordShow", new { dosyaAdi = basvuru });
                }
            }
            else if (raporsablon != null)
            {
                d.raporsablon = raporsablon.FileName.ToString();
                d.StudentID = sutid.KullaniciID;
                d.StajId = stajid;
                dc.dosyas.Add(d);
                dc.SaveChanges();
                var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/StajDosyalar/{d.raporsablon}");
                var stream = new FileStream(path, FileMode.Create);
                raporsablon.CopyTo(stream);

                if (submit == "Görüntüle")
                {
                    return RedirectToAction("FileWordShow", new { dosyaAdi = raporsablon });
                }
            }

            return RedirectToAction("ListInternFile", "StajCrud");
        }

        //Word Dosyalarının gösterimi fonksiyonu
        public IActionResult FilewWordShow(string dosyaAdi)
		{
            var dosyaYolu = Path.Combine(_webHostEnvironment.WebRootPath, "StajDosyalar", dosyaAdi);
            if (System.IO.File.Exists(dosyaYolu))
            {
                var dosyaBytes = System.IO.File.ReadAllBytes(dosyaYolu);
                return File(dosyaBytes, "application/vnd.openxmlformats-officedocument.wordprocessingml.document"); // Word belgesi olduğu için MIME türü "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
            }

            return View();
		}

        //Pdf Dosyalarının gösterimi fonksiyonu
        public IActionResult FilewPdfShow(string dosyaAdi)
        {
            var dosyaYolu = Path.Combine(_webHostEnvironment.WebRootPath, "StajDosyalar", dosyaAdi);
            if (System.IO.File.Exists(dosyaYolu))
            {
                var dosyaBytes = System.IO.File.ReadAllBytes(dosyaYolu);
                return File(dosyaBytes, "application/pdf"); // Pdf belgesi olduğu için MIME türü "application/pdf"
            }

            return View();
        }
    }
}