using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.ResponseDtos;

public record AboutResponseDto(int Id,
                                string Title,
                                string Description,
                                string Age,
                                string Mail,
                                string Phone,
                                string Address,
                                string ImageUrl)
{
    public static AboutResponseDto ConvertToResponse(About about)
    {
        return new AboutResponseDto(
            Id: about.Id,
            Title: about.Title,
            Description: about.Description,
            Age: about.Age,
            Mail: about.Mail,
            Phone: about.Phone,
            Address: about.Address,
            ImageUrl: about.ImageUrl);
    }
}
