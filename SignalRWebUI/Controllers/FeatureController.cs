using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.FeatureDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class FeatureController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public FeatureController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;//yapıcı metot
		}

		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();//istemci oluşturuldu
			var responseMessage = await client.GetAsync("https://localhost:7298/api/Feature");//verileri istemek için kullanılan metot içerisinde adres olacak
			if (responseMessage.IsSuccessStatusCode)//kod 200 lü dönerse yani başarılı olursa
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();//içeriği string formatında oku
																				 //jsondan gelen içeriği
				var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);//jesondaki veriyi çözmek için kullandığım için deserialize
																							  //listelerken deserialize ekleme güncellemede serialize
				return View(values);
			}
			return View();
		}
		[HttpGet]
		public IActionResult CreateFeature()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createFeatureDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7298/api/Feature", stringContent);//sayfaya giderken string contenti de götürüyor
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> DeleteFeature(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7298/api/Feature/{id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
		public async Task<IActionResult> UpdateFeature(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7298/api/Feature/{id}");//once güncellemek istediğimiz veriyi getiriyoruz
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateFeatureDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7298/api/Feature/", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
