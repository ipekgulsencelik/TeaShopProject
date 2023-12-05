using Microsoft.AspNetCore.Mvc;
using TeaShop.BusinessLayer.Abstract;
using TeaShop.DTO.DTOs.MessageDTOs;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessagesController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _messageService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDTO createMessageDTO)
        {
            Message message = new Message()
            {
                MessageSenderName = createMessageDTO.MessageSenderName,
                MessageDetail = createMessageDTO.MessageDetail,
                MessageEmail = createMessageDTO.MessageEmail,
                MessageSubject = createMessageDTO.MessageSubject,
                MessageSendDate = createMessageDTO.MessageSendDate,
                MessageStatus = createMessageDTO.MessageStatus
            };
            _messageService.TInsert(message);
            return Ok("Mesaj Başarılı Bir Şekilde Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteMessage(int id)
        {
            var values = _messageService.TGetByID(id);
            _messageService.TDelete(values);
            return Ok("Mesaj Başarılı Bir Şekilde Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var values = _messageService.TGetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDTO updateMessageDTO)
        {
            Message message = new Message()
            {
                MessageSenderName = updateMessageDTO.MessageSenderName,
                MessageDetail = updateMessageDTO.MessageDetail,
                MessageEmail = updateMessageDTO.MessageEmail,
                MessageSubject = updateMessageDTO.MessageSubject,
                MessageSendDate = updateMessageDTO.MessageSendDate,
                MessageStatus = updateMessageDTO.MessageStatus,
                MessageID = updateMessageDTO.MessageID
            };
            _messageService.TUpdate(message);
            return Ok("Mesaj Başarılı Bir Şekilde Güncellendi");
        }

        [HttpGet("ChangeMessageStatus/{id}")]
        public IActionResult ChangeMessageStatus(int id)
        {
            _messageService.TChangeMessageStatus(id);
            return Ok("Mesajın Durum Değeri Değiştirildi");
        }
    }
}