using TeaShop.DataAccessLayer.Abstract;
using TeaShop.DataAccessLayer.Concrete;
using TeaShop.DataAccessLayer.Repository;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.DataAccessLayer.EntityFramework
{
    public class EFTestimonialDAL : GenericRepository<Testimonial>, ITestimonialDAL
    {
        public EFTestimonialDAL(TeaContext context) : base(context)
        {
        }

        public void ChangeHomeStatus(int id)
        {
            var context = new TeaContext();
            var testimonial = context.Testimonials.Where(x => x.TestimonialID == id).FirstOrDefault();
            if (testimonial.IsHome == true)
            {
                testimonial.IsHome = false;
            }
            else
            {
                testimonial.IsHome = true;
            }
            context.Update(testimonial);
            context.SaveChanges();
        }

        public void ChangeTestimonialStatus(int id)
        {
            var context = new TeaContext();
            var testimonial = context.Testimonials.Where(x => x.TestimonialID == id).FirstOrDefault();
            if (testimonial.TestimonialStatus == true)
            {
                testimonial.TestimonialStatus = false;
            }
            else
            {
                testimonial.TestimonialStatus = true;
            }
            context.Update(testimonial);
            context.SaveChanges();
        }

        public List<Testimonial> GetActiveTestimonials()
        {
            var context = new TeaContext();
            var values = context.Testimonials.Where(x => x.TestimonialStatus == true).ToList();
            return values;
        }

        public List<Testimonial> GetLast3Testimonials()
        {
            var context = new TeaContext();
            var testimonialCount = context.Testimonials.Where(x => x.TestimonialStatus == true && x.IsHome == true).Count();
            var values = context.Testimonials.Where(x => x.TestimonialStatus == true && x.IsHome == true).ToList();
            if (testimonialCount <= 3)
            {
                values = context.Testimonials.Where(x => x.TestimonialStatus == true && x.IsHome == true).OrderByDescending(x => x.TestimonialID).ToList();
            }
            else
            {
                values = context.Testimonials.Where(x => x.TestimonialStatus == true && x.IsHome == true).OrderByDescending(x => x.TestimonialID).Take(3).ToList();
            }
            return values;
        }
    }
}