using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShop.WebUI.DTOs.MapDTOs;

namespace TeaShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultMapComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultMapComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7042/api/Maps/GetActiveMap");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var map = JsonConvert.DeserializeObject<ResultMapDTO>(jsonData);
                return View(map);
            }
            return View();
        }
    }
}