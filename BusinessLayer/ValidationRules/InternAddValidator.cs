using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class InternAddValidator : AbstractValidator<StajBilgi>
    {
        public InternAddValidator()
        {
            RuleFor(x => x.AdUnvan).NotEmpty().WithMessage("Firma Adı Boş Geçilemez!");
            RuleFor(x => x.Adres).NotEmpty().WithMessage("Firma Adres Boş Geçilemez!");
            RuleFor(x => x.Alanı).NotEmpty().WithMessage("Firma Alanı Boş Geçilemez!");
            RuleFor(x => x.YetkiliAd).NotEmpty().WithMessage("Firma Yetkili Adı Boş Geçilemez!");
            RuleFor(x => x.TelNo).NotEmpty().WithMessage("Firma Telefon No Boş Geçilemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Firma Mail Boş Geçilemez!");
            RuleFor(x => x.FaksNo).NotEmpty().WithMessage("Firma Farks No Boş Geçilemez!");
            RuleFor(x => x.WebSite).NotEmpty().WithMessage("Firma Website Boş Geçilemez!");
            RuleFor(x => x.Başlamatrh).NotEmpty().WithMessage("Lütfen Bir Tarih Seçiniz!");
            RuleFor(x => x.Bitistrh).NotEmpty().WithMessage("Lütfen Bir Tarih Seçiniz!");

            RuleFor(x => x.AdUnvan).MaximumLength(30).WithMessage("Maximum Karakter Sınırı 30!");
            RuleFor(x => x.AdUnvan).MinimumLength(5).WithMessage("Mininmum Karakter Sınırı 5!");

            RuleFor(x => x.Adres).MaximumLength(50).WithMessage("Maximum Karakter Sınırı 50!");
            RuleFor(x => x.Adres).MinimumLength(5).WithMessage("Mininmum Karakter Sınırı 5!");

            RuleFor(x => x.Alanı).MaximumLength(15).WithMessage("Maximum Karakter Sınırı 15!");
            RuleFor(x => x.Alanı).MinimumLength(5).WithMessage("Minimum Karakter Sınırı 5!");

            RuleFor(x => x.YetkiliAd).MaximumLength(20).WithMessage("Maximum Karakter Sınırı 20!");
            RuleFor(x => x.YetkiliAd).MinimumLength(5).WithMessage("Minimum Karakter Sınırı 5!");

            RuleFor(x => x.TelNo).MaximumLength(20).WithMessage("Telefon No 11 rakamdan oluşmalıdır!");
            RuleFor(x => x.TelNo).MinimumLength(5).WithMessage("Telefon No 11 rakamdan oluşmalıdır!");
            RuleFor(x => x.TelNo).Matches("^[0-9]*$").WithMessage("Telefon No sadece rakamlardan oluşmalıdır");

            RuleFor(x => x.FaksNo).MaximumLength(15).WithMessage("Maximum Rakam Sınırı 15!");
            RuleFor(x => x.FaksNo).MinimumLength(4).WithMessage("Mininmum  Sınırı 4!");
            RuleFor(x => x.FaksNo).Matches("^[0-9]*$").WithMessage("Faks No sadece rakamlardan oluşmalıdır");

            RuleFor(x => x.WebSite).MaximumLength(50).WithMessage("Maximum Karakter Sınırı 50!");
            RuleFor(x => x.WebSite).MinimumLength(10).WithMessage("Mininmum Karakter Sınırı 10!");

            RuleFor(x => x.stajsayi).Must(sayi => sayi == 1 || sayi == 2 || sayi == 3).WithMessage("Lütfen Bir Seçenek Seçiniz!");
            RuleFor(x => x.stajsayi).NotNull().WithMessage("Lütfen Bir Seçeneği İşaretleyin!");

            RuleFor(x => x.StajTürü).Must(türü => türü == "Donanım" || türü == "Yazılım" || türü == "İş yeri eğitimi").WithMessage("Lütfen Bir Tür Seçiniz!");
            RuleFor(x => x.StajTürü).NotNull().WithMessage("Lütfen Bir Seçeneği İşaretleyin!");

            RuleFor(x => x.ResmiTatil).Must(resmi => resmi == true || resmi == false ).WithMessage("Lütfen Bir Seçeneği İşaretleyin!");
            RuleFor(x => x.ResmiTatil).NotNull().WithMessage("Lütfen Bir Seçeneği İşaretleyin!");

            RuleFor(x => x.CmtDahil).Must(cmt => cmt == true || cmt == false).WithMessage("Lütfen Bir Seçeneği İşaretleyin!");
            RuleFor(x => x.CmtDahil).NotNull().WithMessage("Lütfen Bir Seçeneği İşaretleyin!");

            RuleFor(x => x.Egitim).Must(egitim => egitim == true || egitim == false).WithMessage("Lütfen Bir Seçeneği İşaretleyin!");
            RuleFor(x => x.Egitim).NotNull().WithMessage("Lütfen Bir Seçeneği İşaretleyin!");

        }
    }
}
