using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRWebUI.Dtos.NotificationDtos
{
	public class CreateNotificationDto
	{
		public string NotificationType { get; set; }
		public string NotificationIcon { get; set; }
		public string NotificationDescription { get; set; }
		public bool NotificationStatus { get; set; }
	}
}
