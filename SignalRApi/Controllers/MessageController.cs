using AutoMapper;
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
        private readonly IMapper _mapper;

        public MessageController(IMessageService messageService, IMapper mapper)
        {
            _messageService = messageService;
            _mapper = mapper;
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            return Ok(_mapper.Map<List<Message>>(_messageService.TGetAllList()));
        }
        [HttpGet("[action]/{Id}")]
        public IActionResult GetById(int Id)
        {
            return Ok(_mapper.Map<Message>(_messageService.TGetById(Id)));
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateMessageDto createMessageDto)
        {
            var message = _mapper.Map<Message>(createMessageDto);
            _messageService.TAdd(message);
            return Ok("Message Added Successfully");
        }

        [HttpPut("[action]")]
        public IActionResult Update(UpdateMessageDto updateMessageDto)
        {
            var message = _mapper.Map<Message>(updateMessageDto);

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
