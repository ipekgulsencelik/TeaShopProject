namespace TeaShop.WebUI.DTOs.QuestionDTOs
{
    public class CreateQuestionDTO
    {
        public string QuestionDetail { get; set; }
        public string AnswerDetail { get; set; }
        public bool IsHome { get; set; }
        public bool QuestionStatus { get; set; }
    }
}