﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRWebUI.Dtos.BasketDtos;
using SignalRWebUI.Dtos.ProductDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;//yapıcı metot
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();//istemci oluşturuldu
            var responseMessage = await client.GetAsync("https://localhost:7298/api/Product");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> AddBasket(int id)
        {
            CreateBasketDto createBasketDto = new CreateBasketDto();
            createBasketDto.ProductId = id;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7298/api/Basket", stringContent);//sayfaya giderken string contenti de götürüyor
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return Json(createBasketDto);
        }
    }
}
