using EntityLayer.Concrate;
using FluentValidation;


namespace BusinessLayer.ValidationRules
{
    public class StudentRegValidator : AbstractValidator<Student>
    {
        //Öğrenci Kaydı için gerekli kurallar
        public StudentRegValidator()
        {
            RuleFor(x => x.AdSoyad).NotEmpty().WithMessage("Ad Soyad Boş Geçilemez!");
            RuleFor(x => x.TCNO).NotEmpty().WithMessage("TC Kimlik Numarası Boş Geçilemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Boş Geçilemez!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Boş Geçilemez!");
			RuleFor(x => x.RePassword).NotEmpty().WithMessage("Şifre Tekrar Boş Geçilemez!");
            RuleFor(x => x.Image).NotEmpty().WithMessage("Lütfen Bir Resim Dosyası Yükleyiniz!");
			RuleFor(x => x.OgrenciNo).NotEmpty().WithMessage("Öğrenci No Boş Geçilemez");

			RuleFor(x => x.AdSoyad).MaximumLength(30).WithMessage("Ad Soyad Maximum 30 Karakter İçermelidir!");
            RuleFor(x => x.AdSoyad).MinimumLength(5).WithMessage("Ad Soyad Mininmum 5 Karakter İçermelidir!");

            RuleFor(x => x.TCNO).MaximumLength(11).WithMessage("TC kimlik numaranız 11 rakamdan oluşmalıdır!");
            RuleFor(x => x.TCNO).MinimumLength(11).WithMessage("TC kimlik numarası 11 rakamdan oluşmalıdır!");
			RuleFor(x => x.TCNO).Matches("^[0-9]*$").WithMessage("TC kimlik numarası sadece rakamlardan oluşmalıdır");

			RuleFor(x => x.Cinsiyet).Must(cinsiyet => cinsiyet  == true || cinsiyet == false).WithMessage("Lütfen Bir Cinsiyet Seçiniz!");

			RuleFor(x => x.Mail).MaximumLength(50).WithMessage("Mailiniz Maximum 50 Karakter İçermelidir!");
            RuleFor(x => x.Mail).MinimumLength(15).WithMessage("Mailiniz Mininmum 15 Karakter İçermelidir!");

			RuleFor(x => x.Password).MinimumLength(6).WithMessage("Lütfen en az 6 hane içeren şifrenizi giriniz!");
            RuleFor(x => x.Password).MaximumLength(15).WithMessage("Lütfen en fazla 15 hane içeren şifrenizi giriniz!");

			RuleFor(x => x.RePassword).Equal(x => x.Password).WithMessage("Şifreler eşleşmiyor");

			RuleFor(x => x.OgrenciNo).MaximumLength(10).WithMessage("Öğrenci No 10 hane olmalıdır");
			RuleFor(x => x.OgrenciNo).MinimumLength(10).WithMessage("Öğrenci No 10 hane olmalıdır");
			RuleFor(x => x.OgrenciNo).Matches("^[0-9]*$").WithMessage("Öğrenci No sadece rakamlardan oluşmalıdır");

			RuleFor(x => x.sınıf).Must(sınıf => sınıf == "1.sınıf" || sınıf == "2.sınıf" || sınıf == "3.sınıf" || sınıf == "4.sınıf" || sınıf == "Yüksek Lisans").WithMessage("Lütfen Bir Sınıf Seçiniz!");
			RuleFor(x => x.sınıf).NotNull().WithMessage("Sınıf Boş Geçilemez!");
		}
	}
}
