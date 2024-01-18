﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.SocialMediaDtos;

public class CreateSocialMediaDto
{
    public string Name { get; set; }
    public string Url { get; set; }
    public string IconUrl { get; set; }
    public bool Status = true;
}
