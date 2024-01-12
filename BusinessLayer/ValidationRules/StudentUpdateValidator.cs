using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class StudentUpdateValidator : AbstractValidator<Student>
	{
        //Personel Bilgi için gerekli kurallar
        public StudentUpdateValidator()
        {
			RuleFor(x => x.AdSoyad).NotEmpty().WithMessage("Ad Soyad Boş Geçilemez!");
			RuleFor(x => x.TCNO).NotEmpty().WithMessage("TC Kimlik Numarası Boş Geçilemez!");
			RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Boş Geçilemez!");
			RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen Bir Resim Dosyası Yükleyiniz!");
			RuleFor(x => x.OgrenciNo).NotEmpty().WithMessage("Öğrenci No Boş Geçilemez");

			RuleFor(x => x.AdSoyad).MaximumLength(30).WithMessage("Ad Soyad Maximum 30 Karakter İçermelidir!");
			RuleFor(x => x.AdSoyad).MinimumLength(5).WithMessage("Ad Soyad Mininmum 5 Karakter İçermelidir!");

			RuleFor(x => x.TCNO).MaximumLength(11).WithMessage("TC kimlik numaranız 11 rakamdan oluşmalıdır!");
			RuleFor(x => x.TCNO).MinimumLength(11).WithMessage("TC kimlik numaranız 11 rakamdan oluşmalıdır!");
			RuleFor(x => x.TCNO).Matches("^[0-9]*$").WithMessage("TC No sadece rakamlardan oluşmalıdır");

			RuleFor(x => x.Cinsiyet).Must(cinsiyet => cinsiyet == true || cinsiyet == false).WithMessage("Lütfen Bir Cinsiyet Seçiniz!");

			RuleFor(x => x.Mail).MaximumLength(50).WithMessage("Mailiniz Maximum 50 Karakter İçermelidir!");
			RuleFor(x => x.Mail).MinimumLength(15).WithMessage("Mailiniz Mininmum 15 Karakter İçermelidir!");

			RuleFor(x => x.OgrenciNo).MaximumLength(10).WithMessage("Öğrenci No 10 hane olmalıdır");
			RuleFor(x => x.OgrenciNo).MinimumLength(10).WithMessage("Öğrenci No 10 hane olmalıdır");
			RuleFor(x => x.OgrenciNo).Matches("^[0-9]*$").WithMessage("Öğrenci No sadece rakamlardan oluşmalıdır");

			RuleFor(x => x.sınıf).Must(sınıf => sınıf == "1.sınıf" || sınıf == "2.sınıf" || sınıf == "3.sınıf" || sınıf == "4.sınıf"|| sınıf == "Yüksek Lisans").WithMessage("Lütfen Bir Sınıf Seçiniz!");
			RuleFor(x => x.sınıf).NotNull().WithMessage("Sınıf Boş Geçilemez!");
		}
    }
}
