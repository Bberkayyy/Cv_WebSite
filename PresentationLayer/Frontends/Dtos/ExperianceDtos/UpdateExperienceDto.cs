﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ExperianceDtos;

public class UpdateExperienceDto
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string Date { get; set; }
    public string TaskName { get; set; }
    public string Description { get; set; }
}
