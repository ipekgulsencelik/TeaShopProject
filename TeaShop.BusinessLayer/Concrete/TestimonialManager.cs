using TeaShop.BusinessLayer.Abstract;
using TeaShop.DataAccessLayer.Abstract;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDAL _testimonialDAL;

        public TestimonialManager(ITestimonialDAL testimonialDAL)
        {
            _testimonialDAL = testimonialDAL;
        }

        public void TChangeHomeStatus(int id)
        {
            _testimonialDAL.ChangeHomeStatus(id);
        }

        public void TChangeTestimonialStatus(int id)
        {
            _testimonialDAL.ChangeTestimonialStatus(id);
        }

        public void TDelete(Testimonial entity)
        {
            _testimonialDAL.Delete(entity);
        }

        public List<Testimonial> TGetActiveTestimonials()
        {
            return _testimonialDAL.GetActiveTestimonials();
        }

        public Testimonial TGetByID(int id)
        {
            return _testimonialDAL.GetByID(id);
        }

        public List<Testimonial> TGetLast3Testimonials()
        {
            return _testimonialDAL.GetLast3Testimonials();
        }

        public List<Testimonial> TGetListAll()
        {
            return _testimonialDAL.GetListAll();
        }

        public void TInsert(Testimonial entity)
        {
            _testimonialDAL.Insert(entity);
        }

        public void TUpdate(Testimonial entity)
        {
            _testimonialDAL.Update(entity);
        }
    }
}