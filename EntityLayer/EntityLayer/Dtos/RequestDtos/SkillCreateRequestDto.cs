using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.RequestDtos;

public record SkillCreateRequestDto(string Title,
                                    string Value)
{
    public static Skill ConverToEntity(SkillCreateRequestDto request)
    {
        return new Skill
        {
            Title = request.Title,
            Value = request.Value
        };
    }
}
