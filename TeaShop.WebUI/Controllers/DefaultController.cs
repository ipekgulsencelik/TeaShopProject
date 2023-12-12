using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using TeaShop.WebUI.DTOs.MessageDTOs;
using TeaShop.WebUI.DTOs.SubscribeDTOs;

namespace TeaShop.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DefaultController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        public PartialViewResult _SubscribePartial()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> _SubscribePartial(CreateSubscribeDTO createSubscribeDTO)
        {
            var client = _httpClientFactory.CreateClient();
            createSubscribeDTO.SubscribeStatus = true;
            var jsonData = JsonConvert.SerializeObject(createSubscribeDTO);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7042/api/Subscribe", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDTO createMessageDTO)
        {
            using (var client = _httpClientFactory.CreateClient())
            {
                createMessageDTO.MessageSendDate = DateTime.Now;
                createMessageDTO.MessageStatus = true;

                var content = new StringContent(JsonConvert.SerializeObject(createMessageDTO), Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7042/api/Messages", content);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return View();
        }
    }
}