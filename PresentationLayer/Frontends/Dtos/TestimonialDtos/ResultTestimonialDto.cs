﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.TestimonialDtos;

public class ResultTestimonialDto
{
    public int Id { get; set; }
    public string ClientName { get; set; }
    public string Company { get; set; }
    public string Comment { get; set; }
    public string ImageUrl { get; set; }
    public string Title { get; set; }
}
