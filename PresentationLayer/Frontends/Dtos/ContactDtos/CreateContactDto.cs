﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.ContactDtos;

public class CreateContactDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
}
