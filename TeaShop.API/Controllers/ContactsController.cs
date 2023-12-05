using Microsoft.AspNetCore.Mvc;
using TeaShop.BusinessLayer.Abstract;
using TeaShop.DTO.DTOs.ContactDTOs;
using TeaShop.EntityLayer.Concrete;

namespace TeaShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult ContactList()
        {
            var values = _contactService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateContact(CreateContactDTO createContactDTO)
        {
            Contact contact = new Contact()
            {
                Address = createContactDTO.Address,
                Email = createContactDTO.Email,
                Phone = createContactDTO.Phone,
                ContactStatus = createContactDTO.ContactStatus
            };
            _contactService.TInsert(contact);
            return Ok("İletişim Bilgileri Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var values = _contactService.TGetByID(id);
            _contactService.TDelete(values);
            return Ok("İletişim Bilgileri Başarılı Bir Şekilde Silindi");
        }

        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var values = _contactService.TGetByID(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDTO updateContactDTO)
        {
            Contact contact = new Contact()
            {
                Address = updateContactDTO.Address,
                Email = updateContactDTO.Email,
                Phone = updateContactDTO.Phone,
                ContactStatus = updateContactDTO.ContactStatus,
                ContactID = updateContactDTO.ContactID
            };
            _contactService.TUpdate(contact);
            return Ok("İletişim Bilgileri Güncellendi");
        }

        [HttpGet("GetActiveContact")]
        public IActionResult GetActiveContact()
        {
            var values = _contactService.TGetActiveContact();
            return Ok(values);
        }

        [HttpGet("ChangeContactStatus/{id}")]
        public IActionResult ChangeContactStatus(int id)
        {
            _contactService.TChangeContactStatus(id);
            return Ok("İletişim Bilgilerinin Durum Değeri Değiştirildi");
        }
    }
}