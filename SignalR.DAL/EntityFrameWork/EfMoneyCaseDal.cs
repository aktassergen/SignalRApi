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
	public class EfMoneyCaseDal:GenericRepository<MoneyCase> ,IMoneyCaseDal
	{
        public EfMoneyCaseDal(SignalRContext context):base(context)
        {

        }

		public decimal TotalMoneyCaseAmount()
		{
			using var context = new SignalRContext();
			return context.MoneyCases.Select(x=>x.TotalAmount).FirstOrDefault();
		}
	}
}
