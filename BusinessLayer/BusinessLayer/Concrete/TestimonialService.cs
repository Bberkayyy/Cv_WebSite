using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete;

public class TestimonialService : ITestimonialDal
{
	private readonly ITestimonialDal _testimonialDal;

	public TestimonialService(ITestimonialDal testimonialDal)
	{
		_testimonialDal = testimonialDal;
	}

	public void Add(Testimonial entity)
	{
		_testimonialDal.Add(entity);
	}

	public List<Testimonial> GetAll()
	{
		return _testimonialDal.GetAll();
	}

	public Testimonial GetById(int id)
	{
		return _testimonialDal.GetById(id);
	}

	public void Remove(Testimonial entity)
	{
		_testimonialDal.Remove(entity);
	}

	public void Update(Testimonial entity)
	{
		_testimonialDal.Update(entity);
	}
}
