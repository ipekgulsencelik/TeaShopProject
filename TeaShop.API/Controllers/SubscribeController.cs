using Microsoft.AspNetCore.Mvc;
using TeaShop.BusinessLayer.Abstract;
using TeaShop.DTO.DTOs.SubscribeDTOs;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : ControllerBase
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public IActionResult SubscribeList()
        {
            var values = _subscribeService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateSubscribe(CreateSubscribeDTO createSubscribeDTO)
        {
            Subscribe subscribe = new Subscribe()
            {
                Mail = createSubscribeDTO.Mail,
                SubscribeStatus = createSubscribeDTO.SubscribeStatus
            };
            _subscribeService.TInsert(subscribe);
            return Ok("Abone Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSubscribe(int id)
        {
            var values = _subscribeService.TGetByID(id);
            _subscribeService.TDelete(values);
            return Ok("Abone Başarılı Bir Şekilde Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetSubscribe(int id)
        {
            var values = _subscribeService.TGetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateSubscribe(UpdateSubscribeDTO updateSubscribeDTO)
        {
            Subscribe subscribe = new Subscribe()
            {
                Mail = updateSubscribeDTO.Mail,
                SubscribeStatus = updateSubscribeDTO.SubscribeStatus,
                SubscribeID = updateSubscribeDTO.SubscribeID
            };
            _subscribeService.TUpdate(subscribe);
            return Ok("Abone Güncellendi");
        }

        [HttpGet("ChangeSubscribeStatus/{id}")]
        public IActionResult ChangeSubscribeStatus(int id)
        {
            _subscribeService.TChangeSubscribeStatus(id);
            return Ok("Abonenin Durum Değeri Değiştirildi");
        }
    }
}