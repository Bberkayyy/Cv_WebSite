﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract;

public interface ITestimonialDal : IGenericDal<Testimonial>
{
    void ChangeTestimonialShowcaseToFalse(int id);
    void ChangeTestimonialShowcaseToTrue(int id);
}
