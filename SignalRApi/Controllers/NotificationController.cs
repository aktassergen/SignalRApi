using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BL.Abstract;
using SignalR.Dto.NotificationDto;
using SignalR.Entity.Entities;

namespace SignalRApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;

		public NotificationController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}
		[HttpGet]
		public IActionResult NotidicationList()
		{
			return Ok(_notificationService.TGetListAll());
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
		public IActionResult CreateNotification(CreateNotificationDto createNotificationDto)
		{
			Notification notification = new Notification()
			{
				NotificationDescription = createNotificationDto.NotificationDescription,
				NotificationType = createNotificationDto.NotificationType,
				NotificationDate = Convert.ToDateTime(DateTime.Now.ToShortDateString()),
				NotificationIcon = createNotificationDto.NotificationIcon,
				NotificationStatus = false,
			}; 
			_notificationService.TAdd(notification);
			return Ok("Ekleme İşlemi Başarı İle Yapıldı");
		}
		[HttpDelete("{id}")]
		public IActionResult DeleteNotification(int id)
		{
			var value = _notificationService.TGetById(id);
			_notificationService.TDelete(value);
			return Ok("Bildirim Silindi");
		}
		[HttpGet("{id}")]
		public IActionResult GetNotification(int id)
		{
			var value = _notificationService.TGetById(id);
			return Ok(value);
		}

		[HttpPut]
		public IActionResult UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			Notification notification = new Notification()
			{
				NotificationId=updateNotificationDto.NotificationId,
				NotificationDescription = updateNotificationDto.NotificationDescription,
				NotificationType = updateNotificationDto.NotificationType,
				NotificationDate = updateNotificationDto.NotificationDate,
				NotificationIcon = updateNotificationDto.NotificationIcon,
				NotificationStatus = updateNotificationDto.NotificationStatus,
			};
			_notificationService.TUpdate(notification);
			return Ok("Güncelle İşlemi Başarı İle Yapıldı");
		}
		[HttpGet("NotificationChangeToFalse/{id}")]
		public IActionResult NotificationChangeToFalse(int id)
		{
			_notificationService.TNotificationChangeToFalse(id);
			return Ok("Güncelleme Yapıldı");
		}
		[HttpGet("NotificationChangeToTrue/{id}")]
		public IActionResult NotificationChangeToTrue(int id)
		{
			_notificationService.TNotificationChangeToTrue(id);
			return Ok("Güncelleme Yapıldı");
		}
	}
}
