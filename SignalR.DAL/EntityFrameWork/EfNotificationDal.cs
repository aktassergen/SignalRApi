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

		public void NotificationChangeToFalse(int id)
		{
			
			using var context = new SignalRContext();
			var value = context.Notifications.Find(id);
			value.NotificationStatus = false;
			context.SaveChanges();
		}

		public void NotificationChangeToTrue(int id)
		{
			using var context = new SignalRContext();
			var value = context.Notifications.Find(id);
			value.NotificationStatus = true;
			context.SaveChanges();
		}

		public int NotificationCountByStatusFalse()
		{
			using var context = new SignalRContext();
			return context.Notifications.Where(x => x.NotificationStatus == false).Count();
		}
	}
}
