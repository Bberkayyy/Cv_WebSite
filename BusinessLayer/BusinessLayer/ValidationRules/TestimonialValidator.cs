using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules;

public class TestimonialValidator:AbstractValidator<Testimonial>
{
    public TestimonialValidator()
    {
        RuleFor(x=>x.ClientName).NotEmpty().WithMessage("Ad-soyad boş geçilemez!");
        RuleFor(x=>x.Company).NotEmpty().WithMessage("Şirket adı boş geçilemez!");
        RuleFor(x=>x.Title).NotEmpty().WithMessage("Çalıştığınız pozisyon adı boş geçilemez!");
        RuleFor(x=>x.Comment).NotEmpty().WithMessage("Yorum kısmı boş geçilemez!");
        RuleFor(x=>x.ImageUrl).NotEmpty().WithMessage("Sayfa düzeni için resim seçmeniz gerekmektedir. Lütfen sayfada görünmesi için resminizi seçiniz!");
    }
}
