using Microsoft.AspNetCore.Mvc;
using TeaShop.BusinessLayer.Abstract;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsService _statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            _statisticsService = statisticsService;
        }

        [HttpGet("GetAverageDrinkPrice")]
        public IActionResult GetAverageDrinkPrice()
        {
            return Ok(_statisticsService.TAverageDrinkPrice());
        }

        [HttpGet("GetDrinkCount")]
        public IActionResult GetDrinkCount()
        {
            return Ok(_statisticsService.TDrinkCount());
        }

        [HttpGet("GetLastDrinkName")]
        public IActionResult GetLastDrinkName()
        {
            return Ok(_statisticsService.TLastDrinkName());
        }

        [HttpGet("GetMaxDrinkPrice")]
        public IActionResult GetMaxDrinkPrice()
        {
            return Ok(_statisticsService.TMaxDrinkPrice());
        }

        [HttpGet("GetTestimonialCount")]
        public IActionResult GetTestimonialCount()
        {
            return Ok(_statisticsService.TTestimonialCount());
        }

        [HttpGet("GetMessageCount")]
        public IActionResult GetMessageCount()
        {
            return Ok(_statisticsService.TMessageCount());
        }

        [HttpGet("GetQuestionCount")]
        public IActionResult GetQuestionCount()
        {
            return Ok(_statisticsService.TQuestionCount());
        }

        [HttpGet("GetSubscribeCount")]
        public IActionResult GetSubscribeCount()
        {
            return Ok(_statisticsService.TSubscriberCount());
        }
    }
}