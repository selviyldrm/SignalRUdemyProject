using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IActionResult NotificationList() {
            var values = _notificationService.TGetListAll();
            return Ok(values);
        }

        [HttpGet("NotificationCountByStatusFalse")]
        public IActionResult NotificationCountByStatusFalse()
        {
            return Ok(_notificationService.TNotificationCountByStatusFalse());
        }
        [HttpGet("GetAllNotificationByFalse")]
        public IActionResult GetAllNotificationByFalse()
        {
            return Ok(_notificationService.TGetAllNotificationByFalse());
        }
        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDto createNotificationDto) {
            Notification notification = new Notification()
            {
                Description = createNotificationDto.Description,
                Icon = createNotificationDto.Icon,
                Status = false,
                Type = createNotificationDto.Type,
                Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())
            };
            _notificationService.TAdd(notification);
            return Ok("Bildirim işlemi başarıyla eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNotification(int id)
        {
           var value=_notificationService.TGetByID(id);
            _notificationService.TDelete(value);
            return Ok("Bildirim silindi");
        }
        [HttpGet("{id}")]
        public IActionResult GetNotification(int id) {
            var value = _notificationService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
        {
            Notification notification = new Notification()
            {
                Description = updateNotificationDto.Description,
                Date = updateNotificationDto.Date,
                Icon = updateNotificationDto.Icon,
                NotificationID = updateNotificationDto.NotificationID,
                Status = updateNotificationDto.Status,
                Type = updateNotificationDto.Type,
            };
            _notificationService.TUpdate(notification);
            return Ok("Bildirim güncellendi");
        }

        [HttpGet("NotificationStatusChangeToFalse/{id}")]
        public IActionResult NotificationStatusChangeToFalse(int id)
        {
            _notificationService.TNotificationStatusChangeToFalse(id);
            return Ok("Bildirim Durumu False Yapıldı");
        }

        [HttpGet("NotificationStatusChangeToTrue/{id}")]
        public IActionResult NotificationStatusChangeToTrue(int id)
        {
            _notificationService.TNotificationStatusChangeToTrue(id);
            return Ok("Bildirim Durumu True Yapıldı...");
        }

	}
}
