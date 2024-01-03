using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules;

public class PortfolioValidator : AbstractValidator<Portfolio>
{
    //public PortfolioValidator()
    //{
    //    RuleFor(x => x.ProjectName).NotEmpty().WithMessage("Lütfen proje adı giriniz.");
    //    RuleFor(x => x.ProjectName).MinimumLength(5).WithMessage("Proje adı en az 5 karakterden oluşmalıdır.");
        
    //    PortfolioValidator validations = new PortfolioValidator();
    //    ValidationRules result = validations.Validate(x);

    //}
}