using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TeaShop.BusinessLayer.Abstract;
using TeaShop.DTO.DTOs.AboutDTOs;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutsController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _aboutService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDTO createAboutDTO)
        {
            About about = new About()
            {
                AboutTitle = createAboutDTO.AboutTitle,
                AboutDescription = createAboutDTO.AboutDescription,
                AboutImageURL = createAboutDTO.AboutImageURL,
                IsHome = createAboutDTO.IsHome,
                IsFooter = createAboutDTO.IsFooter,
                AboutStatus = createAboutDTO.AboutStatus
            };
            _aboutService.TInsert(about);
            return Ok("Hakkımızda Bilgisi Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            _aboutService.TDelete(values);
            return Ok("Hakkımızda Bilgisi Başarılı Bir Şekilde Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var values = _aboutService.TGetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDTO updateAboutDTO)
        {
            About about = new About()
            {
                AboutTitle = updateAboutDTO.AboutTitle,
                AboutDescription = updateAboutDTO.AboutDescription,
                AboutImageURL = updateAboutDTO.AboutImageURL,
                IsHome = updateAboutDTO.IsHome,
                IsFooter = updateAboutDTO.IsFooter,
                AboutStatus = updateAboutDTO.AboutStatus,
                AboutID = updateAboutDTO.AboutID
            };
            _aboutService.TUpdate(about);
            return Ok("Hakkımızda Bilgisi Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("GetLast3Abouts")]
        public IActionResult GetLast3Abouts()
        {
            var values = _aboutService.TGetLast3Abouts();
            return Ok(values);
        }

        [HttpGet("GetActiveAbouts")]
        public IActionResult GetActiveAbouts()
        {
            var values = _aboutService.TGetActiveAbouts();
            return Ok(values);
        }

		[HttpGet("GetAboutByFooterStatus")]
		public IActionResult GetAboutByFooterStatus()
		{
			var value = _aboutService.TGetAboutByFooterStatus();
			return Ok(value);
		}

		[HttpGet("ChangeAboutStatus/{id}")]
        public IActionResult ChangeAboutStatus(int id)
        {
            _aboutService.TChangeAboutStatus(id);
            return Ok("Hakkımızda Bilgisi Durum Değeri Değiştirildi");
        }

        [HttpGet("ChangeHomeStatus/{id}")]
        public IActionResult ChangeHomeStatus(int id)
        {
            _aboutService.TChangeHomeStatus(id);
            return Ok("Hakkımızda Bilgisi Ana Sayfa Görünürlüğü Değiştirildi");
        }

        [HttpGet("ChangeFooterStatus/{id}")]
        public IActionResult ChangeFooterStatus(int id)
        {
            _aboutService.TChangeFooterStatus(id);
            return Ok("Hakkımızda Bilgisi Alt-Bilgi Değeri Değiştirildi");
        }
    }
}