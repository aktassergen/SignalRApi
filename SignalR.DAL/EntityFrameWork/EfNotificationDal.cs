using SignalR.DAL.Abstract;
using SignalR.DAL.Concrete;
using SignalR.DAL.Repository;
using SignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DAL.EntityFrameWork
{
	public class EfNotificationdal : GenericRepository<Notification>, INotificationDal
	{
		public EfNotificationdal(SignalRContext context) : base(context)
		{
		}

		public List<Notification> GetAllNotificationByFalse()
		{
			using var context = new SignalRContext();
			return context.Notifications.Where(x=>x.NotificationStatus==false).ToList();
		}

		public int NotificationCountByStatusFalse()
		{
			using var context = new SignalRContext();
			return context.Notifications.Where(x => x.NotificationStatus == false).Count();
		}
	}
}
