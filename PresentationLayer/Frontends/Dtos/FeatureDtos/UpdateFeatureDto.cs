﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.FeatureDtos;

public class UpdateFeatureDto
{
    public int Id { get; set; }
    public string Header { get; set; }
    public string Name { get; set; }
    public string Title { get; set; }
}
