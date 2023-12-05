namespace TeaShop.DTO.DTOs.MessageDTOs
{
    public class UpdateMessageDTO
    {
        public int MessageID { get; set; }
        public string MessageSenderName { get; set; }
        public string MessageSubject { get; set; }
        public string MessageEmail { get; set; }
        public string MessageDetail { get; set; }
        public DateTime MessageSendDate { get; set; }
        public bool MessageStatus { get; set; }
    }
}