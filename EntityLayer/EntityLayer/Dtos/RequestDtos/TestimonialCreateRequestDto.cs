using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record TestimonialCreateRequestDto(string ClientName,
                                          string Company,
                                          string Comment,
                                          string ImageUrl,
                                          string Title,
                                          bool Showcase)
{
    public static Testimonial ConverToEntity(TestimonialCreateRequestDto request)
    {
        return new Testimonial
        {
            ClientName = request.ClientName,
            Company = request.Company,
            Comment = request.Comment,
            ImageUrl = request.ImageUrl,
            Title = request.Title,
            Showcase = false
        };
    }
}
