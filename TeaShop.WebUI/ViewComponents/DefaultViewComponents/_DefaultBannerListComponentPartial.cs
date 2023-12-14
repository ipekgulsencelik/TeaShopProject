using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShop.WebUI.DTOs.BannerDTOs;

namespace TeaShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultBannerListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultBannerListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7042/api/Banners/GetLast3Banners");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var banners = JsonConvert.DeserializeObject<List<ResultBannerDTO>>(jsonData);
                return View(banners);
            }
            return View();
        }
    }
}