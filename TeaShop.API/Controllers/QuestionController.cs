using Microsoft.AspNetCore.Mvc;
using TeaShop.BusinessLayer.Abstract;
using TeaShop.DTO.DTOs.QuestionDTOs;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

        [HttpGet]
        public IActionResult QuestionList()
        {
            var values = _questionService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateQuestion(CreateQuestionDTO createQuestionDTO)
        {
            Question question = new Question()
            {
                AnswerDetail = createQuestionDTO.AnswerDetail,
                QuestionDetail = createQuestionDTO.QuestionDetail,
                IsHome = createQuestionDTO.IsHome,
                QuestionStatus = createQuestionDTO.QuestionStatus
            };
            _questionService.TInsert(question);
            return Ok("Sorunuz Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuestion(int id)
        {
            var values = _questionService.TGetByID(id);
            _questionService.TDelete(values);
            return Ok("Soru Başarılı Bir Şekilde Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetQuestion(int id)
        {
            var values = _questionService.TGetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateQuestion(UpdateQuestionDTO updateQuestionDTO)
        {
            Question question = new Question()
            {
                AnswerDetail = updateQuestionDTO.AnswerDetail,
                QuestionDetail = updateQuestionDTO.QuestionDetail,
                IsHome = updateQuestionDTO.IsHome,
                QuestionStatus = updateQuestionDTO.QuestionStatus,
                QuestionID = updateQuestionDTO.QuestionID
            };
            _questionService.TUpdate(question);
            return Ok("Sorunuz Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("TGetLast5FrequentlyQuestions")]
        public IActionResult TGetLast5FrequentlyQuestions()
        {
            var values = _questionService.TGetLast5FrequentlyQuestions();
            return Ok(values);
        }

        [HttpGet("GetActiveFrequentlyQuestions")]
        public IActionResult GetActiveFrequentlyQuestions()
        {
            var values = _questionService.TGetActiveFrequentlyQuestions();
            return Ok(values);
        }

        [HttpGet("ChangeQuestionStatus/{id}")]
        public IActionResult ChangeQuestionStatus(int id)
        {
            _questionService.TChangeQuestionStatus(id);
            return Ok("Sorunun Durum Değeri Değiştirildi");
        }

        [HttpGet("ChangeHomeStatus/{id}")]
        public IActionResult ChangeHomeStatus(int id)
        {
            _questionService.TChangeHomeStatus(id);
            return Ok("Sorunun Ana Sayfa Görünürlüğü Değiştirildi");
        }
    }
}