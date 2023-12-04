using Microsoft.AspNetCore.Mvc;
using TeaShop.BusinessLayer.Abstract;
using TeaShop.DTO.DTOs.TestimonialDTOs;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _testimonialService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(CreateTestimonialDTO createTestimonialDTO)
        {
            Testimonial testimonial = new Testimonial()
            {
                TestimonialImageURL = createTestimonialDTO.TestimonialImageURL,
                TestimonialName = createTestimonialDTO.TestimonialName,
                TestimonialComment = createTestimonialDTO.TestimonialComment,
                TestimonialTitle = createTestimonialDTO.TestimonialTitle,
                IsHome = createTestimonialDTO.IsHome,
                TestimonialStatus = createTestimonialDTO.TestimonialStatus
            };
            _testimonialService.TInsert(testimonial);
            return Ok("Referans Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            _testimonialService.TDelete(values);
            return Ok("Referans Başarılı Bir Şekilde Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var values = _testimonialService.TGetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(UpdateTestimonialDTO updateTestimonialDTO)
        {
            Testimonial testimonial = new Testimonial()
            {
                TestimonialImageURL = updateTestimonialDTO.TestimonialImageURL,
                TestimonialName = updateTestimonialDTO.TestimonialName,
                TestimonialComment = updateTestimonialDTO.TestimonialComment,
                TestimonialTitle = updateTestimonialDTO.TestimonialTitle,
                IsHome = updateTestimonialDTO.IsHome,
                TestimonialStatus = updateTestimonialDTO.TestimonialStatus,
                TestimonialID = updateTestimonialDTO.TestimonialID
            };
            _testimonialService.TUpdate(testimonial);
            return Ok("Referans Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("GetLast3Testimonials")]
        public IActionResult GetLast3Testimonials()
        {
            var values = _testimonialService.TGetLast3Testimonials();
            return Ok(values);
        }

        [HttpGet("GetActiveTestimonials")]
        public IActionResult GetActiveTestimonials()
        {
            var values = _testimonialService.TGetActiveTestimonials();
            return Ok(values);
        }

        [HttpGet("ChangeTestimonialStatus/{id}")]
        public IActionResult ChangeTestimonialStatus(int id)
        {
            _testimonialService.TChangeTestimonialStatus(id);
            return Ok("Referansınızın Durum Değeri Değiştirildi");
        }

        [HttpGet("ChangeHomeStatus/{id}")]
        public IActionResult ChangeHomeStatus(int id)
        {
            _testimonialService.TChangeHomeStatus(id);
            return Ok("Referansınızın Ana Sayfa Görünürlüğü Değiştirildi");
        }
    }
}