using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.ResponseDtos;

public record TestimonialResponseDto(int Id,
                                     string ClientName,
                                     string Company,
                                     string Comment,
                                     string ImageUrl,
                                     string Title,
                                     bool Showcase)
{
    public static TestimonialResponseDto ConvertToResponse(Testimonial Testimonial)
    {
        return new TestimonialResponseDto(
            Id: Testimonial.Id,
            ClientName: Testimonial.ClientName,
            Company: Testimonial.Company,
            Comment: Testimonial.Comment,
            ImageUrl: Testimonial.ImageUrl,
            Title: Testimonial.Title,
            Showcase: Testimonial.Showcase
            );
    }
}
