﻿using SignalR.DAL.Abstract;
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
    public class EfBookingDal : GenericRepository<Booking>, IBookingDal
    {
        public EfBookingDal(SignalRContext context) : base(context)
        {
        }

		public void BookingStatusApproved(int id)
		{
			using var context=new SignalRContext();
			var values = context.Bookings.Find(id);
			values.BookingDescription = "Rezervasyon Onaylandı";
			context.SaveChanges();
		}

		public void BookingStatusCancelled(int id)
		{
			using var context = new SignalRContext();
			var values = context.Bookings.Find(id);
			values.BookingDescription = "Rezervasyon İptal Edildi";
			context.SaveChanges();
		}
	}
}
