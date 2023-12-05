using Microsoft.AspNetCore.Mvc;
using TeaShop.BusinessLayer.Abstract;
using TeaShop.DTO.DTOs.MapDTOs;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapsController : ControllerBase
    {
        private readonly IMapService _mapService;

        public MapsController(IMapService mapService)
        {
            _mapService = mapService;
        }

        [HttpGet]
        public IActionResult MapList()
        {
            var values = _mapService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMap(CreateMapDTO createMapDTO)
        {
            Map map = new Map()
            {
                LocationURL = createMapDTO.LocationURL,
                MapStatus = createMapDTO.MapStatus
            };
            _mapService.TInsert(map);
            return Ok("Konum Bilgisi Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMap(int id)
        {
            var values = _mapService.TGetByID(id);
            _mapService.TDelete(values);
            return Ok("Konum Bilgisi Başarılı Bir Şekilde Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMap(int id)
        {
            var values = _mapService.TGetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateMap(UpdateMapDTO updateMapDTO)
        {
            Map map = new Map()
            {
                LocationURL = updateMapDTO.LocationURL,
                MapStatus = updateMapDTO.MapStatus,
                MapID = updateMapDTO.MapID
            };
            _mapService.TUpdate(map);
            return Ok("Konum Bilgisi Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("GetActiveMap")]
        public IActionResult GetActiveMap()
        {
            var values = _mapService.TGetActiveMap();
            return Ok(values);
        }

        [HttpGet("ChangeMapStatus/{id}")]
        public IActionResult ChangeMapStatus(int id)
        {
            _mapService.TChangeMapStatus(id);
            return Ok("Konum Bilgisi Durum Değeri Değiştirildi");
        }
    }
}