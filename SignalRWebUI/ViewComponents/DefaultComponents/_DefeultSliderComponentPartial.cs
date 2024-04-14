using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SliderDtos;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
	public class _DefeultSliderComponentPartial:ViewComponent
	{
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefeultSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;//yapıcı metot
        }
        public async Task<IViewComponentResult> InvokeAsync()
		{
            var client = _httpClientFactory.CreateClient();//istemci oluşturuldu
            var responseMessage = await client.GetAsync("https://localhost:7298/api/Sliders");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultSliderDto>>(jsonData);
            return View(values);
		}
	}
}
