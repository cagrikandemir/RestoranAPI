using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;

namespace SignalR.BusinessLayer.Concrete;

public class TestimonialManager : ITestimonialService
{
    private readonly ITestimonialDal _testimonialDal;

    public TestimonialManager(ITestimonialDal testimonialDal)
    {
        _testimonialDal = testimonialDal;
    }

    public void TAdd(Testimonial entity)
    {
        _testimonialDal.Add(entity);
    }

    public void TDelete(Testimonial entity)
    {
        _testimonialDal.Delete(entity);
    }

    public List<Testimonial> TGetAllList()
    {
        return _testimonialDal.GetAllList();
    }

    public Testimonial TGetById(int Id)
    {
        return _testimonialDal.GetById(Id);
    }

    public void TUpdate(Testimonial entity)
    {
        _testimonialDal.Update(entity);
    }
}
