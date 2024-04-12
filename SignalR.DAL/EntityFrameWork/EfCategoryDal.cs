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
    public class EfCategoryDal : GenericRepository<Category>, ICategoryDal
    {
        public EfCategoryDal(SignalRContext context) : base(context)
        {
        }

		public int ActiveCategoryCount()
		{
			using var context=new SignalRContext();
			return context.Categories.Where(x=>x.CategoryStatus==true).Count();
		}

		public int CategoryCount()
		{
			using var context = new SignalRContext();
			return context.Categories.Count();//katagorinin sayısını dönen metot
		}

		public int PassiveCategoryCount()
		{
			using var context = new SignalRContext();
			return context.Categories.Where(x => x.CategoryStatus == false).Count();
		}
	}
}
