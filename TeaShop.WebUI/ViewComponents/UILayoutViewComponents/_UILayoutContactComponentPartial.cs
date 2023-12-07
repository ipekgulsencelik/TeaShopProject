using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShop.WebUI.DTOs.ContactDTOs;

namespace TeaShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutContactComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _UILayoutContactComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7042/api/Contacts/GetActiveContact");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var testimonials = JsonConvert.DeserializeObject<ResultContactDTO>(jsonData);
                return View(testimonials);
            }
            return View();
        }
    }
}