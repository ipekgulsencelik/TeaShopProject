using Microsoft.AspNetCore.Mvc;
using TeaShop.BusinessLayer.Abstract;
using TeaShop.DTO.DTOs.BannerDTOs;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly IBannerService _bannerService;

        public BannersController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        [HttpGet]
        public IActionResult BannerList()
        {
            var values = _bannerService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateBanner(CreateBannerDTO createBannerDTO)
        {
            Banner banner = new Banner()
            {
                BannerTitle = createBannerDTO.BannerTitle,
                BannerSubTitle = createBannerDTO.BannerSubTitle,
                BannerImageURL = createBannerDTO.BannerImageURL,
                IsHome = createBannerDTO.IsHome,
                BannerStatus = createBannerDTO.BannerStatus
            };
            _bannerService.TInsert(banner);
            return Ok("Afiş Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBanner(int id)
        {
            var values = _bannerService.TGetByID(id);
            _bannerService.TDelete(values);
            return Ok("Afiş Başarılı Bir Şekilde Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetBanner(int id)
        {
            var values = _bannerService.TGetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateBanner(UpdateBannerDTO updateBannerDTO)
        {
            Banner banner = new Banner()
            {
                BannerTitle = updateBannerDTO.BannerTitle,
                BannerSubTitle = updateBannerDTO.BannerSubTitle,
                BannerImageURL = updateBannerDTO.BannerImageURL,
                IsHome = updateBannerDTO.IsHome,
                BannerStatus = updateBannerDTO.BannerStatus,
                BannerID = updateBannerDTO.BannerID
            };
            _bannerService.TUpdate(banner);
            return Ok("Afiş Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("GetLast3Banners")]
        public IActionResult GetLast3Banners()
        {
            var values = _bannerService.TGetLast3Banners();
            return Ok(values);
        }

        [HttpGet("ChangeBannerStatus/{id}")]
        public IActionResult ChangeBannerStatus(int id)
        {
            _bannerService.TChangeBannerStatus(id);
            return Ok("Afiş Durum Değeri Değiştirildi");
        }

        [HttpGet("ChangeHomeStatus/{id}")]
        public IActionResult ChangeHomeStatus(int id)
        {
            _bannerService.TChangeHomeStatus(id);
            return Ok("Afiş Ana Sayfa Görünürlüğü Değiştirildi");
        }
    }
}