using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
	public class PersonalUpdateValidator : AbstractValidator<Personal>
	{
        //Personel bilgi güncellemesi için gerekli kurallar
        public PersonalUpdateValidator()
        {
			RuleFor(x => x.AdSoyad).NotEmpty().WithMessage("Ad Soyad Boş Geçilemez!");
			RuleFor(x => x.TCNO).NotEmpty().WithMessage("TC Kimlik Numarası Boş Geçilemez!");
			RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Boş Geçilemez!");
			RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen Bir Resim Dosyası Yükleyiniz!");
			RuleFor(x => x.PersonalNo).NotEmpty().WithMessage("Personel No Boş Geçilemez");

			RuleFor(x => x.AdSoyad).MaximumLength(30).WithMessage("Ad Soyad Maximum 30 Karakter İçermelidir!");
			RuleFor(x => x.AdSoyad).MinimumLength(5).WithMessage("Ad Soyad Mininmum 5 Karakter İçermelidir!");

			RuleFor(x => x.TCNO).MaximumLength(11).WithMessage("TC kimlik numaranız 11 rakamdan oluşmalıdır!");
			RuleFor(x => x.TCNO).MinimumLength(11).WithMessage("TC kimlik numaranız 11 rakamdan oluşmalıdır!");
			RuleFor(x => x.TCNO).Matches("^[0-9]*$").WithMessage("TC No sadece rakamlardan oluşmalıdır");

			RuleFor(x => x.Cinsiyet).Must(cinsiyet => cinsiyet == true || cinsiyet == false).WithMessage("Lütfen Bir Cinsiyet Seçiniz!");

			RuleFor(x => x.Mail).MaximumLength(50).WithMessage("Mailiniz Maximum 50 Karakter İçermelidir!");
			RuleFor(x => x.Mail).MinimumLength(15).WithMessage("Mailiniz Mininmum 15 Karakter İçermelidir!");

			RuleFor(x => x.PersonalNo).MaximumLength(10).WithMessage("Personel No 10 hane olmalıdır!");
			RuleFor(x => x.PersonalNo).MinimumLength(10).WithMessage("Personel No 10 hane olmalıdır!");
			RuleFor(x => x.PersonalNo).Matches("^[0-9]*$").WithMessage("Personel No sadece rakamlardan oluşmalıdır!");

			RuleFor(x => x.Unvan).Must(unvan => unvan == "Prof.Dr" || unvan == "Doç.Dr." || unvan == "Dr.Öğr.Üyesi" || unvan == "Öğretim Görevlisi" || unvan == "Araştırma Görevlisi").WithMessage("Lütfen bir unvan seçin!");
			RuleFor(x => x.Unvan).NotNull().WithMessage("Lütfen bir unvan seçin!");
		}
    }
}
