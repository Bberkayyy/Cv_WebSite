using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.StatisticDtos;

public class ResultStatisticDto
{
    public int ProjectCount { get; set; }
    public int SkillCount { get; set; }
    public int UserCount { get; set; }
    public int WebMessageCount { get; set; }
}
