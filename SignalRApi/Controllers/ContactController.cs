using AutoMapper;
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
        private readonly IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }
        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<List<Contact>>(_contactService.TGetAllList()));
        }
        [HttpGet("[action]/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_mapper.Map<Contact>(_contactService.TGetById(Id)));
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateContactDto createContactDto)
        {
            var contact = _mapper.Map<Contact>(createContactDto);
            _contactService.TAdd(contact);
            return Ok("Contact Added Successfully");
        }
        [HttpPut("[action]")]
        public IActionResult Update(UpdateContactDto updateContactDto)
        {
            var contact = _mapper.Map<Contact>(updateContactDto);

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
