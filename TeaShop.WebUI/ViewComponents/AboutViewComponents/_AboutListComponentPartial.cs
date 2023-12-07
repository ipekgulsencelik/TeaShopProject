using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShop.WebUI.DTOs.AboutDTOs;

namespace TeaShop.WebUI.ViewComponents.AboutViewComponents
{
    public class _AboutListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AboutListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7042/api/Abouts/GetActiveAbouts");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var testimonials = JsonConvert.DeserializeObject<List<ResultAboutDTO>>(jsonData);
                return View(testimonials);
            }
            return View();
        }
    }
}
