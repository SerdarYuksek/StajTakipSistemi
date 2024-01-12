using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class PersonalPasswordValidator : AbstractValidator<Personal>
    {
        //Şifre değiştirme için gerekli kurallar
        public PersonalPasswordValidator()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre Boş Geçilemez!");
            RuleFor(x => x.RePassword).NotEmpty().WithMessage("Şifre Tekrar Boş Geçilemez!");
            RuleFor(x => x.TCNO).NotEmpty().WithMessage("TC Kimlik Numarası Boş Geçilemez!");

            RuleFor(x => x.TCNO).MaximumLength(11).WithMessage("TC kimlik numaranız 11 rakamdan oluşmalıdır!");
            RuleFor(x => x.TCNO).MinimumLength(11).WithMessage("TC kimlik numaranız 11 rakamdan oluşmalıdır!");
            RuleFor(x => x.TCNO).Matches("^[0-9]*$").WithMessage("TC No sadece rakamlardan oluşmalıdır");

            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Lütfen en az 6 hane içeren şifrenizi giriniz!");
            RuleFor(x => x.Password).MaximumLength(15).WithMessage("Lütfen en fazla 15 hane içeren şifrenizi giriniz!");

            RuleFor(x => x.RePassword).Equal(x => x.Password).WithMessage("Şifreler eşleşmiyor");
        }
    }
}
