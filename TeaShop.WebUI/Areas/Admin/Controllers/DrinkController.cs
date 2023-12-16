using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TeaShop.WebUI.DTOs.DrinkDTOs;

namespace TeaShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class DrinkController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public DrinkController(IHttpClientFactory httpClientFactory, IWebHostEnvironment webHostEnvironment)
		{
			_httpClientFactory = httpClientFactory;
			_webHostEnvironment = webHostEnvironment;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.page = "Drink";
			ViewBag.subPage = "İçecekler";

			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7042/api/Drinks");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var drinks = JsonConvert.DeserializeObject<List<ResultDrinkDTO>>(jsonData);
				return View(drinks);
			}
			return View();
		}

		[HttpGet]
		public IActionResult CreateDrink()
		{
			ViewBag.page = "Drink";
			ViewBag.subPage = "İçecekler";

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateDrink(CreateDrinkDTO createDrinkDTO, IFormFile image)
		{
			string uniqueFileName = null;

			if (image != null)
			{
				string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
				uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
				string filePath = Path.Combine(uploadsFolder, uniqueFileName);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					image.CopyTo(fileStream);
				}
				createDrinkDTO.DrinkImageURL = uniqueFileName;
			}

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createDrinkDTO);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7042/api/Drinks", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteDrink(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7042/api/Drinks/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateDrink(int id)
		{
			ViewBag.page = "Drink";
			ViewBag.subPage = "İçecekler";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7042/api/Drinks/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateDrinkDTO>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateDrink(UpdateDrinkDTO updateDrinkDTO, IFormFile image)
		{
			string uniqueFileName = null;

			if (image != null)
			{
				string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
				uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
				string filePath = Path.Combine(uploadsFolder, uniqueFileName);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					image.CopyTo(fileStream);
				}
				updateDrinkDTO.DrinkImageURL = uniqueFileName;
			}
			else
			{
				var drinkClient = _httpClientFactory.CreateClient();
				var response = await drinkClient.GetAsync($"https://localhost:7042/api/Drinks/{updateDrinkDTO.DrinkID}");
				if (response.IsSuccessStatusCode)
				{
					var jsonDrinkData = await response.Content.ReadAsStringAsync();
					var values = JsonConvert.DeserializeObject<GetDrinkDTO>(jsonDrinkData);
					updateDrinkDTO.DrinkImageURL = values.DrinkImageURL;
				}
			}

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateDrinkDTO);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7042/api/Drinks/", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> ChangeHomeStatus(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7042/api/Drinks/ChangeHomeStatus/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> ChangeDrinkStatus(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7042/api/Drinks/ChangeDrinkStatus/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}