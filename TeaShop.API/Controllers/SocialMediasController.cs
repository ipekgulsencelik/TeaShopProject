using Microsoft.AspNetCore.Mvc;
using TeaShop.BusinessLayer.Abstract;
using TeaShop.DTO.DTOs.SocialMediaDTOs;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediasController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        [HttpGet]
        public IActionResult SocialMediaList()
        {
            var values = _socialMediaService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSocialMedia(CreateSocialMediaDTO createSocialMediaDTO)
        {
            SocialMedia socialMedia = new SocialMedia()
            {
                ImageURL = createSocialMediaDTO.ImageURL,
                URL = createSocialMediaDTO.URL,
                SocialMediaStatus = createSocialMediaDTO.SocialMediaStatus
            };
            _socialMediaService.TInsert(socialMedia);
            return Ok("Sosyal Medya Hesabı Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSocialMedia(int id)
        {
            var values = _socialMediaService.TGetByID(id);
            _socialMediaService.TDelete(values);
            return Ok("Sosyal Medya Hesabı Başarılı Bir Şekilde Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSocialMedia(int id)
        {
            var values = _socialMediaService.TGetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateSocialMedia(UpdateSocialMediaDTO updateSocialMediaDTO)
        {
            SocialMedia socialMedia = new SocialMedia()
            {
                ImageURL = updateSocialMediaDTO.ImageURL,
                URL = updateSocialMediaDTO.URL,
                SocialMediaStatus = updateSocialMediaDTO.SocialMediaStatus,
                SocialMediaID = updateSocialMediaDTO.SocialMediaID
            };
            _socialMediaService.TUpdate(socialMedia);
            return Ok("Sosyal Medya Hesabı Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("GetLast4ActiveSocialMedia")]
        public IActionResult GetLast4ActiveSocialMedia()
        {
            var values = _socialMediaService.TGetLast4ActiveSocialMedia();
            return Ok(values);
        }

        [HttpGet("ChangeSocialMediaStatus/{id}")]
        public IActionResult ChangeSocialMediaStatus(int id)
        {
            _socialMediaService.TChangeSocialMediaStatus(id);
            return Ok("Sosyal Medya Hesabı Durum Değeri Değiştirildi");
        }
    }
}