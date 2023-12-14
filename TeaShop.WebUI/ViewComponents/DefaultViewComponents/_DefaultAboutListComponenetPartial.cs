using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShop.WebUI.DTOs.AboutDTOs;

namespace TeaShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultAboutListComponenetPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DefaultAboutListComponenetPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7042/api/Abouts/GetLast3Abouts");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var abouts = JsonConvert.DeserializeObject<List<ResultAboutDTO>>(jsonData);
				return View(abouts);
			}
			return View();
		}
	}
}
