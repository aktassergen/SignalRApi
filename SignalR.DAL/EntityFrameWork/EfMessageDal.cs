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
	public class EfMessageDal : GenericRepository<Message>, IMessageDal
	{
		public EfMessageDal(SignalRContext context) : base(context)
		{
		}
	}
}
