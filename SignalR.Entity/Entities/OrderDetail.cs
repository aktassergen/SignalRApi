using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Entity.Entities
{
	public class OrderDetail
	{
		public int OrderDetailId { get; set; }
		public int ProductId { get; set; }
		public Product Product { get; set; }
		public int OrderDetailCount { get; set; }
		public decimal OrderDetailUnitPrice { get; set; }
		public decimal OrderDetailTotalPrice { get; set;}
		public int OrderId { get; set; }
		public Order Order { get; set; }
	}
}
