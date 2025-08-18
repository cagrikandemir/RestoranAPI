using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet("[action]")]
        public IActionResult GetAllNotification()
        {
            return Ok(_notificationService.TGetAllList());
        }
        [HttpGet("[action]")]
        public IActionResult GetNotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TGetNotificationCountByStatusFalse());
        }
        [HttpGet("[action]")]
        public IActionResult GetAllNotificationByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationByFalse());
        }
        [HttpGet("[action]/{Id}")]
        public IActionResult GetNotificationStatusChangeToTrue(int Id)
        {
            _notificationService.TNotificationStatusChangeToTrue(Id);
            return Ok("Successfully changed notification status to true.");
        }
        [HttpGet("[action]/{Id}")]
        public IActionResult GetNotificationStatusChangeToFalse(int Id) { 
        _notificationService.TNotificationStatusChangeToFalse(Id);
            return Ok("Successfully changed notification status to false.");
        }
        [HttpPost("[action]")]
        public IActionResult Add(CreateNotificationDto createNotificationDto)
        {
            Notification notification = new()
            {
                Type = createNotificationDto.Type,
                Description = createNotificationDto.Description,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
                Status = false,
                Icon = createNotificationDto.Icon
            };
             _notificationService.TAdd(notification);
            return Ok("Notification created successfully.");
        }
        [HttpDelete("[action]/{Id}")]
        public IActionResult Delete(int Id)
        {
            var notification = _notificationService.TGetById(Id);
            if (notification != null)
            {
                _notificationService.TDelete(notification);
                return Ok("Notification deleted successfully.");
            }
            return NotFound("Notification not found.");
        }
        [HttpPut("[action]/{Id}")]
        public IActionResult Update(UpdateNotificationDto updateNotificationDto) {
            Notification notification = new()
            {
                NotificationId = updateNotificationDto.NotificationId,
                Type = updateNotificationDto.Type,
                Description = updateNotificationDto.Description,
                Date = updateNotificationDto.Date,
                Status = updateNotificationDto.Status,
                Icon = updateNotificationDto.Icon,
            };
            _notificationService.TUpdate(notification);
            return Ok("Notification updated successfully.");

        }
    }
}
