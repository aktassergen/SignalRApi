using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SosialMediaDtos;

namespace SignalRWebUI.ViewComponents.UILeyoutComponents
{
	public class _UILayoutSosialMediaComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
		public _UILayoutSosialMediaComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;//yapıcı metot
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();//istemci oluşturuldu
			var responseMessage = await client.GetAsync("https://localhost:7298/api/SosialMedia");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultSosialMediaDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}

