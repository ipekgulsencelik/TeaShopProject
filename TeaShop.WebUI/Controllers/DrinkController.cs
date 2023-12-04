using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShop.WebUI.DTOs.DrinkDTOs;

namespace TeaShop.WebUI.Controllers
{
    public class DrinkController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DrinkController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7042/api/Drinks/GetActiveDrinks");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var drinks = JsonConvert.DeserializeObject<List<ResultDrinkDTO>>(jsonData);
                return View(drinks);
            }
            return View();
        }
    }
}