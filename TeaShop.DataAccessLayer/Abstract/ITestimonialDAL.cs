using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.Abstract
{
    public interface ITestimonialDAL : IGenericDAL<Testimonial>
    {
        void ChangeTestimonialStatus(int id);
        void ChangeHomeStatus(int id);
        List<Testimonial> GetLast3Testimonials();
        List<Testimonial> GetActiveTestimonials();
    }
}