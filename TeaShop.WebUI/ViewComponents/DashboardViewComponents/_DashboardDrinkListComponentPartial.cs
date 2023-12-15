using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShop.WebUI.DTOs.DrinkDTOs;

namespace TeaShop.WebUI.ViewComponents.DashboardViewComponents
{
    public class _DashboardDrinkListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DashboardDrinkListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
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