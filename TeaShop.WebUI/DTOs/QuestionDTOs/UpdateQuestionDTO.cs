namespace TeaShop.WebUI.DTOs.QuestionDTOs
{
    public class UpdateQuestionDTO
    {
        public int QuestionID { get; set; }
        public string QuestionDetail { get; set; }
        public string AnswerDetail { get; set; }
        public bool IsHome { get; set; }
        public bool QuestionStatus { get; set; }
    }
}