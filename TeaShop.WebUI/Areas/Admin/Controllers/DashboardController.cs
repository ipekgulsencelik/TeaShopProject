using Microsoft.AspNetCore.Mvc;

namespace TeaShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("[area]/[controller]/[action]/{id?}")]
    public class DashboardController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DashboardController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();

            var responseMessage1 = await client.GetAsync("https://localhost:7042/api/Statistics/GetAverageDrinkPrice");
            var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
            ViewBag.avgDrinkPrice = jsonData1.ToString().Substring(0, 5); ;

            var responseMessage2 = await client.GetAsync("https://localhost:7042/api/Statistics/GetDrinkCount");
            var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
            ViewBag.drinkCount = jsonData2;

            var responseMessage3 = await client.GetAsync("https://localhost:7042/api/Statistics/GetLastDrinkName");
            var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
            ViewBag.lastDrinkName = jsonData3;

            var responseMessage4 = await client.GetAsync("https://localhost:7042/api/Statistics/GetMaxDrinkPrice");
            var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
            ViewBag.maxPriceDrink = jsonData4.ToString().Substring(0, 5); ;

            var responseMessage5 = await client.GetAsync("https://localhost:7042/api/Statistics/GetTestimonialCount");
            var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
            ViewBag.testimonialCount = jsonData5;

            var responseMessage6 = await client.GetAsync("https://localhost:7042/api/Statistics/GetMessageCount");
            var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
            ViewBag.messageCount = jsonData6;

            var responseMessage7 = await client.GetAsync("https://localhost:7042/api/Statistics/GetQuestionCount");
            var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
            ViewBag.faqCount = jsonData7;

            var responseMessage8 = await client.GetAsync("https://localhost:7042/api/Statistics/GetSubscribeCount");
            var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
            ViewBag.subscribeCount = jsonData8;

            return View();
        }
    }
}