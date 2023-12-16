using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShop.WebUI.DTOs.ShopDTOs;

namespace TeaShop.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultShopListComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DefaultShopListComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7042/api/Shops/GetLast3Shops");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var shops = JsonConvert.DeserializeObject<List<ResultShopDTO>>(jsonData);
				return View(shops);
			}
			return View();
		}
	}
}