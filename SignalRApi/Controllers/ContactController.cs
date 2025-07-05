using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.ContactDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var values = _contactService.TGetAllList();
            return Ok(values);
        }
        [HttpGet("[action]/{Id}")]
        public IActionResult GetById(int Id)
        {
            var value = _contactService.TGetById(Id);
            return Ok(value);
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateContactDto createContactDto)
        {
            Contact contact = new Contact
            {
                Location = createContactDto.Location,
                Phone = createContactDto.Phone,
                Mail = createContactDto.Mail,
                FooterDespcription = createContactDto.FooterDespcription
            };
            _contactService.TAdd(contact);
            return Ok("Contact Added Successfully");
        }
        [HttpPut("[action]")]
        public IActionResult Update(UpdateContactDto updateContactDto)
        {
            Contact contact = new Contact
            {
                ContactId = updateContactDto.ContactId,
                Location = updateContactDto.Location,
                Phone = updateContactDto.Phone,
                Mail = updateContactDto.Mail,
                FooterDespcription = updateContactDto.FooterDespcription
            };
            _contactService.TUpdate(contact);
            return Ok("Contact Updated Successfully");
        }
        [HttpDelete("[action]/{Id}")]
        public IActionResult Delete(int Id)
        {
            var value = _contactService.TGetById(Id);
            _contactService.TDelete(value);
            return Ok("Contact Deleted Successfully");
        }

    }
}
