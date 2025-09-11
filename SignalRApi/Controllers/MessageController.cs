using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var values = _messageService.TGetAllList();
            return Ok(values);
        }
        [HttpGet("[action]/{Id}")]
        public IActionResult GetById(int Id)
        {
            var value = _messageService.TGetById(Id);
            return Ok(value);
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateMessageDto createMessageDto)
        {
            Message message = new Message
            {
                NameSurname = createMessageDto.NameSurname,
                Mail = createMessageDto.Mail,
                Phone = createMessageDto.Phone,
                Subject = createMessageDto.Subject,
                MessageContent = createMessageDto.MessageContent,
                MessageSendDate = createMessageDto.MessageSendDate,
                Status = createMessageDto.Status
            };
            _messageService.TAdd(message);
            return Ok("Message Added Successfully");
        }

        [HttpPut("[action]")]
        public IActionResult Update(UpdateMessageDto updateMessageDto)
        {
            Message message = new Message
            {
                MessageId = updateMessageDto.MessageId,
                NameSurname = updateMessageDto.NameSurname,
                Mail = updateMessageDto.Mail,
                Phone = updateMessageDto.Phone,
                Subject = updateMessageDto.Subject,
                MessageContent = updateMessageDto.MessageContent,
                MessageSendDate = updateMessageDto.MessageSendDate,
                Status = updateMessageDto.Status
            };
            _messageService.TUpdate(message);
            return Ok("Message Updated Successfully");
        }
        [HttpDelete("[action]/{Id}")]
        public IActionResult Delete(int Id)
        {
            var value = _messageService.TGetById(Id);
            _messageService.TDelete(value);
            return Ok("Message Deleted Successfully");
        }
    }
}
