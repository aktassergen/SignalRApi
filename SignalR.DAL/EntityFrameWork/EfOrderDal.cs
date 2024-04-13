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
	public class EfOrderDal : GenericRepository<Order>, IOrderDal
	{
		public EfOrderDal(SignalRContext context) : base(context)
		{
		}

		public int ActiveOrderCount()
		{
			using var context = new SignalRContext();
			return context.Orders.Where(x=>x.OrderDescription=="Müşteri Masada").Count();
		}

		public decimal LastOrderPrice()
		{
			using var context = new SignalRContext();
			return context.Orders.OrderByDescending(x => x.OrderId).Take(1).Select(y => y.OrderTotalPrice).FirstOrDefault();//z den a yadoğru sırala
		}

		public decimal TodayTotalPrice()
		{
			using var context = new SignalRContext();
			var today = DateTime.Now;
			return context.Orders
						  .Where(x => x.OrderDate.Year == today.Year &&
									  x.OrderDate.Month == today.Month &&
									  x.OrderDate.Day == today.Day)
						  .Sum(y => y.OrderTotalPrice);
		}

		public int TotalOrderCount()
		{
			using var context = new SignalRContext();
			return context.Orders.Count();
		}
	}
}
