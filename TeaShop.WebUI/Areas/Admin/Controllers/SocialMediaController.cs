using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TeaShop.WebUI.DTOs.SocialMediaDTOs;

namespace TeaShop.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("[area]/[controller]/[action]/{id?}")]
	public class SocialMediaController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly IWebHostEnvironment _webHostEnvironment;

		public SocialMediaController(IHttpClientFactory httpClientFactory, IWebHostEnvironment webHostEnvironment)
		{
			_httpClientFactory = httpClientFactory;
			_webHostEnvironment = webHostEnvironment;
		}

		public async Task<IActionResult> Index()
		{
			ViewBag.page = "SocialMedia";
			ViewBag.subPage = "Sosyal Medya";

			var client = _httpClientFactory.CreateClient();
			var response = await client.GetAsync("https://localhost:7042/api/SocialMedias");
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var socialMedia = JsonConvert.DeserializeObject<List<ResultSocialMediaDTO>>(jsonData);
				return View(socialMedia);
			}
			return View();
		}

		[HttpGet]
		public IActionResult CreateSocialMedia()
		{
			ViewBag.page = "SocialMedia";
			ViewBag.subPage = "Sosyal Medya";

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateSocialMedia(CreateSocialMediaDTO createSocialMediaDTO, IFormFile image)
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
				createSocialMediaDTO.ImageURL = uniqueFileName;
			}

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createSocialMediaDTO);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7042/api/SocialMedias", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> DeleteSocialMedia(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7042/api/SocialMedias/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		[HttpGet]
		public async Task<IActionResult> UpdateSocialMedia(int id)
		{
			ViewBag.page = "SocialMedia";
			ViewBag.subPage = "Sosyal Medya";

			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7042/api/SocialMedias/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateSocialMediaDTO>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> UpdateSocialMedia(UpdateSocialMediaDTO updateSocialMediaDTO, IFormFile image)
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
				updateSocialMediaDTO.ImageURL = uniqueFileName;
			}
			else
			{
				var drinkClient = _httpClientFactory.CreateClient();
				var response = await drinkClient.GetAsync($"https://localhost:7042/api/SocialMedias/{updateSocialMediaDTO.SocialMediaID}");
				if (response.IsSuccessStatusCode)
				{
					var jsonSocialMediaData = await response.Content.ReadAsStringAsync();
					var values = JsonConvert.DeserializeObject<GetSocialMediaDTO>(jsonSocialMediaData);
					updateSocialMediaDTO.ImageURL = values.ImageURL;
				}
			}

			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateSocialMediaDTO);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7042/api/SocialMedias/", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> ChangeHomeStatus(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7042/api/SocialMedias/ChangeHomeStatus/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}

		public async Task<IActionResult> ChangeSocialMediaStatus(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7042/api/SocialMedias/ChangeSocialMediaStatus/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}