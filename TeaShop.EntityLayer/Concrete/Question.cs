﻿namespace TeaShop.EntityLayer.Concrete
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionDetail { get; set; }
        public string AnswerDetail { get; set; }
        public bool IsHome { get; set; }
        public bool QuestionStatus { get; set; }
    }
}