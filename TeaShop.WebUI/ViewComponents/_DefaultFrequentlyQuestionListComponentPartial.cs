using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TeaShop.WebUI.DTOs.QuestionDTOs;

namespace TeaShop.WebUI.ViewComponents
{
    public class _DefaultFrequentlyQuestionListComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultFrequentlyQuestionListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync("https://localhost:7042/api/Question/TGetLast5FrequentlyQuestions");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var testimonials = JsonConvert.DeserializeObject<List<ResultQuestionDTO>>(jsonData);
                return View(testimonials);
            }
            return View();
        }
    }
}