using Microsoft.EntityFrameworkCore;
using SignalR.DAL.Abstract;
using SignalR.DAL.Concrete;
using SignalR.DAL.Repository;
using SignalR.Dto.ProductDto;
using SignalR.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DAL.EntityFrameWork
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(SignalRContext context) : base(context)
        {
        }

        public List<Product> GetProductsWithCategories()
        {
            var context=new SignalRContext();
            var values=context.Products.Include(x=>x.Category).ToList();
            return values;
        }

		public int ProductCount()
		{
			using var context=new SignalRContext();
            return context.Products.Count();
		}

		public int ProductCountByCategoryNameDrink()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x=>x.CategoryId==(context.Categories.Where(y=>y.CategoryName=="İçecek").Select(z=>z.CategoryId).FirstOrDefault())).Count();

		}

		public int ProductCountByCategoryNameHamburger()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.CategoryId == (context.Categories.Where(y => y.CategoryName == "Hamburgerler").Select(z => z.CategoryId).FirstOrDefault())).Count();
		}

		public string ProductNameByMaxPrice()
		{
			using var context=new SignalRContext();
			return context.Products.Where(x => x.ProductPrice == (context.Products.Max(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();
		}

		public string ProductNameByMinPrice()
		{
			using var context = new SignalRContext();
			return context.Products.Where(x => x.ProductPrice == (context.Products.Min(y => y.ProductPrice))).Select(z => z.ProductName).FirstOrDefault();
		}

		public decimal ProductPriceAvg()
		{
			using var context=new SignalRContext();
			return Convert.ToDecimal(context.Products.Average(x => x.ProductPrice));
		}

		public decimal ProductAvgPriceByHamburger()
		{
			using var context = new SignalRContext();
			return (decimal)context.Products.Where(x => x.CategoryId == (context.Categories.Where(y => y.CategoryName == "Hamburgerler").Select(z => z.CategoryId).FirstOrDefault())).Average(w=>w.ProductPrice);
		}
	}
}
