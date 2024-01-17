using DataAccessLayer.Abstract;
using DataAccessLayer.BaseContext;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete;

public class TestimonialDal : GenericRepository<BaseDbContext, Testimonial>, ITestimonialDal
{
    public TestimonialDal(BaseDbContext context) : base(context)
    {
    }

    public void ChangeTestimonialShowcaseToFalse(int id)
    {
        var value = Context.Testimonials.Where(x => x.Id == id).FirstOrDefault();
        value.Showcase = false;
        Context.SaveChanges();
    }

    public void ChangeTestimonialShowcaseToTrue(int id)
    {
        var value = Context.Testimonials.Where(x => x.Id == id).FirstOrDefault();
        value.Showcase = true;
        Context.SaveChanges();
    }
}
