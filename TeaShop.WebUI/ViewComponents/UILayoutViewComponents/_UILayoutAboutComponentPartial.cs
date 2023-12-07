using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShop.WebUI.DTOs.AboutDTOs;
using TeaShop.WebUI.DTOs.ContactDTOs;

namespace TeaShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _UILayoutAboutComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _UILayoutAboutComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7042/api/Abouts/GetAboutByFooterStatus");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var about = JsonConvert.DeserializeObject<ResultAboutDTO>(jsonData);
				return View(about);
			}
			return View();
		}
	}
}