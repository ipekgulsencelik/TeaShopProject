using TeaShop.EntityLayer.Concrete;

namespace TeaShop.BusinessLayer.Abstract
{
    public interface ITestimonialService : IGenericService<Testimonial>
    {
        void TChangeTestimonialStatus(int id);
        void TChangeHomeStatus(int id);
        List<Testimonial> TGetLast3Testimonials();
        List<Testimonial> TGetActiveTestimonials();
    }
}