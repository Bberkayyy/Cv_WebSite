using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos.ResponseDtos;

public record SkillResponseDto(int Id,
                                string Title,
                                string Value)
{
    public static SkillResponseDto ConvertToResponse(Skill Skill)
    {
        return new SkillResponseDto(
            Id: Skill.Id,
            Title: Skill.Title,
            Value: Skill.Value);
    }
}
