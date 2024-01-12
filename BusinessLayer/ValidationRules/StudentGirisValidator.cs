
using EntityLayer.Concrate;
using FluentValidation;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class StudentGirisValidator : AbstractValidator<Student>
    {
        //Öğrenci Girişi için gerekli olan kurallar
        public StudentGirisValidator()
        {
            RuleFor(x => x.TCNO).NotEmpty().WithMessage("TC kimlik numarası boş geçilemez!");
            RuleFor(x => x.TCNO).MaximumLength(11).WithMessage("TC kimlik numaranız 11 rakamdan oluşmalıdır!");
			RuleFor(x => x.TCNO).MinimumLength(11).WithMessage("TC kimlik numaranız 11 rakamdan oluşmalıdır!");
			RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş geçilemez!");
            RuleFor(x => x.Password).MinimumLength(6).WithMessage("Lütfen en az 6 hane içeren şifrenizi giriniz!");
            RuleFor(x => x.Password).MaximumLength(15).WithMessage("Lütfen en fazla 15 hane içeren şifrenizi giriniz!");
        }
    }
}
