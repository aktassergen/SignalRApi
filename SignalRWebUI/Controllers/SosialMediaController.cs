using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.SosialMediaDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class SosialMediaController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public SosialMediaController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;//yapıcı metot
		}

		public async Task<IActionResult> Index()
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
		[HttpGet]
		public IActionResult CreateSosialMedia()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateSosialMedia(CreateSosialMediaDto createSosialMediaDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createSosialMediaDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7298/api/SosialMedia", stringContent);//sayfaya giderken string contenti de götürüyor
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteSosialMedia(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7298/api/SosialMedia/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> UpdateSosialMedia(int id)
		{
			//updateCategoryDto.CategoryStatus = true;
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7298/api/SosialMedia/{id}");//once güncellemek istediğimiz veriyi getiriyoruz
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateSosialMediaDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateSosialMedia(UpdateSosialMediaDto updateSosialMediaDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateSosialMediaDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7298/api/SosialMedia/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
