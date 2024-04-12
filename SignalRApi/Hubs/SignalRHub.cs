using Microsoft.AspNetCore.SignalR;
using SignalR.DAL.Concrete;

namespace SignalRApi.Hubs
{
	public class SignalRHub:Hub
	{
		//sunucu işlemi görecek ve dağıtım kısmını yapacağız
		SignalRContext context = new SignalRContext();

		//aşağıdaki metoda abone olacam v aşağıdaki metotdan da sendasync ye yapısını kullanacam
		public async Task SendCategoryCount()
		{
			var value = context.Categories.Count();
			await Clients.All.SendAsync("ReceiveCategoryCount", value);
		}
	}
}
