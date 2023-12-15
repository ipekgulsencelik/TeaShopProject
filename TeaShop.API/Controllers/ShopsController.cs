using Microsoft.AspNetCore.Mvc;
using TeaShop.BusinessLayer.Abstract;
using TeaShop.DTO.DTOs.ShopDTOs;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopsController : ControllerBase
    {
        private readonly IShopService _shopService;

        public ShopsController(IShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet]
        public IActionResult ShopList()
        {
            var values = _shopService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateShop(CreateShopDTO createShopDTO)
        {
            Shop shop = new Shop()
            {
                ShopDescription = createShopDTO.ShopDescription,
                ShopImageURL = createShopDTO.ShopImageURL,
                ShopTitle = createShopDTO.ShopTitle,
                IsHome = createShopDTO.IsHome,
                ShopStatus = createShopDTO.ShopStatus
            };
            _shopService.TInsert(shop);
            return Ok("Sepet Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteShop(int id)
        {
            var values = _shopService.TGetByID(id);
            _shopService.TDelete(values);
            return Ok("Sepet Başarılı Bir Şekilde Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetShop(int id)
        {
            var values = _shopService.TGetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateShop(UpdateShopDTO updateShopDTO)
        {
            Shop shop = new Shop()
            {
                ShopImageURL = updateShopDTO.ShopImageURL,
                ShopDescription = updateShopDTO.ShopDescription,
                ShopTitle = updateShopDTO.ShopTitle,
                IsHome = updateShopDTO.IsHome,
                ShopStatus = updateShopDTO.ShopStatus,
                ShopID = updateShopDTO.ShopID
            };
            _shopService.TUpdate(shop);
            return Ok("Sepet Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("GetLast3Shops")]
        public IActionResult GetLast3Shops()
        {
            var values = _shopService.TGetLast3Shops();
            return Ok(values);
        }

        [HttpGet("GetActiveShops")]
        public IActionResult GetActiveShops()
        {
            var values = _shopService.TGetActiveShops();
            return Ok(values);
        }

        [HttpGet("ChangeShopStatus/{id}")]
        public IActionResult ChangeShopStatus(int id)
        {
            _shopService.TChangeShopStatus(id);
            return Ok("Sepet Durum Değeri Değiştirildi");
        }

        [HttpGet("ChangeHomeStatus/{id}")]
        public IActionResult ChangeHomeStatus(int id)
        {
            _shopService.TChangeHomeStatus(id);
            return Ok("Sepetin Ana Sayfa Görünürlüğü Değiştirildi");
        }
    }
}