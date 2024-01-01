using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record SkillUpdateRequestDto(int Id,
                                    string Title,
                                    string Value)
{
    public static Skill ConverToEntity(SkillUpdateRequestDto request)
    {
        return new Skill
        {
            Id = request.Id,
            Title = request.Title,
            Value = request.Value
        };
    }
}
